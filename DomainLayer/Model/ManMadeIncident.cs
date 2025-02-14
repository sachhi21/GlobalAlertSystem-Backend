using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class ManMadeIncident : Incident
    {

        public string AccidentType { get; set; } // E.g., "Industrial Accident", "Oil Spill"
        public int Casualties { get; set; }
        public int EstimatedDamage { get; set; } // In USD
    }
}
