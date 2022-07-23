using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogRadioModifier
{
    public partial class WaveformVisualizer : UserControl
    {
        public interface IDataSource
        {
            float StartTimePercent { get; }
            float EndTimePercent { get; }
        }

        public IDataSource? DataSource;
        public Image? ImgGraph;

        public WaveformVisualizer()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            if (ImgGraph != null)
            {
                e.Graphics.DrawImage(ImgGraph, new Rectangle(0, 0, Width, Height));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (DataSource != null)
            {
                var penStart = new Pen(Color.FromArgb(255, 0, 255, 0));
                int startX = Math.Max(0, Math.Min(Width - 1, (int)Math.Round(Width * DataSource.StartTimePercent)));
                e.Graphics.DrawLine(penStart, new Point(startX, 0), new Point(startX, Height));
                
                var penEnd = new Pen(Color.FromArgb(255, 255, 0, 0));
                int endX = Math.Max(0, Math.Min(Width - 1, (int)Math.Round(Width * DataSource.EndTimePercent)));
                e.Graphics.DrawLine(penEnd, new Point(endX, 0), new Point(endX, Height));
            }
        }
    }
}
