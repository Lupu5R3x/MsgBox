
namespace MsgBox
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public partial class MsgBoxForm : Form
    {

        // Private get set's
        private MsgBoxButtons Buttons { get; set; } = MsgBoxButtons.OK;
        private MsgBoxIcon IconStyle { get; set; } = MsgBoxIcon.None;
        private MsgBoxResult Result { get; set; } = MsgBoxResult.None;
        private MsgBoxCheckBox CheckBox { get; set; } = MsgBoxCheckBox.Hide;
        private MsgBoxDefaultButton DefaultButton { get; set; } = MsgBoxDefaultButton.Button1;
        private MsgBoxOrder SetTopMost { get; set; } = MsgBoxOrder.Default;
        private string TextColor { get; set; } = null;
        private string FormColor { get; set; } = null;


        internal MsgBoxForm(string message)
        {
            // Custom MsgBox form start.          
            InitializeComponent();
            // We use KeyPreview to disable Alt + F4, if AbortIgnorRetry or YesNo buttons is used.
            KeyPreview = true;
            // Set the message.
            lblMessage.Text = message;
            // Sets the MsgBox font to default Message box font.
            lblMessage.Font = SystemFonts.MessageBoxFont;
            // Sets the MsgBox Caption font to default Caption font.
            Font = SystemFonts.CaptionFont;
        }

        internal MsgBoxForm(string message, string caption) : this(message)
        {
            // Set the caption of the message box.
            Text = caption;
        }
        internal MsgBoxForm(string message, string caption, MsgBoxButtons msgBoxButtons) : this(message, caption)
        {
            // Set buttons;
            Buttons = msgBoxButtons;
        }

        internal MsgBoxForm(string message, string caption, MsgBoxButtons msgBoxButtons, MsgBoxIcon icon) : this(message, caption, msgBoxButtons)
        {
            // Set the icon style.
            IconStyle = icon;
        }

        internal MsgBoxForm(string message, string caption, MsgBoxButtons msgBoxButtons, MsgBoxIcon icon, MsgBoxDefaultButton defaultButton) :
            this(message, caption, msgBoxButtons, icon)
        {
            // Set default button
            DefaultButton = defaultButton;
        }

        internal MsgBoxForm(string message, string caption, MsgBoxButtons msgBoxButtons, MsgBoxIcon icon,
            MsgBoxDefaultButton defaultButton, MsgBoxCheckBox checkBox) : this(message, caption, msgBoxButtons, icon, defaultButton)
        {
            // Set the check box
            CheckBox = checkBox;
        }

        internal MsgBoxForm(string message, string caption, MsgBoxButtons msgBoxButtons, MsgBoxIcon icon, MsgBoxDefaultButton defaultButton,
            MsgBoxCheckBox checkBox, string textColor) : this(message, caption, msgBoxButtons, icon, defaultButton, checkBox)
        {
            // Set the color of the Message text.
            TextColor = textColor;
        }
        internal MsgBoxForm(string message, string caption, MsgBoxButtons msgBoxButtons, MsgBoxIcon icon, MsgBoxDefaultButton defaultButton,
            MsgBoxCheckBox checkBox, string textColor, string formBackGroundColor) :
            this(message, caption, msgBoxButtons, icon, defaultButton, checkBox, textColor)
        {
            // Set the color of the form background.
            FormColor = formBackGroundColor;
        }

        internal MsgBoxForm(string message, string caption, MsgBoxButtons msgBoxButtons, MsgBoxIcon icon, MsgBoxDefaultButton defaultButton,
            MsgBoxCheckBox checkBox, string textColor, string formBackGroundColor, MsgBoxOrder topmost) :
            this(message, caption, msgBoxButtons, icon, defaultButton, checkBox, textColor, formBackGroundColor)
        {
            // Set the Z index of the form.
            SetTopMost = topmost;
        }

        /// <summary>
        /// MsgBoxResults.
        /// </summary>
        /// <returns>
        /// the result of MsgBoxResult.
        /// </returns>
        internal new MsgBoxResult Show()
        {
            SetIcons();
            SetButtons();
            SetSize();
            SetButtonLocation();
            SetDefaultButton();
            SetOrder();
            PlaySound();
            SetCheckBox();
            SetColor();
            ShowDialog();
            return Result;
        }

        /// <summary>
        /// Used to set the state of the Do not show again check box.
        /// </summary>
        /// <param name="state">
        /// The state of the Do not show again check box.
        /// </param>
        /// <returns>
        /// Checked or unchecked.
        /// </returns>
        internal MsgBoxResult Show(out CheckState state)
        {
            Result = Show();
            state = chkDoNotShowAgain.CheckState;
            return Result;
        }

        private void SetSize()
        {

            int captionWidth = Convert.ToInt32(TextRenderer.MeasureText(Text, SystemFonts.CaptionFont).Width);
            int txtWidth = Convert.ToInt32(TextRenderer.MeasureText(lblMessage.Text, Control.DefaultFont).Width);
            int formMinWidth = 133; // Form min width when only text.
            int txtMaxWidth = 372; // Default text length when no icon.
            int lblMsgTop = 23; // Default top position, when no icon.
            int lblMsgLeft = 11;
            int iconWidth = 0; // Default when no icon.
            int formHeight = lblMessage.Height + pnlButtons.Height + pnlMain.Height; // Height of the form.
            int formMaxHeight = 500;
            int paddingButtom = 10;
            int paddingRight = 50;

            // Check if we have an icon.
            if (IconStyle != MsgBoxIcon.None)
            {
                txtMaxWidth = 323;
                lblMsgTop = 33;
                lblMsgLeft = 5;
                iconWidth = pnlIcon.Width;
                paddingButtom = 0;
            }

            // Get buttons, and set formMinWidth accordingly.
            switch (Buttons)
            {
                case MsgBoxButtons.OK:
                    formMinWidth = 133;
                    break;
                case MsgBoxButtons.OKCancel:
                case MsgBoxButtons.YesNo:
                case MsgBoxButtons.RetryCancel:
                    formMinWidth = 216;
                    break;
                case MsgBoxButtons.AbortRetryIgnore:
                case MsgBoxButtons.YesNoCancel:
                    formMinWidth = 300;
                    break;
            }

            // Check if the Do not show again check box is shown.
            if (CheckBox == MsgBoxCheckBox.Show)
            {
                pnlButtons.Height += 15;
                formMinWidth = Math.Max(chkDoNotShowAgain.Width + 31, formMinWidth);
            }

            // Check if we need to add scrollbar to the main panel.
            if (formHeight > formMaxHeight)
            {
                // We need to add scrollbar to the main panel.
                pnlMain.HorizontalScroll.Maximum = 0;
                pnlMain.VerticalScroll.Visible = true;
                pnlMain.AutoScroll = true;
                pnlMain.AutoScrollMargin = new Size(0, 10);
            }

            // Get the max width for the label.
            int lblWidth = Math.Min(txtWidth + (paddingRight + iconWidth), txtMaxWidth);

            // Set the size of the MsgBox, and the message label.
            lblMessage.MaximumSize = new Size(lblWidth, lblMessage.Height);
            lblMessage.Top = lblMsgTop;
            lblMessage.Left = lblMsgLeft;
            Width = Math.Min(Math.Max(Math.Max(txtWidth + (paddingRight + iconWidth), formMinWidth), captionWidth + 55), 426);
            Height = Math.Min(formHeight, formMaxHeight) - paddingButtom;

        }

        #region PlaySound
        private void PlaySound()
        {
            // Play a sound according to the icon style.
            System.Media.SystemSound sound;

            switch (IconStyle)
            {
                case MsgBoxIcon.None:
                    sound = null;
                    break;
                case MsgBoxIcon.Error:
                    sound = System.Media.SystemSounds.Hand;
                    break;
                case MsgBoxIcon.Question:
                    sound = System.Media.SystemSounds.Question;
                    break;
                case MsgBoxIcon.Warning:
                    sound = System.Media.SystemSounds.Exclamation;
                    break;
                case MsgBoxIcon.Information:
                    sound = System.Media.SystemSounds.Asterisk;
                    break;
                default:
                    sound = System.Media.SystemSounds.Beep;
                    break;
            }

            // Check if we should play the sound.
            if (sound != null)
            {
                sound.Play();
            }
        }
        #endregion

        #region SetIcon
        private void SetIcons()
        {

            switch (IconStyle)
            {
                case MsgBoxIcon.None:
                    pnlIcon.Hide(); // Hide the whole icon panel so the text moves left with the docking, when there is no icon.
                    break;
                case MsgBoxIcon.Error:
                    picIcon.Image = SystemIcons.Error.ToBitmap();
                    break;
                case MsgBoxIcon.Information:
                    picIcon.Image = SystemIcons.Information.ToBitmap();
                    break;
                case MsgBoxIcon.Question:
                    picIcon.Image = SystemIcons.Question.ToBitmap();
                    break;
                case MsgBoxIcon.Warning:
                    picIcon.Image = SystemIcons.Warning.ToBitmap();
                    break;
            }
            // Call the playSound method.
            PlaySound();
        }
        #endregion

        private void SetColor()
        {
            if (TextColor != null && System.Text.RegularExpressions.Regex.IsMatch(TextColor, @"#[A-F,a-f,0-9]{6}"))
            {
                Color txtColor = ColorTranslator.FromHtml(TextColor.ToString());
                lblMessage.ForeColor = txtColor;

                // We only aply the color to the button and check box if the background color also is set.
                if (FormColor != null)
                {
                    foreach (Control ctrl in pnlButtons.Controls)
                    {
                        if (ctrl == chkDoNotShowAgain)
                        {
                            (ctrl as CheckBox).ForeColor = txtColor;
                        }
                        else
                        {
                            (ctrl as Button).ForeColor = txtColor;
                        }

                    }
                }
            }

            if (FormColor != null && System.Text.RegularExpressions.Regex.IsMatch(FormColor, @"#[A-F,a-f,0-9]{6}"))
            {
                Color backColor = ColorTranslator.FromHtml(FormColor.ToString());
                pnlMain.BackColor = backColor;
                pnlIcon.BackColor = backColor;
                pnlButtons.BackColor = ControlPaint.Dark(backColor, 3);


                foreach (Control ctrl in pnlButtons.Controls)
                {
                    if (ctrl != chkDoNotShowAgain)
                    {
                        (ctrl as Button).BackColor = ControlPaint.Dark(backColor, 3);
                    }

                }
            }
        }
        /// <summary>
        /// Set the order of the form.
        /// </summary>
        private void SetOrder()
        {
            switch (SetTopMost)
            {
                case MsgBoxOrder.Default:
                    break;
                case MsgBoxOrder.TopMost:
                    TopMost = true;
                    break;
            }
        }
        /// <summary>
        /// Set the Do not show again check box state.
        /// </summary>
        private void SetCheckBox()
        {
            if (CheckBox == MsgBoxCheckBox.Show || CheckBox == MsgBoxCheckBox.Checked)
            {
                chkDoNotShowAgain.Visible = true;
                if (CheckBox == MsgBoxCheckBox.Checked)
                {
                    chkDoNotShowAgain.Checked = true;
                }
            }
        }

        #region Buttons

        /// <summary>
        /// Sets the buttons, order of addition is respected.
        /// </summary>
        private void SetButtons()
        {
            // Abort button
            if (Buttons == MsgBoxButtons.AbortRetryIgnore)
            {
                AddButton("Abort", "Abort");
            }

            // Ok
            if (Buttons == MsgBoxButtons.OK || Buttons == MsgBoxButtons.OKCancel)
            {
                AddButton("OK", "OK");
            }

            // Yes
            if (Buttons == MsgBoxButtons.YesNo || Buttons == MsgBoxButtons.YesNoCancel)
            {
                AddButton("Yes", "Yes");
            }

            // Retry
            if (Buttons == MsgBoxButtons.AbortRetryIgnore || Buttons == MsgBoxButtons.RetryCancel)
            {
                AddButton("Retry", "Retry");
            }

            // No
            if (Buttons == MsgBoxButtons.YesNo || Buttons == MsgBoxButtons.YesNoCancel)
            {
                AddButton("No", "No");
            }

            // Cancel
            if (Buttons == MsgBoxButtons.OKCancel || Buttons == MsgBoxButtons.RetryCancel || Buttons == MsgBoxButtons.YesNoCancel)
            {
                AddButton("Cancel", "Cancel");
            }

            // Ignore
            if (Buttons == MsgBoxButtons.AbortRetryIgnore)
            {
                AddButton("Ignore", "Ignore");
            }

            // Check if the buttons is either AbortRetryIgnore or YesNo
            if (Buttons == MsgBoxButtons.AbortRetryIgnore || Buttons == MsgBoxButtons.YesNo)
            {
                // If so, we disable the [x] close button, also in the Form key press event we disable the use of Alt + F4, just like in a normal MessageBox.
                CloseButton.Enable(this, false);
            }
            SetButtonsSize();
        }

        /// <summary>
        /// Sets the button(s) size and Top position.
        /// </summary>
        private void SetButtonsSize()
        {
            foreach (Control ctrl in pnlButtons.Controls)
            {
                if (ctrl != chkDoNotShowAgain)
                {
                    ctrl.Size = new Size(75, 23);
                    ctrl.Top = pnlButtons.Height - 31;
                }
            }
        }
        /// <summary>
        /// Sets the location of the button(s).
        /// </summary>
        private void SetButtonLocation()
        {
            // Set location of the first button, x location is button width + margin right (75 + 31), and the height of the panel - the button height + 8 (23 + 8)
            Point lastBtnLocation = new Point(Width - 106, pnlButtons.Height - 31);

            // Placing the buttons in reverse order, by adding the last button first.
            for (int i = pnlButtons.Controls.Count - 1; i >= 0; i--)
            {
                // Check that the control isn't the check box.
                if (pnlButtons.Controls[i] != chkDoNotShowAgain)
                {
                    pnlButtons.Controls[i].Location = lastBtnLocation;
                    lastBtnLocation.X -= (85);
                }
            }
        }
        /// <summary>
        /// Adds button(s) to the form.
        /// </summary>
        /// <param name="name">
        /// The name of the button.
        /// </param>
        /// <param name="text">
        /// The caption of the button.
        /// </param>
        private void AddButton(string name, string text)
        {
            Control btnToAdd;

            btnToAdd = new Button();
            (btnToAdd as Button).Click += btnButton_Click;
            (btnToAdd as Button).Anchor = AnchorStyles.Top | AnchorStyles.Right;
            (btnToAdd as Button).Font = SystemFonts.MessageBoxFont;
            btnToAdd.Name = name;
            btnToAdd.Text = text;
            pnlButtons.Controls.Add(btnToAdd);
        }
        /// <summary>
        /// Sets the default button focus.
        /// </summary>
        private void SetDefaultButton()
        {
            switch (DefaultButton)
            {
                case var btn when btn == MsgBoxDefaultButton.Button1 && pnlButtons.Controls.Count > 1:
                    pnlButtons.Controls[1].Select();
                    break;
                case var btn when btn == MsgBoxDefaultButton.Button2 && pnlButtons.Controls.Count > 2:
                    pnlButtons.Controls[2].Select();
                    break;
                case var btn when btn == MsgBoxDefaultButton.Button3 && pnlButtons.Controls.Count > 3:
                    pnlButtons.Controls[3].Select();
                    break;
                default:
                    // Set first button as default.
                    pnlButtons.Controls[1].Select();
                    break;
            }
        }

        private void HandleButton(Control sender)
        {
            Control senderControl = sender;
            switch (senderControl.Name)
            {
                case "Abort":
                    Result = MsgBoxResult.Abort;
                    break;
                case "OK":
                    Result = MsgBoxResult.OK;
                    break;
                case "Yes":
                    Result = MsgBoxResult.Yes;
                    break;
                case "Retry":
                    Result = MsgBoxResult.Retry;
                    break;
                case "No":
                    Result = MsgBoxResult.No;
                    break;
                case "Cancel":
                    Result = MsgBoxResult.Cancel;
                    break;
                case "Ignore":
                    Result = MsgBoxResult.Ignore;
                    break;
                default:
                    Result = MsgBoxResult.None;
                    break;
            }

            DialogResult = DialogResult.OK;
        }

        #endregion

        #region Events
        /// <summary>
        /// Handles the button click events.
        /// </summary>

        private void btnButton_Click(object sender, EventArgs e)
        {
            if (sender is Control)
            {
                HandleButton((Control)sender);
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the MsgBox Form.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The Key pressed.
        /// </param>
        private void MsgBoxForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // Check if the buttons is not Abort,Retry,Ignore or Yes,No
                if (Buttons != MsgBoxButtons.AbortRetryIgnore || Buttons != MsgBoxButtons.YesNo)
                {
                    Result = MsgBoxResult.None;
                    Close();
                }
                else if (Buttons == MsgBoxButtons.OK)
                {
                    Result = MsgBoxResult.OK;
                    Close();
                }
                else
                {
                    // If AbortRetryIgnore or YesNo, we returns.
                    return;
                }
            }
            // If AbortRetryIgnore or YesNo we also disables the Alt + F4 closing of the form.
            if (e.Alt && e.KeyCode == Keys.F4 && Buttons == MsgBoxButtons.AbortRetryIgnore || Buttons == MsgBoxButtons.YesNo)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Handles the form close event.
        /// </summary>
        private void MsgBoxForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Result == MsgBoxResult.None)
            {
                // If the user clicked the close button [X]
                Result = MsgBoxResult.Cancel;
            }
        }
        #endregion
    }

    /// <summary>
    /// Enables or disables the [x] close button on the form.
    /// Code snippet found here:
    /// https://social.msdn.microsoft.com/Forums/en-US/df89dfd8-ece2-4358-be38-65843e993e3c/enable-and-disable-close-button-x-using-c?forum=winforms
    /// </summary>
    internal class CloseButton
    {
        private const int SC_CLOSE = 0xF060;
        private const int MF_GRAYED = 0x1;

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);

        public static void Enable(Form form, bool isEnable)
        {
            EnableMenuItem(GetSystemMenu(form.Handle, isEnable), SC_CLOSE, MF_GRAYED);
        }

    }
}
