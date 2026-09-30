namespace BTC4;

using System;
using System.Windows.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void btn_bai1_click(object? sender, EventArgs e)
    {
        Bai1 form_bai1 = new Bai1();
        form_bai1.ShowDialog();
    }

    private void btn_notepad_click(object? sender, EventArgs e)
    {
        NotepadForm form_notepad = new NotepadForm();
        form_notepad.ShowDialog();
    }

    private void btn_wordpad_click(object? sender, EventArgs e)
    {
        WordPadForm form_wordpad = new WordPadForm();
        form_wordpad.ShowDialog();
    }

    private void btn_explorer_click(object? sender, EventArgs e)
    {
        ExplorerForm form_explorer = new ExplorerForm();
        form_explorer.ShowDialog();
    }

    private void btn_exit_click(object? sender, EventArgs e)
    {
        this.Close();
    }
}
