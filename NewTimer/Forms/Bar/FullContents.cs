﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewTimer.FormParts;

namespace NewTimer.Forms.Bar
{
    public partial class FullContents : UserControl, ICountdown
    {
        public FullContents()
        {
            InitializeComponent();

            //Sets foreground colors to comply with global settings
            FullH.ForeColor = Config.GlobalForeColor;
            FullM.ForeColor = Config.GlobalForeColor;
            FullS.ForeColor = Config.GlobalForeColor;

            FullTotalH.ForeColor = Config.GlobalForeColor;
            FullTotalM.ForeColor = Config.GlobalForeColor;
            FullTotalS.ForeColor = Config.GlobalForeColor;

            FullFracM.ForeColor = Config.GlobalForeColor;
            FullFracM.ForeColor = Config.GlobalForeColor;

            /*
             * Initialize dynamic fill colors
             */
            //Main display
            FullH.HighlightColor = ColorTranslator.FromHtml("#ff8888");
            FullM.HighlightColor = ColorTranslator.FromHtml("#88ccff");
            FullS.HighlightColor = ColorTranslator.FromHtml("#ffdd88");

            //Integer portions of total hours, minutes and seconds
            FullTotalH.HighlightColor = FullH.HighlightColor;
            FullTotalM.HighlightColor = FullM.HighlightColor;
            FullTotalS.HighlightColor = FullS.HighlightColor;

            //Fraction portions of total hours and minutes
            FullFracH.HighlightColor = FullH.HighlightColor;
            FullFracM.HighlightColor = FullM.HighlightColor;

            /*
             * Set color of leading zeros
             */

            //Main display
            FullH.LeadingZerosColor = Config.GlobalGrayedColor;
            FullM.LeadingZerosColor = Config.GlobalGrayedColor;
            FullS.LeadingZerosColor = Config.GlobalGrayedColor;

            //Integer portions of total hours, minutes and seconds
            FullTotalH.LeadingZerosColor = Config.GlobalGrayedColor;
            FullTotalM.LeadingZerosColor = Config.GlobalGrayedColor;
            FullTotalS.LeadingZerosColor = Config.GlobalGrayedColor;

            //Fraction portions of total hours and minutes
            FullFracH.LeadingZerosColor = Config.GlobalGrayedColor;
            FullFracM.LeadingZerosColor = Config.GlobalGrayedColor;
        }

        /// <summary>
        /// Handler: Updates contents
        /// </summary>
        /// <param name="span"></param>
        /// <param name="isOvertime"></param>
        public void OnCountdownTick(TimeSpan span, bool isOvertime)
        {
            /*
             * Sets the text
             */
            //Main hours
            FullH.Text = span.Hours.ToString("00");
            FullH.RenderLeadingZeros = span.TotalDays >= 1;

            //Main minutes
            FullM.Text = span.Minutes.ToString("00");
            FullM.RenderLeadingZeros = span.TotalHours >= 1;

            //Main seconds
            FullS.Text = span.Seconds.ToString("00");
            FullS.RenderLeadingZeros = span.TotalMinutes >= 1;


            //Total hours
            FullTotalH.Text = Math.Floor(span.TotalHours) >= 100 ? "BIG" : Math.Floor(span.TotalHours).ToString("00");
            FullFracH.Text = Config.GetDecimals(span.TotalHours, 3).ToString("000");
            FullFracH.RenderLeadingZeros = span.TotalHours >= 1;

            //Total minutes
            FullTotalM.Text = Math.Floor(span.TotalMinutes) >= 1000 ? "BIG" : Math.Floor(span.TotalMinutes).ToString("000");
            FullFracM.Text = Config.GetDecimals(span.TotalMinutes, 2).ToString("00");
            FullFracM.RenderLeadingZeros = span.TotalMinutes >= 1;

            //Total seconds
            FullTotalS.Text = Math.Floor(span.TotalSeconds).ToString("0000000");

            /*
             * Set fill effects
             */
            //Main hours
            FullH.Progress = (isOvertime ? ReversedTimeLeft() : Config.TimeLeft).Hours  / 24f;

            //Main minutes
            FullM.Progress = (isOvertime ? ReversedTimeLeft() : Config.TimeLeft).Minutes / 60f;

            //Main seconds
            FullS.Progress = (isOvertime ? ReversedTimeLeft() : Config.TimeLeft).Seconds / 60f;


            //Total hours
            FullTotalH.Progress = FullH.Progress;
            FullFracH.Progress = Config.GetDecimals((float)(isOvertime ? ReversedTimeLeft() : Config.TimeLeft).TotalHours, 3) / 1000f;

            //Total minutes
            FullTotalM.Progress = FullM.Progress;
            FullFracM.Progress = Config.GetDecimals((float)(isOvertime ? ReversedTimeLeft() : Config.TimeLeft).TotalMinutes, 3) / 1000f;

            //Total seconds
            FullTotalS.Progress = FullS.Progress;

        }

        private TimeSpan ReversedTimeLeft()
        {
            return new TimeSpan(1000, 0, 0, 0) - Config.TimeLeft;
        }
    }
}
