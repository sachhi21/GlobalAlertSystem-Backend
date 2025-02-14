using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class CybersecurityIncident : Incident
    {

        public string BreachType { get; set; } // E.g., "Data Leak", "DDoS Attack"
        public int AffectedSystems { get; set; }
        public int DataCompromised { get; set; } // In GB or Number of Records
    
}
}
