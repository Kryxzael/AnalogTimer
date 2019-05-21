using NewTimer.FormParts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTimer.Forms.Clock
{
    public class ClockControl : UserControl, ICountdown
    {
        private Color[] _colors;
        private bool _showDottedHourHand;

        /*
         * Constants and settings
         */

        //Background
        private static readonly Brush FRAME_BRUSH = new SolidBrush(ColorTranslator.FromHtml("#333"));
        private static readonly Brush BG_BRUSH = new SolidBrush(ColorTranslator.FromHtml("#222"));
        private static readonly Brush BG_TRUE_BRUSH = new SolidBrush(Config.GlobalBackColor);

        private static readonly Pen FRAME_MARK_PEN = new Pen(ColorTranslator.FromHtml("#444"), 3) { EndCap = LineCap.Round };
        private static readonly Pen FRAME_MARK_BIG_PEN = new Pen(ColorTranslator.FromHtml("#444"), 6) { EndCap = LineCap.Round };

        //Scales
        private const float BG_FRAME_SCALE = 0.1f;
        private const float HOUR_HAND_SCALE = 0.5f;
        private const float MINUTE_HAND_SCALE = 1 - BG_FRAME_SCALE;
        private const float SECOND_HAND_SCALE = MINUTE_HAND_SCALE;

        private const float NUMBER_HOUR_DISTANCE_SCALE = 0.4f;
        private const float NUMBER_MINUTE_DISTANCE_SCALE = 0.7f;
        private const float NUMBER_SECOND_DISTANCE_SCALE = NUMBER_MINUTE_DISTANCE_SCALE;
        private const float FONT_SIZE = 28f;

        //Hand and number colors
        private static readonly Color COLOR_HAND = ColorTranslator.FromHtml("#BBB");
        private static readonly Color COLOR_HAND_WEAK = ColorTranslator.FromHtml("#888");
        private static readonly Color COLOR_HAND_BORDER = ColorTranslator.FromHtml("#222");
        private static readonly Color COLOR_NUMBER = ColorTranslator.FromHtml("#444");

        //Hand and number pens and brushes
        private static readonly Pen PEN_BORDER_NORMAL = new Pen(COLOR_HAND_BORDER, 7) { EndCap = LineCap.Round, StartCap = LineCap.Round };
        private static readonly Pen PEN_FILL_NORMAL = new Pen(COLOR_HAND, 5) { EndCap = LineCap.Round, StartCap = LineCap.Round };

        private static readonly Pen PEN_BORDER_THIN = new Pen(COLOR_HAND_BORDER, 4) { EndCap = LineCap.Round, StartCap = LineCap.Round };
        private static readonly Pen PEN_FILL_THIN = new Pen(COLOR_HAND, 2) { EndCap = LineCap.Round, StartCap = LineCap.Round };

        private static readonly Pen PEN_DOTTED = new Pen(COLOR_HAND_WEAK, 4) { EndCap = LineCap.Round, StartCap = LineCap.Round, DashCap = DashCap.Round, DashStyle = DashStyle.Dot };
        private static readonly Pen PEN_DOTTED_THIN = new Pen(COLOR_HAND_WEAK, 2) { EndCap = LineCap.Round, StartCap = LineCap.Round, DashCap = DashCap.Round, DashStyle = DashStyle.Dot };

        private static readonly Brush BRUSH_NUMBER = new SolidBrush(COLOR_NUMBER);

        //Disc settings
        private const float DISC_INITAL_SCALE = (1 - BG_FRAME_SCALE) * 0.95f;
        private const float DISC_DIVIDEND_INCREMENT = 0.2f;

        public ClockControl()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            _colors = Config.ColorScheme.GenerateMany(24, Config.MasterRandom).ToArray();

            Font = new Font(DefaultFont.FontFamily, FONT_SIZE);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Config.Target != DateTime.Now.Date)
            {
                OnDrawBackCircle(e);
            }
            
            OnDrawNumbers(e);

            OnDrawMinuteHand(e);
            OnDrawSecondHand(e);
            OnDrawHourHand(e);

            if (Config.Target == DateTime.Now.Date)
            {
                return;
            }
            OnDrawMinutesLeftHand(e);
            OnDrawSecondsLeftHand(e);
            OnDrawHoursLeftHand(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            //Draw the frame
            e.Graphics.FillEllipse(FRAME_BRUSH, e.ClipRectangle);

            //Draw the hour lines;
            Point center = new Point(
                x: e.ClipRectangle.Left + e.ClipRectangle.Width / 2,
                y: e.ClipRectangle.Top + e.ClipRectangle.Height / 2
            );
            int radius = e.ClipRectangle.Width / 2;

            for (int i = 0; i < 12; i++)
            {
                e.Graphics.DrawLine(
                    pen: i % 3 == 0 ? FRAME_MARK_BIG_PEN : FRAME_MARK_PEN,
                    pt1: center,
                    pt2: GetPointAtAngle(center, radius, i / 12f * 360f)
                );
            }

            //Draw the fill
            Rectangle nonFrameArea = new Rectangle(
                x: (int)(e.ClipRectangle.Left + (e.ClipRectangle.Width * BG_FRAME_SCALE / 2)),
                y: (int)(e.ClipRectangle.Top + (e.ClipRectangle.Width * BG_FRAME_SCALE / 2)),
                width: (int)(e.ClipRectangle.Width * (1 - BG_FRAME_SCALE)),
                height: (int)(e.ClipRectangle.Height * (1 - BG_FRAME_SCALE))
            );

            e.Graphics.FillEllipse(Config.RealTimeLeft.TotalMinutes < 1f ? BG_TRUE_BRUSH : BG_BRUSH, nonFrameArea);
        }

        protected virtual void OnDrawHourHand(PaintEventArgs e)
        {
            OnDrawHand(
                e: e,
                scale: HOUR_HAND_SCALE, 
                angle: CalculateAngle(DateTime.Now.Hour % 12 + DateTime.Now.Minute / 60f, 12), 
                fillPen: PEN_FILL_NORMAL, 
                borderPen: PEN_BORDER_NORMAL
            );
        }

        protected virtual void OnDrawMinuteHand(PaintEventArgs e)
        {
            OnDrawHand(
                e: e,
                scale: MINUTE_HAND_SCALE, 
                angle: CalculateAngle(DateTime.Now.Minute + DateTime.Now.Second / 60f, 60), 
                fillPen: PEN_FILL_NORMAL, 
                borderPen: PEN_BORDER_NORMAL
            );
        }

        protected virtual void OnDrawSecondHand(PaintEventArgs e)
        {
            OnDrawHand(
                e: e, 
                scale: SECOND_HAND_SCALE, 
                angle: CalculateAngle(DateTime.Now.Second + DateTime.Now.Millisecond / 1000f, 60), 
                fillPen: PEN_FILL_THIN, 
                borderPen: PEN_BORDER_THIN
            );
        }

        protected virtual void OnDrawHoursLeftHand(PaintEventArgs e)
        {
            if (!_showDottedHourHand)
            {
                if (Config.TimeLeft.Hours < 1)
                {
                    return;
                }
                else
                {
                    _showDottedHourHand = true;
                }
                
            }

            OnDrawHand(
                e: e,
                scale: HOUR_HAND_SCALE, 
                angle: CalculateAngle((float)Config.TimeLeft.TotalHours % 12, 12), 
                fillPen: PEN_DOTTED, 
                borderPen: null
            );
        }

        protected virtual void OnDrawMinutesLeftHand(PaintEventArgs e)
        {
            OnDrawHand(
                e: e,
                scale: MINUTE_HAND_SCALE, 
                angle: CalculateAngle((float)Config.TimeLeft.TotalMinutes, 60), 
                fillPen: PEN_DOTTED, 
                borderPen: null
            );
        }

        protected virtual void OnDrawSecondsLeftHand(PaintEventArgs e)
        {
            if (Config.Target.Second == 0)
            {
                return;
            }

            OnDrawHand(
                e: e, 
                scale: SECOND_HAND_SCALE, 
                angle: CalculateAngle((float)Config.TimeLeft.TotalSeconds, 60), 
                fillPen: PEN_DOTTED_THIN, 
                borderPen: null
            );
        }

        protected virtual void OnDrawBackCircle(PaintEventArgs e)
        {
            /* local */ void fillPie(Brush color, float startAngle, float angle, float scale)
            {
                Rectangle area = new Rectangle(
                    x: (int)(e.ClipRectangle.Width * (1 - scale) / 2f),
                    y: (int)(e.ClipRectangle.Height * (1 - scale) / 2f),
                    width: (int)(e.ClipRectangle.Width * scale),
                    height: (int)(e.ClipRectangle.Height * scale)
                );

                e.Graphics.FillPie(color, area, -90 + startAngle, angle);
            }


            if (Config.TimeLeft.TotalMinutes < 1f && !Config.Overtime)
            {
                fillPie(
                    color: BG_BRUSH,
                    startAngle: (DateTime.Now.Second + DateTime.Now.Millisecond / 1000f) / 60f * 360f,
                    angle: (float)Config.RealTimeLeft.TotalSeconds / 60f * 360f,
                    scale: 1 - BG_FRAME_SCALE
                );
            }

            float dividend = 1f;
            for (int i = 0; i < Math.Ceiling(Config.TimeLeft.TotalHours); i++)
            {
                using (SolidBrush b = new SolidBrush(_colors[i % _colors.Length]))
                {
                    if (i == Math.Floor(Config.TimeLeft.TotalHours))
                    {
                        fillPie(
                            color: b, 
                            startAngle: (DateTime.Now.Minute + DateTime.Now.Second / 60f) / 60f * 360f,
                            angle: (float)(Config.RealTimeLeft.TotalMinutes % 60) / 60f * 360f, 
                            scale: DISC_INITAL_SCALE / dividend);
                    }
                    else
                    {
                        fillPie(
                            color: b, 
                            startAngle: 0f, 
                            angle: 360f, 
                            scale: DISC_INITAL_SCALE / dividend
                        );
                    }
                }    
                
                dividend += DISC_DIVIDEND_INCREMENT;
            }
        }

        protected virtual void OnDrawNumbers(PaintEventArgs e)
        {
            Point center = new Point(
                x : e.ClipRectangle.Left + (e.ClipRectangle.Right / 2),
                y: e.ClipRectangle.Top + (e.ClipRectangle.Bottom / 2)
            );

            //Draw number at hour hand
            {
                PointF p = GetPointAtAngle(
                    origin: center,
                    length: (int)(NUMBER_HOUR_DISTANCE_SCALE * e.ClipRectangle.Width / 2),
                    angle: CalculateAngle(DateTime.Now.Hour % 12 + DateTime.Now.Minute / 60f, 12)
                );

                byte s = (byte)(Math.Min(byte.MaxValue, Math.Max((Config.TimeLeft.TotalHours - 1), 0) / (1 / 6f) * byte.MaxValue));
                using (Brush brush = new SolidBrush(Color.FromArgb(s, Color.White)))
                {
                    e.Graphics.DrawString(
                        s: Config.TimeLeft.Hours.ToString(),
                        font: Font,
                        brush: brush,
                        point: p,
                        format: new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }
                    );
                }
            }


            //Draw number at minute hand
            {
                PointF p = GetPointAtAngle(
                    origin: center, 
                    length: (int)(NUMBER_MINUTE_DISTANCE_SCALE * e.ClipRectangle.Width / 2), 
                    angle: CalculateAngle(DateTime.Now.Minute + DateTime.Now.Second / 60f, 60)
                );

                byte s = (byte)(Math.Min(byte.MaxValue, Math.Max((Config.TimeLeft.TotalMinutes - 1), 0) / 5f * byte.MaxValue));
                using (Brush brush = new SolidBrush(Color.FromArgb(s, Color.White)))
                {
                    e.Graphics.DrawString(
                        s: Config.TimeLeft.Minutes.ToString("00"),
                        font: Font,
                        brush: brush,
                        point: p,
                        format: new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }
                    );
                }
            }


            //Draw number at second hand
            {
                PointF p = GetPointAtAngle(
                    origin: center,
                    length: (int)(NUMBER_SECOND_DISTANCE_SCALE * e.ClipRectangle.Width / 2),
                    angle: CalculateAngle(DateTime.Now.Second + DateTime.Now.Millisecond / 1000f, 60)
                );

                byte s = (byte)(Config.RealTimeLeft.Milliseconds / 1000f * 255);
                using (Brush brush = new SolidBrush(Color.FromArgb(s, Color.White)))
                {
                    e.Graphics.DrawString(
                        s: Config.TimeLeft.Seconds.ToString("00"),
                        font: Font,
                        brush: brush,
                        point: p,
                        format: new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }
                    );
                }
            }


        }

        protected virtual void OnDrawHand(PaintEventArgs e, float scale, float angle, Pen fillPen, Pen borderPen)
        {
            Point center = new Point(
                x: e.ClipRectangle.Left + e.ClipRectangle.Width / 2,
                y: e.ClipRectangle.Top + e.ClipRectangle.Height / 2
            );

            PointF anglePoint = GetPointAtAngle(center, (int)(scale * e.ClipRectangle.Width) / 2, angle);

            if (borderPen != null)
            {
                e.Graphics.DrawLine(borderPen, center, anglePoint);
            }
            
            e.Graphics.DrawLine(fillPen, center, anglePoint);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _colors = Config.ColorScheme.GenerateMany(12, Config.MasterRandom).ToArray();
            Invalidate();
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
