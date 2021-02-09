using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserConsoleLib;

namespace NewTimer.Commands
{
    public class TimeLeft : Command
    {
        public override string Name => "timeleft";
        public override string HelpDescription => "Gets or sets the time left of the timer";

        public override Syntax GetSyntax(Params args)
        {
            return Syntax.Begin().Or().AddTrailing("New time left");
        }

        protected override void Executed(Params args, IConsoleOutput target)
        {
            //Set target
            if (args.Count >= 1)
            {
                try
                {
                    string arg = args[0].ToLower();

                    if (arg.EndsWith("h"))
                    {
                        Config.Target = DateTime.Now.AddHours(double.Parse(args[0].TrimEnd('h'), NumberStyles.Float, CultureInfo.InvariantCulture));
                    }
                    else if (arg.EndsWith("m"))
                    {
                        Config.Target = DateTime.Now.AddMinutes(double.Parse(args[0].TrimEnd('m'), NumberStyles.Float, CultureInfo.InvariantCulture));
                    }
                    else if (arg.EndsWith("s"))
                    {
                        Config.Target = DateTime.Now.AddSeconds(double.Parse(args[0].TrimEnd('s'), NumberStyles.Float, CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        Config.Target = DateTime.Now + TimeSpan.Parse(args.JoinEnd(0));
                    }

                    target.WriteLine("Target time has been updated to " + Config.Target);
                }
                catch (Exception)
                {
                    ThrowGenericError("Cannot convert input to a valid TimeSpan", ErrorCode.ARGUMENT_INVALID);
                }
            }
        }
    }
}
