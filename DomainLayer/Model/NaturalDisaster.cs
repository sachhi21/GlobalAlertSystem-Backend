using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class NaturalDisaster : Incident
    {
        public string DisasterType { get; set; } // E.g., "Earthquake", "Flood", "Hurricane"
        public double Magnitude { get; set; } // E.g., for Earthquakes
        public string AffectedAreas { get; set; }
        public int    EstimatedDamage { get; set; } // In USD
    }
}

