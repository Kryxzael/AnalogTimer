using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bars;

namespace NewTimer
{
    /// <summary>
    /// Stores configuration and other global settings
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Gets or sets the time the timer targets
        /// </summary>
        public static DateTime Target { get; set; } = new DateTime(2017, 4, 7, 15, 05, 0);

        /// <summary>
        /// Will the time selector use 24-hour time?
        /// </summary>
        public static bool Use24HourSelector { get; set; } = false;

        /// <summary>
        /// The color scheme that is selected. This value is set when the timer starts
        /// </summary>
        public static ColorScheme ColorScheme { get; set; }

        /// <summary>
        /// Gets the time to display on the timer. This is value will start incrementing once the target time has passed
        /// </summary>
        /// <returns></returns>
        public static TimeSpan TimeLeft => DateTime.Now > Target ? DateTime.Now - Target : Target - DateTime.Now;

        /// <summary>
        /// Gets the real time left until the target time. This value will go negative after the target time
        /// </summary>
        /// <returns></returns>
        public static TimeSpan RealTimeLeft => Target - DateTime.Now;

        /// <summary>
        /// Has the target time passed?
        /// </summary>
        public static bool Overtime => DateTime.Now > Target;

        /*
         * Constants
         */

        /// <summary>
        /// The random number generator that is used for all randomness
        /// </summary>
        public static readonly Random MasterRandom = new Random();

        /// <summary>
        /// The color that will be used as the text color for the whole application
        /// </summary>
        public static Color GlobalForeColor { get; } = ColorTranslator.FromHtml("#dddddd");

        /// <summary>
        /// The color that will be used as the background color for the whole application
        /// </summary>
        public static Color GlobalBackColor { get; } = ColorTranslator.FromHtml("#111111");

        /// <summary>
        /// The color that will be used as the background color for the whole application
        /// </summary>
        public static Color GlobalOvertimeColor { get; } = ColorTranslator.FromHtml("#330000");

        /// <summary>
        /// The color that will be used to gray out text
        /// </summary>
        public static Color GlobalGrayedColor { get; } = ColorTranslator.FromHtml("#333333");


        /// <summary>
        /// Gets the configuration settings that the time bar will use. The key is the minimum unit time that will be used to apply the settings
        /// </summary>
        public static Dictionary<TimeSpan, BarSettings> BarSettings = new Dictionary<TimeSpan, BarSettings>()
        {
            /*  1y */ { new TimeSpan(365, 0, 0, 0), CreateBarSettings(1, 1)},

            /* 30d */ { new TimeSpan(30, 0, 0, 0), CreateBarSettings(30, 30) },
            /*  7d */ { new TimeSpan(7, 0, 0, 0), CreateBarSettings(7, 7) },
            /*  1d */ { new TimeSpan(1, 0, 0, 0), CreateBarSettings(1, 1) },

            /*  3y */ { new TimeSpan(12, 0, 0), CreateBarSettings(12, 3) },
            /*  2y */ { new TimeSpan(6, 0, 0), CreateBarSettings(6, 2) },
            /*  1h */ { new TimeSpan(1, 0, 0), CreateBarSettings(1, 1) },

            /* 15m */ { new TimeSpan(0, 30, 0), CreateBarSettings(30, 15) },
            /*  5y */ { new TimeSpan(0, 10, 0), CreateBarSettings(10, 5) },

            /*  1m */ { new TimeSpan(0, 1, 0), CreateBarSettings(1, 1) },
            /* 10s */ { new TimeSpan(0, 0, 10), CreateBarSettings(10, 10) },
            /*  1s */ { new TimeSpan(0, 0, 0), CreateBarSettings(1, 1) }
        };

