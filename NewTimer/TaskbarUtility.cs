using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTimer
{
    /// <summary>
    /// Updates the taskbar
    /// </summary>
    public static class TaskbarUtility
    {
        /// <summary>
        /// Sets the title of a form to a standardized format that mimics the timer
        /// </summary>
        /// <param name="f">Form to set title of</param>
        public static void SetTitle(Form f)
        {
            TimeSpan tl = Config.TimeLeft;
            string title;

            //Less than one minute, show amount of seconds left
            if (tl.TotalMinutes < 1)
            {
                title = tl.Seconds.ToString() + (tl.Seconds == 1 ? " second" : " seconds");
            }

            //Less than one hour, show amount of minutes left
            else if (tl.TotalHours < 1)
            {
                title = tl.Minutes.ToString() + (tl.Minutes == 1 ? " minute" : " minutes");
            }

            //Less than one day, show amount of hours left
            else if (tl.TotalDays < 1)
            {
                title = tl.Hours.ToString() + (tl.Hours == 1 ? " hour" : " hours");
            }

            //Less than one year, show amount of days left
            else if (tl.TotalDays < 360)
            {
                title = tl.Days + (tl.Days == 1 ? " day" : " days");
            }

            //More than a year, show a fallback string
            else
            {
                title = "A long time";
            }


            //We are in overtime, add "ago" to the end of the title
            if (Config.Overtime)
            {
                title += " ago";
            }

            f.Text = title;
        }

        /// <summary>
        /// Sets the taskbar icon's progress information to mimic the timer
        /// </summary>
        /// <param name="f"></param>
        public static void SetProgress(Form f)
        {
            TimeSpan tl = Config.TimeLeft;

            //Get handle of form
            IntPtr handle = f.Handle;

            //Overtime -> Indeterminate state (Value does not apply)
            if (Config.Overtime)
            {
                TaskbarHelper.SetState(handle, TaskbarHelper.TaskbarStates.Indeterminate);
                return;
            }

            //Buffer for storing precalculated values
            double v = 60 - tl.Minutes;

            //1m -> red, yellow and green
            if (tl.TotalMinutes < 1)
            {
                v = 60 - tl.Seconds;
                switch (tl.Seconds % 3)
                {
                    case 0:
                        setProgress(TaskbarHelper.TaskbarStates.Normal, v, 60);
                        break;
                    case 1:
                        setProgress(TaskbarHelper.TaskbarStates.Paused, v, 60);
                        break;
                    case 2:
                        setProgress(TaskbarHelper.TaskbarStates.Error, v, 60);
                        break;
                }
            }

            //1h -> green
            else if (tl.TotalHours < 1) setProgress(TaskbarHelper.TaskbarStates.Normal, v, 59);

            //2h -> yellow
            else if (tl.TotalHours < 2) setProgress(TaskbarHelper.TaskbarStates.Paused, v, 60);

            //3h -> red
            else if (tl.TotalHours < 3) setProgress(TaskbarHelper.TaskbarStates.Error, v, 60);

            //4h -> yellow, green
            else if (tl.TotalHours < 4) setProgress(tl.Seconds % 2 == 0 ?
                TaskbarHelper.TaskbarStates.Paused :
                TaskbarHelper.TaskbarStates.Normal,
                v, 60);

            //5h -> red, green
            else if (tl.TotalHours < 5) setProgress(tl.Seconds % 2 == 0 ?
                TaskbarHelper.TaskbarStates.Error :
                TaskbarHelper.TaskbarStates.Normal,
                v, 60);

            //6h -> red, yellow
            else if (tl.TotalHours < 6) setProgress(tl.Seconds % 2 == 0 ?
                TaskbarHelper.TaskbarStates.Error :
                TaskbarHelper.TaskbarStates.Paused,
                v, 60);

            //1d -> solid green
            else if (tl.TotalDays < 1) setProgress(TaskbarHelper.TaskbarStates.Normal, 1, 1);

            //7d -> solid yellow
            else if (tl.TotalDays < 7) setProgress(TaskbarHelper.TaskbarStates.Paused, 1, 1);

            //>7d -> solid red
            else setProgress(TaskbarHelper.TaskbarStates.Error, 1, 1);

            //Shorthand for TaskbarHelper.SetState and TaskbarHelper.SetValue
            /* local */ void setProgress(TaskbarHelper.TaskbarStates state, double value, double maxValue)
            {
                TaskbarHelper.SetState(handle, state);
                TaskbarHelper.SetValue(handle, value, maxValue);
            }

        }
    }
}
