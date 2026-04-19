using CIPHelpDesk.Models;
using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPHelpDesk.Repositories {
    public class UserRepository {
        /// <summary>
        /// Funkcija stvara SQL upit za dohvaćanje specifičnog korisnika.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Korisničko ime, ime, prezime, i lozinku. </returns>
        public static User GetUser(string username) {
            string sql = $"SELECT * FROM Korisnici WHERE Korisnicko_Ime = '{username}'";
            return FetchUser(sql);
        } 
        /// <summary>
        /// Funkcija koja izvršava SQL upit za dohvaćanje korisnika iz baze podataka.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Objekt korisnik.</returns>

        public static User FetchUser(string sql) {
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            User user = null;

            if (reader.HasRows == true) {
                reader.Read();
                user = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();

            return user;
        }
        /// <summary>
        /// Funkcija koja kreira objekt tipa User iz podataka koje je SqlDataReader pročitao.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Objekt korisnik.</returns>
        private static User CreateObject(SqlDataReader reader) {
            int id = int.Parse(reader["ID_Korisnika"].ToString());
            string name = reader["Ime"].ToString();
            string lastname = reader["Prezime"].ToString();
            string username = reader["Korisnicko_Ime"].ToString();
            string password = reader["Lozinka"].ToString();

            var user = new User {
                ID = id,
                Name = name,
                Lastname = lastname,
                UserName = username,
                Password = password
            };
            return user;
        }
    }
}