        /// <summary>
        /// Gets the available color schemes
        /// </summary>
        public static ColorScheme[] ColorSchemes { get; } =
        {
            //Random
            new Schemes.SchemeRandom(),

            //Single colored
            new Schemes.SchemeSingle("Reds", Color.Red),
            new Schemes.SchemeSingle("Oranges", Color.OrangeRed),
            new Schemes.SchemeSingle("Yellows", Color.Yellow),
            new Schemes.SchemeSingle("Greens", Color.LimeGreen),
            new Schemes.SchemeSingle("Blues", Color.Blue),
            new Schemes.SchemeSingle("Aqua", Color.Aqua),
            new Schemes.SchemeSingle("Purples", Color.Purple),
            new Schemes.SchemeSingle("Grays", Color.White),

            //Gauges
            new Schemes.SchemeCustom("Positive", Schemes.SchemeCustom.LoopType.Ceiling, 
                /*  1s */ Color.Lime,
                /* 10s */ Color.LimeGreen,
                /*  1m */ Color.Green,
                /*  5m */ Color.GreenYellow,
                /* 15m */ Color.Gold,
                /*  1h */ Color.OrangeRed,
                /*  2h */ Color.Red,
                /*  3h */ Color.FromArgb(0xE0, 0, 0),
                /*  1d */ Color.FromArgb(0xC0, 0, 0),
                /*  7d */ Color.FromArgb(0xA0, 0, 0),
                /* 30d */ Color.FromArgb(0x80, 0, 0),
                /*  1y */ Color.FromArgb(0x40, 0, 0),
                /* >1y */ Color.FromArgb(0x20, 0, 0)
            ),

            new Schemes.SchemeCustom("Negative", Schemes.SchemeCustom.LoopType.Ceiling,
                /*  1s */ Color.DarkRed,
                /* 10s */ Color.Red,
                /*  1m */ Color.OrangeRed,
                /*  5m */ Color.Orange,
                /* 15m */ Color.Gold,
                /*  1h */ Color.YellowGreen,
                /*  2h */ Color.Green,
                /*  3h */ Color.LimeGreen,
                /*  1d */ Color.Lime,
                /*  7d */ Color.FromArgb(0x20, 0xFF, 0x20),
                /* 30d */ Color.FromArgb(0x40, 0xFF, 0x40),
                /*  1y */ Color.FromArgb(0x60, 0xFF, 0x60),
                /* >1y */ Color.FromArgb(0x80, 0xFF, 0x80)
            ),

            new Schemes.SchemeCustom("Long Pos", Schemes.SchemeCustom.LoopType.Ceiling,
                /*  1s */ Color.White,
                /* 10s */ Color.FromArgb(0xBF, 0xFF, 0xBF),
                /*  1m */ Color.FromArgb(0x8F, 0xFF, 0x8F),
                /*  5m */ Color.FromArgb(0x4F, 0xFF, 0x4F),
                /* 15m */ Color.Lime,
                /*  1h */ Color.LimeGreen,
                /*  2h */ Color.GreenYellow,
                /*  3h */ Color.Green,
                /*  1d */ Color.Gold,
                /*  7d */ Color.OrangeRed,
                /* 30d */ Color.Red,
                /*  1y */ Color.DarkRed,
                /* >1y */ Color.Black
            ),

            new Schemes.SchemeCustom("Long Neg", Schemes.SchemeCustom.LoopType.Ceiling,
                /*  1s */ Color.Black,
                /* 10s */ Color.FromArgb(0x4F, 0x00, 0x00),
                /*  1m */ Color.FromArgb(0x8F, 0x00, 0x00),
                /*  5m */ Color.FromArgb(0xBF, 0x00, 0x00),
                /* 15m */ Color.Red,
                /*  1h */ Color.FromArgb(0xFF, 0x2F, 0x00),
                /*  2h */ Color.FromArgb(0xFF, 0x4F, 0x00),
                /*  3h */ Color.FromArgb(0xFF, 0x8F, 0x00),
                /*  1d */ Color.FromArgb(0xFF, 0xBF, 0x00),
                /*  7d */ Color.Gold,
                /* 30d */ Color.Green,
                /*  1y */ Color.Lime,
                /* >1y */ Color.White
            )
        };

        /// <summary>
        /// Starts the timer
        /// </summary>
        /// <param name="target">Target time</param>
        /// <param name="closingForm">Form that will be closed, this should be the settings form</param>
        public static void StartTimer(DateTime target, ColorScheme colorScheme, Form closingForm = null)
        {
            //Set target and color scheme
            Target = target;
            ColorScheme = colorScheme;

            //Close the closing form with a result of OK so that the application doesn't exit
            if (closingForm != null)
            {
                closingForm.DialogResult = DialogResult.OK;
                closingForm.Close();
            }

            //Colorize the bar
            ColorizeTimerBar();

            //Show main form
            new Forms.Clock.Clock().Show();
        }


        /// <summary>
        /// Creates a bar setting object with the given minValue and interval
        /// </summary>
        /// <param name="maxValue"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        private static BarSettings CreateBarSettings(float maxValue, int interval)
        {
            return new BarSettings(maxValue, interval, Color.White, Color.White);
        }

        /// <summary>
        /// Populates the bar control with a colors from the current color scheme
        /// </summary>
        internal static void ColorizeTimerBar()
        {
            //Get colors
            Color[] color = ColorScheme.GenerateMany(BarSettings.Count, MasterRandom).ToArray();

            //Apply colors to bar settings
            for (int i = 0; i < BarSettings.Count - 1; i++)
            {
                //Apply fill color
                BarSettings.Values.ElementAt(BarSettings.Count - (i + 1)).FillColor = color[i];

                //Apply overflow color
                BarSettings.Values.ElementAt(BarSettings.Count - (i + 1)).OverflowColor = color[i + 1];
            }
        }

        /// <summary>
        /// Gets the decimals of a number and returns it as a integer. Eg: 1.25 => 25
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="significantDigits">The amount of digits to get</param>
        /// <returns></returns>
        public static int GetDecimals(double value, int significantDigits)
        {
            return (int)((value - Math.Truncate(value)) * Math.Pow(10, significantDigits));
        }
    }
}
