using System.Collections.Specialized;

namespace BTC2;

public partial class b15_form : Form {
    private Panel? pnlGreen, pnlYellow, pnlRed;
    private Button? btnStart, btnEnd;
    private Button? btnCar;

    private System.Windows.Forms.Timer? timer;
    private int passedMiniSeconds;
    private int carSpeed;

    public b15_form() {
        InitializeComponent();

        // Green light
        pnlGreen = new Panel();
        pnlGreen.Location = new Point(40, 40);
        pnlGreen.Size = new Size(60, 60);
        pnlGreen.BackColor = Color.LightGray;

        // Yello light
        pnlYellow = new Panel();
        pnlYellow.Location = new Point(40, 100);
        pnlYellow.Size = new Size(60, 60);
        pnlYellow.BackColor = Color.LightGray;

        // Red light
        pnlRed = new Panel();
        pnlRed.Location = new Point(40, 160);
        pnlRed.Size = new Size(60, 60);
        pnlRed.BackColor = Color.LightGray;

        // Startbutton for timer
        btnStart = new Button();
        btnStart.Text = "Start";
        btnStart.Location = new Point(200, 50);
        btnStart.Size = new Size(90, 30);
        btnStart.Click += BtnStart_Click;

        // End button for timer
        btnEnd = new Button();
        btnEnd.Text = "End";
        btnEnd.Location = new Point(300, 50);
        btnEnd.Size = new Size(90, 30);
        btnEnd.Click += BtnEnd_Click; // Reset everything

        // Car
        btnCar = new Button();
        btnCar.Text = "Car";
        btnCar.Location = new Point(40, 340);
        btnCar.Size = new Size(60, 30);

        // Timer
        timer = new System.Windows.Forms.Timer();
        timer.Interval = 50; // 50ms
        timer.Tick += Timer_Tick;

        // Control
        Controls.Add(pnlGreen);
        Controls.Add(pnlYellow);
        Controls.Add(pnlRed);
        Controls.Add(btnStart);
        Controls.Add(btnEnd);
        Controls.Add(btnCar);
    }

    private void LightUp(Panel lighting) {
        pnlGreen?.BackColor = (lighting == pnlGreen) ? Color.LimeGreen : Color.LightGray;
        pnlYellow?.BackColor = (lighting == pnlYellow) ? Color.Gold : Color.LightGray;
        pnlRed?.BackColor = (lighting == pnlRed) ? Color.Red : Color.LightGray;
    }

    private void AllLight() {
        pnlGreen?.BackColor = Color.LightGray;
        pnlYellow?.BackColor = Color.LightGray;
        pnlRed?.BackColor = Color.LightGray;
    }

    private void BtnStart_Click(object? sender, EventArgs e) {
        passedMiniSeconds = 0;
        if (btnCar is not null) {
            btnCar.Left = 40;
            timer?.Start();
        }
    }

    private void BtnEnd_Click(object? sender, EventArgs e) {
        timer?.Stop();
        AllLight();
        btnCar?.Left = 40;
    }

    private void Timer_Tick(object? sender, EventArgs e) {
        if (timer is not null) {
            passedMiniSeconds += timer.Interval;
        }

        double second = passedMiniSeconds / 1000.0;

        if (second < 5) {
            if (pnlGreen is not null) {
                LightUp(pnlGreen);
                carSpeed = 6; // Car moves 6 pixel/tick
            }
        }
        else if (second < 4) {
            if (pnlYellow is not null) {
                LightUp(pnlYellow);
                carSpeed = 2;
            }
        }
        else if (second < 3) {
            if (pnlRed is not null) {
                LightUp(pnlRed);
                carSpeed = 0;
            }
        }
        else {
            // Reset after 25 secs
            passedMiniSeconds = 0;
            btnCar?.Left = 40;
            return;
        }

        if (btnCar?.Left + btnCar?.Width + carSpeed < this.ClientSize.Width) {
            btnCar?.Left += carSpeed;
        }
    }
}