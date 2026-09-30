namespace BTC4;

using System;
using System.IO;
using System.Windows.Forms;

public partial class WordPadForm : Form
{
    private string current_file_path = "";

    public WordPadForm()
    {
        InitializeComponent();
    }

    private void menu_open_click(object? sender, EventArgs e)
    {
        try
        {
            open_file_dialog.Filter = "Rich Text Format (*.rtf)|*.rtf|All Files (*.*)|*.*";
            open_file_dialog.Title = "Chon tap tin RTF can mo";

            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                current_file_path = open_file_dialog.FileName;
                rtf_content.LoadFile(current_file_path, RichTextBoxStreamType.RichText);

                this.Text = Path.GetFileName(current_file_path) + " - WordPad";
                MessageBox.Show("Mo tap tin thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Loi doc tap tin: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void menu_save_click(object? sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(current_file_path))
            {
                save_file_dialog.Filter = "Rich Text Format (*.rtf)|*.rtf|All Files (*.*)|*.*";
                save_file_dialog.DefaultExt = "rtf";
                save_file_dialog.Title = "Luu tap tin RTF";

                if (save_file_dialog.ShowDialog() == DialogResult.OK)
                {
                    current_file_path = save_file_dialog.FileName;
                }
                else
                {
                    return;
                }
            }

            rtf_content.SaveFile(current_file_path, RichTextBoxStreamType.RichText);

            this.Text = Path.GetFileName(current_file_path) + " - WordPad";
            MessageBox.Show("Luu tap tin thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Loi luu tap tin: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void menu_exit_click(object? sender, EventArgs e)
    {
        this.Close();
    }
}
