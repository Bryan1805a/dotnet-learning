namespace BTC4;

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

public partial class NotepadForm : Form
{
    private string current_file_path = "";

    public NotepadForm()
    {
        InitializeComponent();
    }

    private void menu_open_click(object? sender, EventArgs e)
    {
        try
        {
            open_file_dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            open_file_dialog.Title = "Chon tap tin TXT can mo";

            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                current_file_path = open_file_dialog.FileName;

                using (StreamReader source_file = new StreamReader(current_file_path, Encoding.UTF8))
                {
                    txt_content.Text = source_file.ReadToEnd();
                }

                this.Text = Path.GetFileName(current_file_path) + " - Notepad";
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
                save_file_dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                save_file_dialog.DefaultExt = "txt";
                save_file_dialog.Title = "Luu tap tin TXT";

                if (save_file_dialog.ShowDialog() == DialogResult.OK)
                {
                    current_file_path = save_file_dialog.FileName;
                }
                else
                {
                    return;
                }
            }

            using (StreamWriter target_file = new StreamWriter(current_file_path, false, Encoding.UTF8))
            {
                target_file.Write(txt_content.Text);
            }

            this.Text = Path.GetFileName(current_file_path) + " - Notepad";
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
