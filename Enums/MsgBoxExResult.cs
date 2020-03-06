using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsgBoxEx
{
    public enum MsgBoxResult
    {
        /// <summary>
        /// The dialog box return value is Abort.
        /// </summary>
        Abort,

        /// <summary>
        /// The dialog box return value is Cancel.
        /// </summary>
        Cancel,

        /// <summary>
        /// The dialog box return value is Ignore.
        /// </summary>
        Ignore,

        /// <summary>
        /// The dialog box return value is No.
        /// </summary>
        No,

        /// <summary>
        /// Nothing is returned from the dialog box. This means that the modal dialog continues running.
        /// </summary>
        None,

        /// <summary>
        /// The dialog box return value is OK.
        /// </summary>
        OK,

        /// <summary>
        /// The dialog box return value is Retry.
        /// </summary>
        Retry,

        /// <summary>
        /// The dialog box return value is Yes.
        /// </summary>
        Yes,
    }
}
