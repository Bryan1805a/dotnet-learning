namespace BTC4;

using System.Drawing;
using System.Windows.Forms;

public static class InputDialog
{
    public static string Show(string prompt, string title, string default_text = "")
    {
        Form form_input = new Form();
        Label lbl_prompt = new Label();
        TextBox txt_input = new TextBox();
        Button btn_ok = new Button();
        Button btn_cancel = new Button();

        form_input.Text = title;
        lbl_prompt.Text = prompt;
        txt_input.Text = default_text;

        btn_ok.Text = "OK";
        btn_cancel.Text = "Hủy";
        btn_ok.DialogResult = DialogResult.OK;
        btn_cancel.DialogResult = DialogResult.Cancel;

        lbl_prompt.SetBounds(15, 15, 350, 20);
        txt_input.SetBounds(15, 40, 350, 25);
        btn_ok.SetBounds(175, 75, 90, 30);
        btn_cancel.SetBounds(275, 75, 90, 30);

        form_input.ClientSize = new Size(380, 115);
        form_input.Controls.AddRange(new Control[] { lbl_prompt, txt_input, btn_ok, btn_cancel });
        form_input.FormBorderStyle = FormBorderStyle.FixedDialog;
        form_input.StartPosition = FormStartPosition.CenterParent;
        form_input.AcceptButton = btn_ok;
        form_input.CancelButton = btn_cancel;
        form_input.MaximizeBox = false;
        form_input.MinimizeBox = false;

        DialogResult dialog_result = form_input.ShowDialog();
        return dialog_result == DialogResult.OK ? txt_input.Text.Trim() : "";
    }
}
