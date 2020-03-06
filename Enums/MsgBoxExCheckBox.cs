using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsgBoxEx
{
    [Flags]
    public enum MsgBoxCheckBox
    {
        /// <summary>
        /// Show the check box.
        /// </summary>
        Show = 1,
        /// <summary>
        /// Hides the check box (default)
        /// </summary>
        Hide = 0,
        /// <summary>
        /// Show as checked.
        /// </summary>
        Checked = 2,
    }
}
