using CIPHelpDesk.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIPHelpDesk {
    public partial class FrmCreateTicket : Form {
        public FrmCreateTicket() {
            InitializeComponent();
        }

        private void FrmCreateTicket_Load(object sender, EventArgs e) {

        }
        /// <summary>
        /// Funkcija koja zatvara prozor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }
        /// <summary>
        /// Funkcija koja poziva funkciju stvaranja ticketa/zahtjeva.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e) {
            string description = txtDescription.Text;
            TicketRepository.CreateTicket(description);
            Close();
        }
    }
}
