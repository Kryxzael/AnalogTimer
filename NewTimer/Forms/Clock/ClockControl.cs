using NewTimer.FormParts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTimer.Forms.Clock
{
    public class ClockControl : UserControl, ICountdown
    {
        public ClockControl()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            OnDrawBackCircle(e);
            OnDrawNumbers(e);

            OnDrawSecondHand(e);
            OnDrawMinuteHand(e);
            OnDrawHourHand(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected virtual void OnDrawHourHand(PaintEventArgs e)
        {
            using (Pen hourPen = new Pen(Brushes.White, 5)
            {
                StartCap = System.Drawing.Drawing2D.LineCap.Round,
                EndCap = System.Drawing.Drawing2D.LineCap.Round,
            })
            {
                OnDrawHand(e, e.ClipRectangle.Width / 4, CalculateAngle(DateTime.Now.Hour % 12 + DateTime.Now.Minute / 60f, 12), hourPen);
            }
        }

        protected virtual void OnDrawMinuteHand(PaintEventArgs e)
        {
            using (Pen minutePen = new Pen(Brushes.White, 5)
            {
                StartCap = System.Drawing.Drawing2D.LineCap.Round,
                EndCap = System.Drawing.Drawing2D.LineCap.Round
            })
            {
                OnDrawHand(e, e.ClipRectangle.Width / 2, CalculateAngle(DateTime.Now.Minute + DateTime.Now.Second / 60f, 60), minutePen);
            }
        }

        protected virtual void OnDrawSecondHand(PaintEventArgs e)
        {
            using (Pen minutePen = new Pen(Brushes.White, 2)
            {
                StartCap = System.Drawing.Drawing2D.LineCap.Round,
                EndCap = System.Drawing.Drawing2D.LineCap.Round
            })
            {
                OnDrawHand(e, e.ClipRectangle.Width / 2, CalculateAngle(DateTime.Now.Second + DateTime.Now.Millisecond / 1000f, 60), minutePen);
            }
        }

        protected virtual void OnDrawBackCircle(PaintEventArgs e)
        {

        }

        protected virtual void OnDrawNumbers(PaintEventArgs e)
        {

        }

        protected virtual void OnDrawHand(PaintEventArgs e, int length, float angle, Pen p)
        {
            Point center = new Point(
                x: e.ClipRectangle.Left + e.ClipRectangle.Width / 2,
                y: e.ClipRectangle.Top + e.ClipRectangle.Height / 2
            );

            e.Graphics.DrawLine(p, center, GetPointAtAngle(center, length, angle));
        }

        protected static PointF GetPointAtAngle(Point origin, int length, float angle)
        {
            return new PointF(
                x: origin.X + (float)Math.Cos(ToRadiants(angle)) * length, 
                y: origin.Y + (float)Math.Sin(ToRadiants(angle)) * length
            );
        }

        protected static float ToRadiants(double angle)
        {
            return (float)((Math.PI / 180) * angle);
        }

        protected static float CalculateAngle(float value, float maxValue)
        {
            return (value / maxValue * 360) - 90;
        }

        public void OnCountdownTick(TimeSpan span, bool isOvertime)
        {
            Invalidate();
        }
    }
}
