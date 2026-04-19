using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPHelpDesk.Models {
    /// <summary>
    /// Klasa koja preslikava tablicu Korisnik iz baze podataka.
    /// </summary>
    public class User {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool CheckPassword(string password) {
            return Password == password;
        }
    }
}
