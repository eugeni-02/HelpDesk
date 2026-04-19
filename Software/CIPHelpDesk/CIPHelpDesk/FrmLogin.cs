using CIPHelpDesk.Models;
using CIPHelpDesk.Repositories;
using DBLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIPHelpDesk
{
    public partial class FrmLogin : Form {
        public FrmLogin()
        {
            InitializeComponent();
        }

        public static User LoggedUser { get; set; }

        private void FrmLogin_Load(object sender, EventArgs e) {
            DB.SetConfiguration("IPS23_eivanisev21", "eivanisev21", "&)stsXi%");
        }
        /// <summary>
        /// Funkcija koja provjerava jesu li podaci za prijavu ispravni.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e) {
            if(txtUsername.Text == "") {
                MessageBox.Show("Niste unijeli korisničko ime", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == "") {
                MessageBox.Show("Niste unijeli lozinku", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                LoggedUser = UserRepository.GetUser(txtUsername.Text);
                if (LoggedUser != null && LoggedUser.CheckPassword(txtPassword.Text)) {
                    FrmTickets frmTickets = new FrmTickets();
                    Hide();
                    frmTickets.ShowDialog();
                    Close();
                }
                else {
                    MessageBox.Show("Krivi podaci", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
