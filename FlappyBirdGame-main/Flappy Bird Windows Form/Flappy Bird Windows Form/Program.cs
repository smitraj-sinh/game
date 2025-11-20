using System;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ✅ Start from the login form, not the game directly
            Application.Run(new LoginForm());
        }
    }
}
