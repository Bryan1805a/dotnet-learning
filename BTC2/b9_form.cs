using System.Collections.Specialized;

namespace BTC2;

public partial class b9_form : Form {
    private Label? lblEthnic;
    private ComboBox? cboEthnic;

    public b9_form() {
        InitializeComponent();
        this.Load += EthnicForm_Load;

        // Ethnic label
        lblEthnic = new Label();
        lblEthnic.Text = "Ethnic";
        lblEthnic.Location = new System.Drawing.Point(40, 50);
        lblEthnic.AutoSize = true;
        
        // Combo
        cboEthnic = new ComboBox();
        cboEthnic.Location = new System.Drawing.Point(140, 47);
        cboEthnic.Size = new System.Drawing.Size(200, 21);
        cboEthnic.DropDownStyle = ComboBoxStyle.DropDown;
        cboEthnic.SelectedIndexChanged += CboEthnic_SeletedIndexChanged;

        Controls.Add(lblEthnic);
        Controls.Add(cboEthnic);
    }

    private void EthnicForm_Load(object? sender, EventArgs e) {
        if (cboEthnic is not null) {    
            cboEthnic.Items.AddRange(new object[] {"Kinh", "Hoa", "K'Me", "H'Mong", "Other"});
            cboEthnic.SelectedIndex = 0;
        }
    }

    private void CboEthnic_SeletedIndexChanged(object? sender, EventArgs e) {
        if (cboEthnic is not null) {
            MessageBox.Show(
            text: "Seleted ethnic: " + (cboEthnic.SelectedItem?.ToString() ?? string.Empty),
            caption: "Notification"
            );
        }
        
    }
}