using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPHelpDesk.Models {
    /// <summary>
    /// Klasa koj preslikava zahtjev spremljen na SQL serveru.
    /// </summary>
    public class Ticket {
        [DisplayName("Broj zahtjeva")]
        public int ID { get; set; }
        [DisplayName("Datum podnošenja")]
        public string Date { get; set; }
        [DisplayName("Vrijeme podnošenja")]
        public string Time { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Ime")]
        public string Name { get; set; }
        [DisplayName("Prezime")]
        public string Lastname { get; set; }
        [DisplayName("Komentari")]
        public string Comments { get; set; }
        [DisplayName("Prioritet")]
        public string Priority { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }

        public override string ToString() {
            return Name + " " + Lastname;
        }

    }
}
