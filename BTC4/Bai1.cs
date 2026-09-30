namespace BTC4;

using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

public partial class Bai1 : Form {
    private string file_path = Path.Combine(Application.StartupPath, "assets", "bai_tho_ngau_nhien.rtf");

    public Bai1() {
        InitializeComponent();
    }

    // Open FIle button event handler
    private void btn_open_click(object? sender, EventArgs e) {
        try {
            if (!File.Exists(file_path)) {
                // Fallback: check if the original source file exists at repository assets folder
                string rootAssetPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\..\assets\bai_tho_ngau_nhien.rtf"));
                if (File.Exists(rootAssetPath)) {
                    file_path = rootAssetPath;
                }
                else {
                    MessageBox.Show("File " + file_path + " not exist.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Use StreamReader to read file path
            using (StreamReader source_file = new StreamReader(file_path, Encoding.UTF8)) {
                rtf_poem.Rtf = source_file.ReadToEnd();
                source_file.Close();
            }

            MessageBox.Show("Open poem successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) {
            MessageBox.Show("Failed to read file: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Save file button event handler
    private void btn_save_click(object? sender, EventArgs e) {
        try {
            using (StreamWriter target_file = new StreamWriter(file_path, false, Encoding.UTF8)) {
                target_file.Write(rtf_poem.Rtf);
                target_file.Close();
            }

            MessageBox.Show("Saved file " + file_path + " successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) {
            MessageBox.Show("Save error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
