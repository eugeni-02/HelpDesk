using CIPHelpDesk.Models;
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
    public partial class FrmEditTicket : Form {
        public FrmEditTicket() {
            InitializeComponent();
        }
        int id;

        private void frmEdit_Load(object sender, EventArgs e) {
            
        }
        /// <summary>
        /// Funkcija koja postavlja podatke zahtjeva kojeg treba urediti.
        /// </summary>
        /// <param name="ticket"></param>
        public void EditTicket(Ticket ticket) {
            txtDescription.Text = ticket.Description;
            id = ticket.ID;
        }
        /// <summary>
        /// Funkcija koja šalje ID ticketa i novi opis klasi TicketRepostory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendEdited_Click(object sender, EventArgs e) {
            string description = txtDescription.Text;
            TicketRepository.EditTicket(id,description);
            Close();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
