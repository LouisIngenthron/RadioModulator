using NAudio;
using NAudio.Wave;
using NAudio.WaveFormRenderer;

namespace DialogRadioModifier
{
    public partial class MainForm : Form, WaveformVisualizer.IDataSource
    {
        private const int TRACKBAR_RESOLUTION = 100;
        private static readonly int[] EXPORT_SAMPLE_RATES = { 44100, 32000, 16000, 8000, };
        private static readonly int[] EXPORT_STEP_SIZES = { 0, 100, 32, 16, };
        private static readonly float[] STATIC_STRENGTH_MULTIPLIERS = { 0.01f, 0.05f, 0.1f, 0.2f, };

        public String? SourceFilename { get; set; }
        public float StartTimePercent { get; set; }
        public float EndTimePercent { get; set; }

        public MainForm()
        {
            InitializeComponent();
            waveformVisualizer1.DataSource = this;

            // disable everything until an input file is chosen
            trackBarStart.Enabled = false;
            trackBarEnd.Enabled = false;
            comboBoxQuality.Enabled = false;
            buttonExport.Enabled = false;
            trackBarStart.Minimum = trackBarEnd.Minimum = 0;
            trackBarStart.Maximum = trackBarEnd.Maximum = TRACKBAR_RESOLUTION;
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Sound Files|*.wav;*.ogg;*.mp3";
            if (d.ShowDialog() == DialogResult.OK)
            {
                // set up config for renderer
                MaxPeakProvider maxPeakProvider = new MaxPeakProvider();
                RmsPeakProvider rmsPeakProvider = new RmsPeakProvider(200); // e.g. 200
                SamplingPeakProvider samplingPeakProvider = new SamplingPeakProvider(200); // e.g. 200
                AveragePeakProvider averagePeakProvider = new AveragePeakProvider(4); // e.g. 4

                StandardWaveFormRendererSettings myRendererSettings = new StandardWaveFormRendererSettings();
                myRendererSettings.Width = waveformVisualizer1.Width;
                myRendererSettings.TopHeight = waveformVisualizer1.Height / 2;
                myRendererSettings.BottomHeight = waveformVisualizer1.Height / 2;

                // render the waveform image
                WaveFormRenderer renderer = new WaveFormRenderer();
                WaveStream reader;
                SourceFilename = d.FileName;
                if (SourceFilename.ToLower().EndsWith(".mp3"))
                {
                    reader = new Mp3FileReader(SourceFilename);
                }
                else
                {
                    reader = new WaveFileReader(SourceFilename);
                }
                Image image = renderer.Render(reader, averagePeakProvider, myRendererSettings);

                // apply settings to controls
                waveformVisualizer1.ImgGraph = image;
                StartTimePercent = 0;
                EndTimePercent = 1;
                trackBarStart.Value = 0;
                trackBarEnd.Value = TRACKBAR_RESOLUTION;
                comboBoxQuality.SelectedIndex = 0;

                // enable everything for editing
                waveformVisualizer1.Refresh();

                trackBarStart.Enabled = true;
                trackBarEnd.Enabled = true;
                comboBoxQuality.Enabled = true;
                buttonExport.Enabled = true;
            }
        }

        private void trackBarStart_Scroll(object sender, EventArgs e)
        {
            if (trackBarStart.Enabled)
            {
                StartTimePercent = trackBarStart.Value / (float)TRACKBAR_RESOLUTION;
                waveformVisualizer1.Refresh();
            }
        }

        private void trackBarEnd_Scroll(object sender, EventArgs e)
        {
            if (trackBarEnd.Enabled)
            {
                EndTimePercent = trackBarEnd.Value / (float)TRACKBAR_RESOLUTION;
                waveformVisualizer1.Refresh();
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(SourceFilename))
                throw new InvalidOperationException();

            List<float> totalData = new List<float>();
            int sourceRate;
            float minVal = Single.MaxValue, maxVal = Single.MinValue;
            // read the source data
            using (AudioFileReader reader = new AudioFileReader(SourceFilename))
            {
                sourceRate = reader.WaveFormat.SampleRate;
                float[] tempData = new float[128];
                int offset = 0;
                while (reader.CanRead)
                {
                    int read = reader.Read(tempData, 0, tempData.Length);
                    if (read == 0)
                    {
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < read; i++)
                        {
                            minVal = Math.Min(minVal, tempData[i]);
                            maxVal = Math.Max(maxVal, tempData[i]);
                            totalData.Add(tempData[i]);
                        }
                        offset += read;
                    }
                }
            }

