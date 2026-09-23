using System.Collections.Specialized;

namespace BTC2;

public partial class ListBoxForm : Form {
    private ListBox? lstLeft;
    private ListBox? lstRight;
    private Button? btnMoveRight;
    private Button? btnMoveAllRight;
    private Button? btnMoveLeft;
    private Button? btnMoveAllLeft;
    public ListBoxForm() {
        InitializeComponent();

        // Left listbox
        lstLeft = new ListBox();
        lstLeft.Location = new System.Drawing.Point(30, 30);
        lstLeft.Size = new System.Drawing.Size(160, 250);
        lstLeft.SelectionMode = SelectionMode.MultiExtended; // cho phép chọn nhiều bằng Ctrl/Shift
        lstLeft.Items.AddRange(new object[] { "Coc", "Oi", "Xoai", "Me", "Buoi", "Cam" });

        // Buttons in centre
        btnMoveRight = new Button();
        btnMoveRight.Text = ">";
        btnMoveRight.Location = new System.Drawing.Point(210, 60);
        btnMoveRight.Size = new System.Drawing.Size(60, 30);
        btnMoveRight.Click += BtnMoveRight_Click;
        btnMoveAllRight = new Button();
        btnMoveAllRight.Text = ">>";
        btnMoveAllRight.Location = new System.Drawing.Point(210, 100);
        btnMoveAllRight.Size = new System.Drawing.Size(60, 30);
        btnMoveAllRight.Click += BtnMoveAllRight_Click;

        btnMoveLeft = new Button();
        btnMoveLeft.Text = "<";
        btnMoveLeft.Location = new System.Drawing.Point(210, 150);
        btnMoveLeft.Size = new System.Drawing.Size(60, 30);
        btnMoveLeft.Click += BtnMoveLeft_Click;
        btnMoveAllLeft = new Button();
        btnMoveAllLeft.Text = "<<";
        btnMoveAllLeft.Location = new System.Drawing.Point(210, 190);
        btnMoveAllLeft.Size = new System.Drawing.Size(60, 30);
        btnMoveAllLeft.Click += BtnMoveAllLeft_Click;

        // --- ListBox phải ---
        lstRight = new ListBox();
        lstRight.Location = new System.Drawing.Point(300, 30);
        lstRight.Size = new System.Drawing.Size(160, 250);
        lstRight.SelectionMode = SelectionMode.MultiExtended;

        // Add Control
        Controls.Add(lstLeft);
        Controls.Add(btnMoveRight);
        Controls.Add(btnMoveAllRight);
        Controls.Add(btnMoveLeft);
        Controls.Add(btnMoveAllLeft);
        Controls.Add(lstRight);
    }

    private void MoveTheSelectedElement(ListBox startpoint, ListBox endpoint) {
        for (int i = startpoint.SelectedItems.Count - 1; i >= 0; i--) {
            object? item = startpoint.SelectedItems[i];
            if (item is not null) {
                endpoint.Items.Add(item);
                startpoint.Items.Remove(item);
            }
        }
    }

    // Move all elements from startpoint to endpoint
    private void MoveAll(ListBox startpoint, ListBox endpoint) {
        foreach (object? item in startpoint.Items) {
            if (item is not null) {    
                endpoint.Items.Add(item);
            }
        }
        startpoint.Items.Clear();
    }

    private void BtnMoveRight_Click(object? sender, EventArgs e) {
        if (lstLeft is not null && lstRight is not null) {
            MoveTheSelectedElement(lstLeft, lstRight);
        }
    }

    private void BtnMoveAllRight_Click(object? sender, EventArgs e) {
        if (lstLeft is not null && lstRight is not null) {
            MoveAll(lstLeft, lstRight);
        }
    }

    private void BtnMoveLeft_Click(object? sender, EventArgs e) {
        if (lstLeft is not null && lstRight is not null) {
            MoveTheSelectedElement(lstRight, lstLeft);
        }
    }

    private void BtnMoveAllLeft_Click(object? sender, EventArgs e) {
        if (lstLeft is not null && lstRight is not null) {
            MoveAll(lstRight, lstLeft);
        }
    }
}