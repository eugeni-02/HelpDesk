using CIPHelpDesk.Models;
using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPHelpDesk.Repositories {
    public class TicketRepository {

        /// <summary>
        /// Funkcija koja hvata sve zahtjeve/tickete iz baze podataka.
        /// </summary>
        /// <returns>Listu zahtjeva/ticketa</returns>
        public static List<Ticket> GetTickets() {
            List<Ticket> tickets = new List<Ticket>();
            string sql = "SELECT * FROM Zahtjevi";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read()) {
                Ticket ticket = CreateObject(reader);
                tickets.Add(ticket);
            }
            reader.Close();
            DB.CloseConnection();
            return tickets;
        }

        /// <summary>
        /// Funkcija koja kreira objekt tipa Ticket iz podataka koje je SqlDataReader pročitao.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Objekt tipa Ticket</returns>
        private static Ticket CreateObject(SqlDataReader reader) {
            int id = int.Parse(reader["ID_Zahtjeva"].ToString());
            string date = reader["Datum"].ToString();
            string time = reader["Vrijeme"].ToString();
            string description = reader["Opis"].ToString();
            string name = reader["Ime"].ToString();
            string lastname = reader["Prezime"].ToString();
            string comment = reader["Komentari"].ToString();
            string priority = reader["Prioritet"].ToString();
            string status = reader["Status"].ToString();
            var ticket = new Ticket {
                ID = id,
                Date = date,
                Time = time,
                Description = description,
                Name = name,
                Lastname = lastname,
                Comments = comment,
                Priority = priority,
                Status = status
            };
            return ticket;
        }
        /// <summary>
        /// Funkcija koja briše red (n-torku) iz baze podataka na temelju ID-a prosljeđenog objekta.
        /// </summary>
        /// <param name="ticket"></param>
        public static void DeleteTicket(Ticket ticket) {
            int id = ticket.ID;
            string sql = "DELETE FROM Zahtjevi WHERE ID_Zahtjeva="+id;
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        /// <summary>
        /// Funkcija koja stvara novi zahtjev (ticket) i sprema ga u bazu podataka. Funkcija sama dohvaća sistemsko vrijeme i datum.
        /// </summary>
        /// <param name="description"></param>
        public static void CreateTicket(string description) {
            string date = DateTime.Now.ToString("MM/dd/yyyy");
            string time = DateTime.Now.ToString("HH:mm");
            string sql = "INSERT INTO Zahtjevi (Datum, Vrijeme, Opis, Status, ID_Korisnika) VALUES ('" + date + "','" + time + "','" + description + "','Zaprimljen', 1);";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
        /// <summary>
        /// Funkcija koja mijenja opis zahtjeva u bazi podataka na temelju prosljeđenog ID-a i opisa.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="description"></param>
        public static void EditTicket(int ID, string description) { 
            string sql = "UPDATE Zahtjevi SET Opis='" + description + "' WHERE ID_Zahtjeva = " + ID + ";"; 
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
        /// <summary>
        /// Funkcija koja vraća zahtjeve koji sadrže znakove za pretragu po imenu osobe koja je preuzela zahtjev.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<Ticket> SearchByName(string name) {
            List<Ticket> tickets = new List<Ticket>();
            string sql = "SELECT * FROM Zahtjevi WHERE Ime LIKE'" + name + "%';";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read()) {
                Ticket ticket = CreateObject(reader);
                tickets.Add(ticket);
            }
            reader.Close();
            DB.CloseConnection();
            return tickets;


        }
    }
}