            // trimming
            int firstFrameIndex = (int)Math.Floor(StartTimePercent * totalData.Count);
            int lastFrameIndex = (int)Math.Floor(EndTimePercent * totalData.Count);

            Random rand = new Random();
            List<float> outData = new List<float>();
            // the target rate is the sample rate of the output file, usually smaller than the source rate
            int targetRate = EXPORT_SAMPLE_RATES[comboBoxQuality.SelectedIndex];
            // the static multiplier controls how strong the constant background static fuzz is for the output
            float staticMult = STATIC_STRENGTH_MULTIPLIERS[comboBoxQuality.SelectedIndex];
            // the step size controls the resolution of each sample in the output.
            // In audio files, this is usually controlled by the bitrate
            int stepSize = EXPORT_STEP_SIZES[comboBoxQuality.SelectedIndex];

            int numCapSamples = (int)(targetRate * 0.2f);
            // generate starting kssh if requested
            if(checkBoxCaps.Checked)
            {
                float prevVal = 0;
                for(int i=0;i<numCapSamples/2;i++)
                {
                    var nextVal = (float)((rand.NextDouble() - 0.5) * 0.6f);
                    outData.Add((prevVal + nextVal) * 0.5f);
                    outData.Add(nextVal);
                }
            }

            float rateRatio = targetRate / (float)sourceRate;
            float rateFill = 0;
            // transform the source audio into the destination audio
            for (int i = firstFrameIndex; i <= lastFrameIndex; i++)
            {
                // rateFill variable handles the difference between the sample rates
                rateFill += rateRatio;
                while (rateFill >= 1)
                {
                    // this is how much ambient static is added
                    float stat = (float)((rand.NextDouble() - 0.5) * staticMult);
                    // this is the source plus the static
                    float val = totalData[i] + stat;
                    // this will make the clip louder or softer to normalize it against other clips, if requested
                    if(checkBoxNormalize.Checked)
                    {
                        if(val > 0)
                        {
                            val = (val / maxVal) * 0.6f;
                        }
                        else if(val < 0)
                        {
                            val = (val / minVal) * -0.6f;
                        }
                    }
                    // this will reduce the sample resolution
                    if(stepSize > 0)
                    {
                        val = (int)Math.Round(val * stepSize) / (float)stepSize;
                    }
                    outData.Add(val);
                    rateFill--;
                }
            }

            // generate ending kssh if requested
            if (checkBoxCaps.Checked)
            {
                float prevVal = 0;
                for (int i = 0; i < numCapSamples / 2; i++)
                {
                    var nextVal = (float)((rand.NextDouble() - 0.5) * 0.6f);
                    outData.Add((prevVal + nextVal) * 0.5f);
                    outData.Add(nextVal);
                }
            }

            // figure out the output filename
            String? folder = Path.GetDirectoryName(SourceFilename);
            if (folder == null)
                throw new InvalidOperationException();
            String fn = Path.GetFileNameWithoutExtension(SourceFilename)+"_processed.wav";
            String outFilename = Path.Combine(folder, fn);
            int extraNum = 1;
            while (File.Exists(outFilename))
            {
                // the default output filename already exists, so let's find another
                extraNum++;
                fn = Path.GetFileNameWithoutExtension(SourceFilename) + "_processed (" + extraNum + ").wav";
                outFilename = Path.Combine(folder, fn);
            }
            
            // all data is processed.  time to actually write file
            WaveFormat format = new WaveFormat(targetRate, 16, 1);
            using (WaveFileWriter writer = new WaveFileWriter(outFilename, format))
            {
                writer.WriteSamples(outData.ToArray(), 0, outData.Count);
            }
        }
    }
}