using System;
using System.Windows.Forms;
using System.Drawing;

namespace Flappy_Bird_Windows_Form
{
    public partial class MainMenuForm : Form
    {
        private string currentUser;
        private Timer fadeTimer; // For fade-in animation

        public MainMenuForm(string username)
        {
            InitializeComponent();
            currentUser = username;

            lblWelcome.Text = $"Welcome, {username}! 👋";
            this.Opacity = 0; // Start transparent for fade-in
        }

        // 🟢 FORM LOAD EVENT
        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            // Optional fade-in animation
            fadeTimer = new Timer();
            fadeTimer.Interval = 30;
            fadeTimer.Tick += FadeInEffect;
            fadeTimer.Start();
        }

        private void FadeInEffect(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.05;
            else
                fadeTimer.Stop();
        }

        // 🎮 START GAME BUTTON
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1(currentUser);
            gameForm.Show();
            this.Hide();
        }

        // 🏆 LEADERBOARD BUTTON
        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🏆 Leaderboard feature coming soon!", "Info");
        }

        // 🚪 EXIT BUTTON
        private void btnExit_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to exit?",
                                          "Exit Game",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
                Application.Exit();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            // Not used — kept safe
        }

        private void MainMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
