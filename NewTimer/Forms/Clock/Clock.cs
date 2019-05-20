using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTimer.Forms.Clock
{
    public class Clock : TimerFormBase
    {
        public override Control BarTabContents()
        {
            return new FullContents();
        }

        public override Control DaysTabContents()
        {
            return new FullContents();
        }

        public override Control FullTabContents()
        {
            return new FullContents();
        }

        public override string GetBarTabName()
        {
            return "$$_NULL";
        }
    }
}
