namespace MsgBoxEx
{
    using System.Windows.Forms;
    public static class MsgBox
    {
        /// <summary>
        /// Displays a message box with specified text..
        /// </summary>
        /// <param name="msg">
        /// The text to display in the message box.
        /// </param>
        /// <returns>
        /// MsgBoxResult OK</returns>
        public static MsgBoxResult Show(string msg)
        {
            return new MsgBoxForm(msg).Show();
        }
        /// <summary>
        /// Displays a message box with specified text and caption.
        /// </summary>
        /// <param name="message">
        /// The text to display in the message box.
        /// </param>
        /// <param name="caption">
        /// The text to display in the title bar of the message box.
        /// </param>
        /// <returns>
        /// MessageBoxResult OK
        /// </returns>
        public static MsgBoxResult Show(string message, string caption)
        {
            return new MsgBoxForm(message, caption).Show();
        }

        /// <summary>
        /// Displays a message box with specified text, caption and buttons.
        /// </summary>
        /// <param name="message">
        /// The text to display in the message box.
        /// </param>
        /// <param name="caption">
        /// The text to display in the title bar of the message box.
        /// </param>
        /// <param name="msgBoxButtons">
        /// One of the MsgBoxButtons values that specifies which
        /// buttons to display.
        /// </param>
        /// <returns>
        /// One of the MsgBoxResult values.
        /// </returns>
        public static MsgBoxResult Show(string message, string caption, MsgBoxButtons msgBoxButtons)
        {
            return new MsgBoxForm(message, caption, msgBoxButtons).Show();
        }
        /// <summary>
        /// Displays a message box with specified text, caption, buttons and Icon.
        /// </summary>
        /// <param name="message">
        /// The text to display in the message box.
        /// </param>
        /// <param name="caption">
        /// The text to display in the title bar of the message box.
        /// </param>
        /// <param name="msgBoxButtons">
        /// One of the MsgBoxButtons values that specifies which
        /// buttons to display.
        /// </param>
        /// <param name="icon">
        /// One of the MsgBoxIcon values that specifies which icon
        /// to display in the message box.
        /// </param>
        /// <returns>
        /// One of the MsgBoxResult values.
        /// </returns>
        public static MsgBoxResult Show(string message, string caption, MsgBoxButtons msgBoxButtons, MsgBoxIcon icon)
        {
            return new MsgBoxForm(message, caption, msgBoxButtons, icon).Show();
        }
        /// <summary>
        /// Displays a message box with specified text, caption, buttons, Icon and default button.
        /// </summary>
        /// <param name="message">
        /// The text to display in the message box.
        /// </param>
        /// <param name="caption">
        /// The text to display in the title bar of the message box.
        /// </param>
        /// <param name="msgBoxButtons">
        /// One of the MsgBoxButtons values that specifies which
        /// buttons to display.
        /// </param>
        /// <param name="icon">
        /// One of the MsgBoxIcon values that specifies which icon
        /// to display in the message box.
        /// <param name="defaultButton">
        ///  One of the MsgBoxDefaultButton values that specifies
        ///  the default button for the message box.
        /// </param>
        /// <returns>
        /// One of the MsgBoxResult values.
        /// </returns>
        public static MsgBoxResult Show(string message, string caption, MsgBoxButtons msgBoxButtons, MsgBoxIcon icon, MsgBoxDefaultButton defaultButton)
        {
            return new MsgBoxForm(message, caption, msgBoxButtons, icon, defaultButton).Show();
        }

        /// <summary>
        /// Displays a message box with specified text, caption, buttons, Icon, default button and a Do not show again Check box.
        /// To get the result of the check box, add: Syste.Windows.Forms.CheckState doNotShowAgain = System.Windows.Forms.CheckState.Indeterminate;
        /// Before the MsgBox call.
        /// </summary>
        /// <param name="message">
        /// The text to display in the message box.
        /// </param>
        /// <param name="caption">
        /// The text to display in the title bar of the message box.
        /// </param>
        /// <param name="msgBoxButtons">
        /// One of the MsgBoxButtons values that specifies which
        /// buttons to display.
        /// </param>
        /// <param name="icon">
        /// One of the MsgBoxIcon values that specifies which icon
        /// to display in the message box.
        /// <param name="defaultButton">
        ///  One of the MsgBoxDefaultButton values that specifies
        ///  the default button for the message box.
        /// </param>
        /// <param name="doNotShowAgain">
        /// Show (checked) or hide the Do not show again check box.
        /// </param>
        /// <param name="checkBoxState">
        /// The checked state of the Do not show again check box.
        /// </param>
        /// <returns>
        /// One of the MsgBoxResult values.
        /// The state of the Do not show again check box.
        /// </returns>
        public static MsgBoxResult Show(string message, string caption, MsgBoxButtons msgBoxButtons, MsgBoxIcon icon, MsgBoxDefaultButton defaultButton,
            MsgBoxCheckBox doNotShowAgain, out CheckState checkBoxState)
        {
            return new MsgBoxForm(message, caption, msgBoxButtons, icon, defaultButton, doNotShowAgain).Show(out checkBoxState);
        }

