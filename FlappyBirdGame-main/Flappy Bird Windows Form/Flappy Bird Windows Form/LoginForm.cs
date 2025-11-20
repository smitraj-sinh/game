using System;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1️⃣ Check that both fields are filled
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Missing Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Check with database (DatabaseHelper handles connection)
            bool valid = DatabaseHelper.LoginUser(txtUser.Text, txtPass.Text);

            if (valid)
            {
                MessageBox.Show("✅ Login Successful!", "Welcome",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 3️⃣ Open the game and pass username
                Form1 game = new Form1(txtUser.Text);
                game.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("❌ Invalid username or password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // 1️⃣ Check fields
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Missing Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Try to create user
            bool created = DatabaseHelper.RegisterUser(txtUser.Text, txtPass.Text);

            if (created)
            {
                MessageBox.Show("✅ Registration Successful! You can now login.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("⚠️ Username already exists. Try another name.", "Duplicate",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
