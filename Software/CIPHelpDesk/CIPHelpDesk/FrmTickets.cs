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
    public partial class FrmTickets : Form {
        public FrmTickets() {
            InitializeComponent();
        }

        private void FrmTickets_Load(object sender, EventArgs e) {
            ShowTickets();
        }
        /// <summary>
        /// Funkcija za osvježavanje zahtjeva.
        /// </summary>
        private void RefreshTickets() {
            List<Ticket> ticket = TicketRepository.GetTickets();
            dgvTickets.DataSource = ticket;
        }
        /// <summary>
        /// Funkcija koja prikazuje zahtjeve i formatira DataGridView.
        /// </summary>
        private void ShowTickets() {
            List<Ticket> ticket = TicketRepository.GetTickets();
            dgvTickets.DataSource = ticket;

            dgvTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach(DataGridViewColumn column in dgvTickets.Columns ) {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        /// <summary>
        /// Funkcija za odabiranje i prosljeđivanje zahtjeva kojeg korisnik želi obrisati.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite obrisati ovaj zahtjev?", "Obrisati zahtjev", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) {
                Ticket selectedTicket = dgvTickets.CurrentRow.DataBoundItem as Ticket;
                if (selectedTicket != null) {
                    TicketRepository.DeleteTicket(selectedTicket);
                    RefreshTickets();
                }
            }
        }

        private void btnNewTicket_Click(object sender, EventArgs e) {
            FrmCreateTicket frmCreateTicket = new FrmCreateTicket();
            frmCreateTicket.ShowDialog();
            RefreshTickets();
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            Ticket selectedTicket = dgvTickets.CurrentRow.DataBoundItem as Ticket;
            if (selectedTicket != null) {
                FrmEditTicket frmEditTicket = new FrmEditTicket();
                frmEditTicket.EditTicket(selectedTicket);
                frmEditTicket.ShowDialog();
                RefreshTickets();
            }
        }

        /// <summary>
        /// Funkcija za pozivanje funkcije koja pretražuje bazu po imenu osobe koja je preuzela zahtjev na obradu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e) {
            if (txtSearch.Text.Length == 0 || txtSearch.Text == "") {
                RefreshTickets();
            } else {
                string nameSearch = txtSearch.Text;
                List<Ticket> ticket = TicketRepository.SearchByName(nameSearch);
                dgvTickets.DataSource = ticket;
            }
        }

        private void btnRemoveSearch_Click(object sender, EventArgs e) {
            txtSearch.Text = "";
            ShowTickets();
        }
    }
}
