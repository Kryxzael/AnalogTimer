using CleanNodeTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTimer.Forms
{
    /// <summary>
    /// The main settings panel for the application
    /// </summary>
    public partial class Setup : Form
    {
        public Setup()
        {
            InitializeComponent();

            //Set the hour knob to target the next hour
            knbHour.Value = (DateTime.Now.Hour + 1) % 24;

            /*
             * Set up event handlers
             */

            //Update the day knob's max value to correspond with the amount of days the selected month has (When the month is changed)
            knbMonth.ValueChanged += (s, e) => knbDay.MaxValue = DateTime.DaysInMonth((int)numYear.Value, (int)knbMonth.Value);

            //Start thetimer when either start button is pressed
            btnStartTime.MouseDown += OnClickStart;
            btnStartDuration.MouseDown += OnClickStart;

            //Clean up resources when the application closes
            FormClosing += HandleClose;

            //Set the minimum and maximum values for the year
            numYear.Minimum = DateTime.Now.Year - 1;
            numYear.Maximum = DateTime.Now.Year + 1;

            //Initialize the color scheme selector
            cboxColors.Items.AddRange(Config.ColorSchemes);
            cboxColors.SelectedIndex = 0;

            //Force trigger ChkAdv.CheckedChange (for some reason)
            OnAdvancedToggled(null, null);

            //Recreate suggestions when any knob is tweaked
            foreach (FormParts.Setup.Knob i in tabTime.Controls.Cast<Control>().OfType<FormParts.Setup.Knob>())
            {
                i.ValueChanged += (s, e) => CreateSuggestions();
            }
            foreach (FormParts.Setup.Knob i in tabTime.Controls.Cast<Control>().OfType<FormParts.Setup.Knob>())
            {
                i.ValueChanged += (s, e) => CreateSuggestions();
            }

            //Create initial suggestions and load user data
            CreateSuggestions();
            chk24h.Checked = Properties.Settings.Default.use24h;
        }

        protected override void OnShown(EventArgs e)
        {
            MessageBox.Show(
                "This application is obsolete.\r\n" +
                "It still works, but it will not be maintained.\r\n" +
                "Check out the sister project NewTimer instead as this application's functionality has been merged to that one."
            );
        }

        /// <summary>
        /// Gets the selected color scheme
        /// </summary>
        /// <returns></returns>
        public ColorScheme GetSelectedColorScheme()
        {
            return (ColorScheme)(cboxColors.SelectedItem ?? cboxColors.Items[0]);
        }

        /// <summary>
        /// Recreates the TimeSuggestion buttons at the bottom of the window
        /// </summary>
        private void CreateSuggestions()
        {
            //Deletes any existing buttons
            flwTimeSuggestions.Controls.Clear();
            flwTimeSuggestionsDuration.Controls.Clear();

            //Gets the currently selected hour and minute; to use when creating new suggestions
            int h = (int)knbHour.Value;
            int m = (int)knbMin.Value;

            /* 
             * Smart next xx:mm
             */

            //The given minute has passed. Create for next hour
            if (DateTime.Now.Minute >= m)
            {
                createTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, m, 0).AddHours(1));
            }

            //The given minute has not passed. Create for current hour
            else
            {
                createTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, m, 0));
            }

            /*
             * Smart next hh:mm (today/tomorrow)
             */

            //The given time has passed. Generate for tomorrow
            if (DateTime.Now.TimeOfDay > new TimeSpan(h, m, 0))
            {
                createTimeWithText(
                    text: new DateTime(1, 1, 1, h, m, 0).ToString(Config.Use24HourSelector ? "HH:mm" : "h:mm tt") + " tomorrow", 
                    target: DateTime.Now.Date.AddHours(h).AddMinutes(m).AddDays(1)
                );
            }

            //The given time has not passed. Generate for today
            else
            {
                createTimeWithText(
                    text: new DateTime(1, 1, 1, h, m, 0).ToString(Config.Use24HourSelector ? "HH:mm" : "h:mm tt") + " today", 
                    target: DateTime.Now.Date.AddHours(h).AddMinutes(m)
                );
            }

            /*
             * Quarters
             */

            switch (DateTime.Now.Minute)
            {
                //m = 0..14 => xx:15, xx:30, (xx+1):00
                case int i when i < 15:
                    createTime(DateTime.Now.Date.AddHours(DateTime.Now.Hour + 0.25));
                    createTime(DateTime.Now.Date.AddHours(DateTime.Now.Hour + 0.5f));
                    createTime(DateTime.Now.Date.AddHours(DateTime.Now.Hour + 1));
                    break;
                
                //m = 15..29 => xx:30, xx:45, (xx+1):00
                case int i when i < 30:
                    createTime(DateTime.Now.Date.AddHours(DateTime.Now.Hour + 0.5f));
                    createTime(DateTime.Now.Date.AddHours(DateTime.Now.Hour + 0.75f));
                    createTime(DateTime.Now.Date.AddHours(DateTime.Now.Hour + 1f));
                    break;

                //m = 30..44 => xx:45, (xx+1):00, (xx+1):30
                case int i when i < 45:
                    createTime(DateTime.Now.Date.AddHours(DateTime.Now.Hour + 0.75f));
                    createTime(DateTime.Now.Date.AddHours(DateTime.Now.Hour + 1f));
                    createTime(DateTime.Now.Date.AddHours(DateTime.Now.Hour + 1.5f));
                    break;

                //m = 45..59 => (xx+1):00, (xx+1):30, (xx+2):00
                default:
                    createTime(DateTime.Now.Date.AddHours(DateTime.Now.Hour + 1));
                    createTime(DateTime.Now.Date.AddHours(DateTime.Now.Hour + 1.5f));
                    createTime(DateTime.Now.Date.AddHours(DateTime.Now.Hour + 2));
                    break;
            }

            /*
             * Duration presets
             */
            createTimeDuration("30s", new TimeSpan(0, 0, 30));
            createTimeDuration("1m", new TimeSpan(0, 1, 0));
            createTimeDuration("3m", new TimeSpan(0, 3, 0));
            createTimeDuration("5m", new TimeSpan(0, 5, 0));
            createTimeDuration("10m", new TimeSpan(0, 10, 0));
            createTimeDuration("15m", new TimeSpan(0, 15, 0));
            createTimeDuration("20m", new TimeSpan(0, 20, 0));
            createTimeDuration("30m", new TimeSpan(0, 30, 0));
            createTimeDuration("45m", new TimeSpan(0, 45, 0));
            createTimeDuration("1h", new TimeSpan(1, 0, 0));
            createTimeDuration("2h", new TimeSpan(2, 0, 0));
            createTimeDuration("3h", new TimeSpan(3, 0, 0));

            /*
             * local functions
             */

            //Creates a TimeSuggestion that points to the given datetime
            /* local */ void createTime(DateTime target)
            {
                flwTimeSuggestions.Controls.Add(new FormParts.Setup.TimeSugestion(
                    text: target.ToString(Config.Use24HourSelector ? "HH:mm" : "h:mm tt"), 
                    getTarget: () => target)
                );
            }

            //Creates a TimeSuggestion that points to the given datetime, with a custom label
            /* local */ void createTimeWithText(string text, DateTime target)
            {
                flwTimeSuggestions.Controls.Add(new FormParts.Setup.TimeSugestion(
                    text: text, 
                    getTarget: () => target)
                );
            }

            //Creates a TimeSuggestion that points a certain timespan ahead in time, with a custom label
            /* local */ void createTimeDuration(string text, TimeSpan duration)
            {
                flwTimeSuggestionsDuration.Controls.Add(new FormParts.Setup.TimeSugestion(
                    text: text, 
                    getTarget: () => DateTime.Now + duration)
                );
            }
        }


        /*
         * EVENT HANDLERS
         */

        /// <summary>
        /// Handles the 'Use 24h time' box being toggled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChangeHourMode(object sender, EventArgs e)
        {
            //Update settings
            Config.Use24HourSelector = chk24h.Checked;

            //Redraw hour knob and suggestions to use the correct hour format
            knbHour.Invalidate();
            CreateSuggestions();
        }

        /// <summary>
        /// Handler: Handles the 'Load' button being clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickLoad(object sender, EventArgs e)
        {
            //Create dialog to prompt user
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Countdown preset|*.countdownpreset"
            };

            //Show dialog
            //If the user cancels. Do not attempt to open any files
            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            //Load the file the user picked in the dialog
            LoadFile(dialog.FileName);
        }

        /// <summary>
        /// Handler: Handles the 'Advanced' checkbox being toggled on or off and changes layout accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAdvancedToggled(object sender, EventArgs e)
        {
            //Resets the advanced knobs. The value of these knobs are in effect regardless of whether they are visible or not
            numYear.Value = DateTime.Now.Year;
            knbMonth.Value = DateTime.Now.Month;
            knbDay.Value = DateTime.Now.Day;
            knbSec.Value = 0;

            //Advanced mode is enabled
            if (chkAdv.Checked)
            {
                //Show the advanced knobs
                knbDay.Show();
                knbMonth.Show();
                knbSec.Show();
                numYear.Show();
                lblYear.Show();

                //Move 'Advanced' checkbox
                chkAdv.Location = new Point(305, 131);

                //Set minute step to be finer
                knbMin.Step = 1;
            }

            //Advanced mode is disabled
            else
            {
                //Hide the advanced knobs
                knbDay.Hide();
                knbMonth.Hide();
                knbSec.Hide();
                numYear.Hide();
                lblYear.Hide();

                //Move 'Advanced' checkbox to top again
                chkAdv.Location = new Point(305, 6);

                //Set minute step to be coarser
                knbMin.Step = 5;
            }
        }

        /// <summary>
        /// Handler: Handles the 'save' button being clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickSave(object sender, EventArgs e)
        {
            //Create dialog to display
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Countdown preset|*.countdownpreset",
                FileName = "Preset.countdownpreset"
            };

            //Show dialog
            //If the dialog is canceled. Do not save
            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            //Save file
            if (sender == btnSaveCountdown)
            {
                SaveTimeToFile(dialog.FileName);
            }
            else if (sender == btnSaveDuration)
            {
                SaveDurationToFile(dialog.FileName);
            }

        }

        /// <summary>
        /// Handler: Handles the window being closed (by any means)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleClose(object sender, FormClosingEventArgs e)
        {
            //The application is being exited without starting the timer
            if (DialogResult == DialogResult.None)
            {
                Application.Exit();
            }

            //Save user settings
            Properties.Settings.Default.use24h = chk24h.Checked;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Handler: Handles the user having pressed any of the two 'Start Countdown' buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickStart(object sender, MouseEventArgs e)
        {
            //The user is starting a to-time countdown
            if (sender == btnStartTime)
            {
                Config.StartTimer(
                    target: new DateTime((int)numYear.Value, (int)knbMonth.Value, (int)knbDay.Value, (int)knbHour.Value, (int)knbMin.Value, (int)knbSec.Value),
                    colorScheme: GetSelectedColorScheme(),
                    closingForm: this
                );
            }

            //The user is starting a duration countdown
            else if (sender == btnStartDuration)
            {
                Config.StartTimer(
                    target: DateTime.Now.Add(new TimeSpan((int)knbDurHour.Value, (int)knbDurMin.Value, (int)knbDurSec.Value)),
                    colorScheme: GetSelectedColorScheme(),
                    closingForm: this
                );
            }
        }
    }
}