        /// <summary>
        /// Displays a message box with specified text, caption, buttons, Icon, default button, a Do not show again Check box,
        /// custom Text color using a hexadecimal color (web color code #0000FF = Blue text).
        /// To get the result of the check box, add: Syste.Windows.Forms.CheckState doNotShowAgain = System.Windows.Forms.CheckState.Indeterminate;
        /// Before the MsgBox call.
        /// </summary>
        /// <param name="message">
        /// The text to display in the message box.
        /// </param>
        /// <param name="caption">
        /// The text to display in the title bar of the message box.
        /// </param>
        /// <param name="msgBoxButtons">
        /// One of the MsgBoxButtons values that specifies which
        /// buttons to display.
        /// </param>
        /// <param name="icon">
        /// One of the MsgBoxIcon values that specifies which icon
        /// to display in the message box.
        /// <param name="defaultButton">
        ///  One of the MsgBoxDefaultButton values that specifies
        ///  the default button for the message box.
        /// </param>
        /// <param name="doNotShowAgain">
        /// Show (checked) or hide the Do not show again check box.
        /// </param>
        /// <param name="checkBoxState">
        /// The checked state of the Do not show again check box.
        /// </param>
        /// <param name="textColor">
        /// A hexadecimal color code (web color code #FF0000 = Red)
        /// </param>
        /// <returns>
        /// One of the MsgBoxResult values.
        /// The state of the Do not show again check box.
        /// </returns>
        public static MsgBoxResult Show(string message, string caption, MsgBoxButtons msgBoxButtons, MsgBoxIcon icon, MsgBoxDefaultButton defaultButton,
            MsgBoxCheckBox doNotShowAgain, out CheckState checkBoxState, string textColor)
        {
            return new MsgBoxForm(message, caption, msgBoxButtons, icon, defaultButton, doNotShowAgain, textColor).Show(out checkBoxState);
        }

        /// <summary>
        /// Displays a message box with specified text, caption, buttons, Icon, default button, a Do not show again Check box,
        /// custom Text color using a hexadecimal color (web color code #0000FF = Blue text) and custom form background color
        /// using a hexadecimal color (web color code #C0C0C0 = Silver background) (The button bar is automatic set to a darker color than the form background.).
        /// To get the result of the check box, add: Syste.Windows.Forms.CheckState doNotShowAgain = System.Windows.Forms.CheckState.Indeterminate;
        /// Before the MsgBox call.
        /// </summary>
        /// <param name="message">
        /// The text to display in the message box.
        /// </param>
        /// <param name="caption">
        /// The text to display in the title bar of the message box.
        /// </param>
        /// <param name="msgBoxButtons">
        /// One of the MsgBoxButtons values that specifies which
        /// buttons to display.
        /// </param>
        /// <param name="icon">
        /// One of the MsgBoxIcon values that specifies which icon
        /// to display in the message box.
        /// <param name="defaultButton">
        ///  One of the MsgBoxDefaultButton values that specifies
        ///  the default button for the message box.
        /// </param>
        /// <param name="doNotShowAgain">
        /// Show (checked) or hide the Do not show again check box.
        /// </param>
        /// <param name="checkBoxState">
        /// The checked state of the Do not show again check box.
        /// </param>
        /// <param name="textColor">
        /// A hexadecimal color code (web color code #FF0000 = Red)
        /// </param>
        /// <param name="formColor">
        /// A hexadecimal color code (web color code #FFFFFF = White)
        /// </param>
        /// <returns>
        /// One of the MsgBoxResult values.
        /// The state of the Do not show again check box.
        /// </returns>
        public static MsgBoxResult Show(string message, string caption, MsgBoxButtons msgBoxButtons, MsgBoxIcon icon, MsgBoxDefaultButton defaultButton,
            MsgBoxCheckBox doNotShowAgain, out CheckState checkBoxState, string textColor, string formColor)
        {
            return new MsgBoxForm(message, caption, msgBoxButtons, icon, defaultButton, doNotShowAgain, textColor, formColor).Show(out checkBoxState);
        }

        /// <summary>
        /// Displays a message box with specified text, caption, buttons, Icon, default button, a Do not show again Check box,
        /// custom Text color using a hexadecimal color (web color code #0000FF = Blue text), custom form background color
        /// using a hexadecimal color (web color code #C0C0C0 = Silver background) (The button bar is automatic set to a darker color than the form background.)
        /// and MsgBox order (TopMost).
        /// To get the result of the check box, add: Syste.Windows.Forms.CheckState doNotShowAgain = System.Windows.Forms.CheckState.Indeterminate;
        /// Before the MsgBox call.
        /// </summary>
        /// <param name="message">
        /// The text to display in the message box.
        /// </param>
        /// <param name="caption">
        /// The text to display in the title bar of the message box.
        /// </param>
        /// <param name="msgBoxButtons">
        /// One of the MsgBoxButtons values that specifies which
        /// buttons to display.
        /// </param>
        /// <param name="icon">
        /// One of the MsgBoxIcon values that specifies which icon
        /// to display in the message box.
        /// <param name="defaultButton">
        ///  One of the MsgBoxDefaultButton values that specifies
        ///  the default button for the message box.
        /// </param>
        /// <param name="doNotShowAgain">
        /// Show (checked) or hide the Do not show again check box.
        /// </param>
        /// <param name="checkBoxState">
        /// The checked state of the Do not show again check box.
        /// </param>
        /// <param name="textColor">
        /// A hexadecimal color code (web color code #FF0000 = Red)
        /// </param>
        /// <param name="formColor">
        /// A hexadecimal color code (web color code #FFFFFF = White)
        /// </param>
        /// <param name="topMost">
        /// State of the message box Z index (TopMost)
        /// </param>
        /// <returns>
        /// One of the MsgBoxResult values.
        /// The state of the Do not show again check box.
        /// </returns>
        public static MsgBoxResult Show(string message, string caption, MsgBoxButtons msgBoxButtons, MsgBoxIcon icon, MsgBoxDefaultButton defaultButton,
            MsgBoxCheckBox doNotShowAgain, out CheckState checkBoxState, string textColor, string formColor, MsgBoxOrder topMost)
        {
            return new MsgBoxForm(message, caption, msgBoxButtons, icon, defaultButton, doNotShowAgain, textColor, formColor, topMost).Show(out checkBoxState);
        }
    }
}
