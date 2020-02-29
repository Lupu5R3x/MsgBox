## Yet another Custom message box clone.
This is created as close as possible to a std message box, only with the addition of a do not show again checkbox, the ability to change the color of the message text and form background, and to set the message box order (TopMost)

The usage is just as with the normal MessageBox.Show(all the normal parameters of message box + MsgBoxCheckBox / TextColor / FormBackColor / TopMost).

If using the Do not show again check box, one must add:
`Syste.Windows.Forms.CheckState doNotShowAgain = System.Windows.Forms.CheckState.Indeterminate;`
Before the MsgBox.Show() call.
And add: out doNotShowAgain after the MsgBoxCheckBox.Show/Checked state.

**Example:**
`Syste.Windows.Forms.CheckState doNotShowAgain = System.Windows.Forms.CheckState.Indeterminate;
MsgBoxResult result = MsgBox.Show("Message", "Caption", MsgBoxButtons.OKCancel, MsgBoxIcon.None, MsgBoxDefaultButton.Button2, MsgBoxCheckBox.Show, out doNotShowAgain, "#FF0000");`

This will show a Message Box with the text: Message Caption: Caption, an OK and Cancel button, no icon, Cancel button is selected as default (Button2), the Do not show again check box is shown, and the message text color is set to Red.

![](https://i.imgur.com/1BhiGZY.png)
