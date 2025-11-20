using System;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        private string currentUser;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // 🟢 ensures form always receives keyboard input
        }

        public Form1(string username)
        {
            InitializeComponent();
            currentUser = username;
            this.KeyPreview = true;
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }

            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -25)
            {
                endGame();
            }

            if (score > 5)
            {
                pipeSpeed = 15;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += "   Game Over!";
            btnRestart.Visible = true;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void RestartGame()
        {
            gravity = 15;
            score = 0;
            pipeSpeed = 8;

            // Reset bird and pipes
            flappyBird.Top = 281;
            flappyBird.Left = 92;
            pipeTop.Left = 660;
            pipeTop.Top = -73;
            pipeBottom.Left = 483;
            pipeBottom.Top = 514;

            // Reset text and UI
            scoreText.Text = "Score: 0";
            btnRestart.Visible = false;

            // Restart the game
            gameTimer.Start();

            // 🟢 FIX: force keyboard focus back to the form
            this.ActiveControl = null;
            this.Focus();
            this.Select();
        }
    }
}
