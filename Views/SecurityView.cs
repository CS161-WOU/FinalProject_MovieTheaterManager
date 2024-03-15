using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS161_FinalProject_MovieTheaterManager.Views
{
    public partial class SecurityView : Form
    {
        public SecurityView()
        {
            InitializeComponent();
        }

        private void enter_Button_Click(object sender, EventArgs e)
        {
            string passcodeEntered = password_TextBox.Text;

            switch(passcodeEntered)
            {
                default:
                    {
                        BackColor = Color.Tomato;
                        MessageBox.Show("Inccorect Passcode entered.");
                        break;
                    }
                case "1989":
                    {
                        Form managerView = new ManagerView();
                        managerView.Show();

                        this.Close();
                        break;
                    }

                case "":
                    {
                        MessageBox.Show("Please enter a passcode.");
                        break;
                    }
            }
        }
    }
}
