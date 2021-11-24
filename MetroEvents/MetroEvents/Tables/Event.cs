using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetroEvents.Tables {
    class Event {

        [PrimaryKey]
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Date { get; set; }
        public string User { get; set; }

        public override string ToString() {
            return "Event Name: " + this.Name + "(" + "Event Address: " + this.Address + " Event Date: " + this.Date + " User: " + this.User + ")";
         }
    }
}
