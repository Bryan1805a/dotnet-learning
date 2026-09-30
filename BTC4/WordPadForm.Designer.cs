namespace BTC4;

using System.Drawing;
using System.Windows.Forms;

partial class WordPadForm
{
    private System.ComponentModel.IContainer components = null;

    private MenuStrip menu_strip;
    private ToolStripMenuItem menu_file;
    private ToolStripMenuItem menu_open;
    private ToolStripMenuItem menu_save;
    private ToolStripSeparator menu_separator;
    private ToolStripMenuItem menu_exit;

    private RichTextBox rtf_content;
    private OpenFileDialog open_file_dialog;
    private SaveFileDialog save_file_dialog;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.menu_strip = new MenuStrip();
        this.menu_file = new ToolStripMenuItem();
        this.menu_open = new ToolStripMenuItem();
        this.menu_save = new ToolStripMenuItem();
        this.menu_separator = new ToolStripSeparator();
        this.menu_exit = new ToolStripMenuItem();

        this.rtf_content = new RichTextBox();
        this.open_file_dialog = new OpenFileDialog();
        this.save_file_dialog = new SaveFileDialog();

        this.menu_strip.SuspendLayout();
        this.SuspendLayout();

        this.menu_strip.Items.AddRange(new ToolStripItem[] {
            this.menu_file
        });
        this.menu_strip.Location = new Point(0, 0);
        this.menu_strip.Name = "menu_strip";
        this.menu_strip.Size = new Size(800, 24);
        this.menu_strip.TabIndex = 0;
        this.menu_strip.Text = "menu_strip";

        this.menu_file.DropDownItems.AddRange(new ToolStripItem[] {
            this.menu_open,
            this.menu_save,
            this.menu_separator,
            this.menu_exit
        });
        this.menu_file.Name = "menu_file";
        this.menu_file.Text = "&File";

        this.menu_open.Name = "menu_open";
        this.menu_open.ShortcutKeys = Keys.Control | Keys.O;
        this.menu_open.Text = "&Open";
        this.menu_open.Click += new System.EventHandler(this.menu_open_click);

        this.menu_save.Name = "menu_save";
        this.menu_save.ShortcutKeys = Keys.Control | Keys.S;
        this.menu_save.Text = "&Save";
        this.menu_save.Click += new System.EventHandler(this.menu_save_click);

        this.menu_separator.Name = "menu_separator";
        this.menu_separator.Size = new Size(143, 6);

        this.menu_exit.Name = "menu_exit";
        this.menu_exit.Text = "E&xit";
        this.menu_exit.Click += new System.EventHandler(this.menu_exit_click);

        this.rtf_content.Dock = DockStyle.Fill;
        this.rtf_content.Font = new Font("Times New Roman", 12F, FontStyle.Regular);
        this.rtf_content.Location = new Point(0, 24);
        this.rtf_content.Name = "rtf_content";
        this.rtf_content.ScrollBars = RichTextBoxScrollBars.Both;
        this.rtf_content.Size = new Size(800, 426);
        this.rtf_content.TabIndex = 1;
        this.rtf_content.Text = "";

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.rtf_content);
        this.Controls.Add(this.menu_strip);
        this.MainMenuStrip = this.menu_strip;
        this.Name = "WordPadForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "WordPad - Mo va Luu tap tin RTF";

        this.menu_strip.ResumeLayout(false);
        this.menu_strip.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}
