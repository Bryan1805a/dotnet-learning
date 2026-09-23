using System.Collections.Specialized;

namespace BTC2;

public partial class LoginForm : Form
{
    private Label? lblUser;
    private Label? lblPassword;
    private TextBox? txtUser;
    private TextBox? txtPassword;
    private Button? btnLogin;
    private Button? btnQuit;

    public LoginForm() {
        InitializeComponent();

        this.Text = "Login";
        this.Size = new System.Drawing.Size(420, 250);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        // Label user
        lblUser = new Label();
        lblUser.Text = "User";
        lblUser.Location = new System.Drawing.Point(40, 40);
        lblUser.AutoSize = true;

        // Textbox user
        txtUser = new TextBox();
        txtUser.Location = new System.Drawing.Point(140, 37);
        txtUser.Size = new System.Drawing.Size(220, 20);

        // Label password
        lblPassword = new Label();
        lblPassword.Text = "Password";
        lblPassword.Location = new System.Drawing.Point(40, 80);
        lblPassword.AutoSize = true;

        // Textbox Password
        txtPassword = new TextBox();
        txtPassword.Location = new System.Drawing.Point(140, 77);
        txtPassword.Size = new System.Drawing.Size(220, 20);
        txtPassword.PasswordChar = '*';
        // txtPassword.KeyDown += TxtPassword_KeyDown;

        // Login button
        btnLogin = new Button();
        btnLogin.Text = "Login";
        btnLogin.Location = new System.Drawing.Point(120, 140);
        btnLogin.Size = new System.Drawing.Size(100, 35);
        // btnLogin.Click += ;

        // Quit button
        btnQuit = new Button();
        btnQuit.Text = "Quit";
        btnQuit.Location = new System.Drawing.Point(230, 140);
        btnQuit.Size = new System.Drawing.Size(100, 35);
        // btnQuit.Click += ;

        // Add control
        this.Controls.Add(lblUser);
        this.Controls.Add(txtUser);
        this.Controls.Add(lblPassword);
        this.Controls.Add(txtPassword);
        this.Controls.Add(btnLogin);
        this.Controls.Add(btnQuit);
    }

    // Display User + Password when Login button clicked
    private void LoginProcessing() {
        MessageBox.Show(
            text: "User: " + txtUser?.Text + Environment.NewLine
                + "Password: " + txtPassword?.Text,
            caption: "Login information"
        );
    }


}
