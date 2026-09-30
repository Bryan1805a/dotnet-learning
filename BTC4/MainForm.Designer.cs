namespace BTC4;

using System.Drawing;
using System.Windows.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private Label lbl_title;
    private Button btn_bai1;
    private Button btn_notepad;
    private Button btn_wordpad;
    private Button btn_explorer;
    private Button btn_exit;

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

        this.lbl_title = new Label();
        this.btn_bai1 = new Button();
        this.btn_notepad = new Button();
        this.btn_wordpad = new Button();
        this.btn_explorer = new Button();
        this.btn_exit = new Button();

        this.SuspendLayout();

        this.lbl_title.AutoSize = false;
        this.lbl_title.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        this.lbl_title.Location = new Point(20, 15);
        this.lbl_title.Name = "lbl_title";
        this.lbl_title.Size = new Size(380, 35);
        this.lbl_title.TabIndex = 0;
        this.lbl_title.Text = "BÀI TẬP CHƯƠNG 4";
        this.lbl_title.TextAlign = ContentAlignment.MiddleCenter;

        this.btn_bai1.Font = new Font("Segoe UI", 10F);
        this.btn_bai1.Location = new Point(60, 60);
        this.btn_bai1.Name = "btn_bai1";
        this.btn_bai1.Size = new Size(300, 38);
        this.btn_bai1.TabIndex = 1;
        this.btn_bai1.Text = "Bài 1: Lưu và mở bài thơ (RTF)";
        this.btn_bai1.UseVisualStyleBackColor = true;
        this.btn_bai1.Click += new System.EventHandler(this.btn_bai1_click);

        this.btn_notepad.Font = new Font("Segoe UI", 10F);
        this.btn_notepad.Location = new Point(60, 108);
        this.btn_notepad.Name = "btn_notepad";
        this.btn_notepad.Size = new Size(300, 38);
        this.btn_notepad.TabIndex = 2;
        this.btn_notepad.Text = "Bài nâng cao 1: Notepad (TXT)";
        this.btn_notepad.UseVisualStyleBackColor = true;
        this.btn_notepad.Click += new System.EventHandler(this.btn_notepad_click);

        this.btn_wordpad.Font = new Font("Segoe UI", 10F);
        this.btn_wordpad.Location = new Point(60, 156);
        this.btn_wordpad.Name = "btn_wordpad";
        this.btn_wordpad.Size = new Size(300, 38);
        this.btn_wordpad.TabIndex = 3;
        this.btn_wordpad.Text = "Bài nâng cao 2: WordPad (RTF)";
        this.btn_wordpad.UseVisualStyleBackColor = true;
        this.btn_wordpad.Click += new System.EventHandler(this.btn_wordpad_click);

        this.btn_explorer.Font = new Font("Segoe UI", 10F);
        this.btn_explorer.Location = new Point(60, 204);
        this.btn_explorer.Name = "btn_explorer";
        this.btn_explorer.Size = new Size(300, 38);
        this.btn_explorer.TabIndex = 4;
        this.btn_explorer.Text = "Bài nâng cao 3: Windows Explorer";
        this.btn_explorer.UseVisualStyleBackColor = true;
        this.btn_explorer.Click += new System.EventHandler(this.btn_explorer_click);

        this.btn_exit.Font = new Font("Segoe UI", 10F);
        this.btn_exit.Location = new Point(140, 258);
        this.btn_exit.Name = "btn_exit";
        this.btn_exit.Size = new Size(140, 34);
        this.btn_exit.TabIndex = 5;
        this.btn_exit.Text = "Thoát";
        this.btn_exit.UseVisualStyleBackColor = true;
        this.btn_exit.Click += new System.EventHandler(this.btn_exit_click);

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(420, 305);
        this.Controls.Add(this.lbl_title);
        this.Controls.Add(this.btn_bai1);
        this.Controls.Add(this.btn_notepad);
        this.Controls.Add(this.btn_wordpad);
        this.Controls.Add(this.btn_explorer);
        this.Controls.Add(this.btn_exit);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "MainForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Menu Bài Tập - Chương 4";
        this.ResumeLayout(false);
    }

    #endregion
}
