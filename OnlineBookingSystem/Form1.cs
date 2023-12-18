using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBookingSystem
{
    public partial class LoginFrom : Form
    {
        public LoginFrom()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            SginUp signUpForm = new SginUp();
            this.Dispose();
            signUpForm.Show();
            
        }

        private void LoginFrom_Load(object sender, EventArgs e)
        {

        }
    }
}
