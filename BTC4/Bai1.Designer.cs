namespace BTC4;

using System.Drawing;
using System.Windows.Forms;

partial class Bai1 {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private RichTextBox rtf_poem;
    private Panel pnl_bottom;
    private Button btn_open;
    private Button btn_save;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        this.components = new System.ComponentModel.Container();

        this.rtf_poem = new RichTextBox();
        this.pnl_bottom = new Panel();
        this.btn_open = new Button();
        this.btn_save = new Button();

        this.SuspendLayout();
        this.pnl_bottom.SuspendLayout();

        // Open file button
        this.btn_open.Text = "Open File";
        this.btn_open.Size = new Size(120, 35);
        this.btn_open.Location = new Point(170, 12);
        this.btn_open.Cursor = Cursors.Hand;
        this.btn_open.Click += new System.EventHandler(this.btn_open_click);

        // Save file button
        this.btn_save.Text = "Save File";
        this.btn_save.Size = new Size(120, 35);
        this.btn_save.Location = new Point(310, 12);
        this.btn_save.Cursor = Cursors.Hand;
        this.btn_save.Click += new System.EventHandler(this.btn_save_click);

        // Bottom panel storing 2 buttons
        this.pnl_bottom.Dock = DockStyle.Bottom;
        this.pnl_bottom.Height = 60;
        this.pnl_bottom.BackColor = SystemColors.ControlLight;
        this.pnl_bottom.Controls.Add(this.btn_open);
        this.pnl_bottom.Controls.Add(this.btn_save);

        // The poem input and display frame
        this.rtf_poem.Dock = DockStyle.Fill;
        this.rtf_poem.Font = new Font("Times New Roman", 12F, FontStyle.Regular);
        this.rtf_poem.ScrollBars = RichTextBoxScrollBars.Vertical;
        this.rtf_poem.AcceptsTab = true;

        // Creating window form
        components = new System.ComponentModel.Container();
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Text = "Luu, mo bai tho";

        // Add Controls
        this.Controls.Add(this.rtf_poem);
        this.Controls.Add(this.pnl_bottom);
        this.pnl_bottom.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion
}
