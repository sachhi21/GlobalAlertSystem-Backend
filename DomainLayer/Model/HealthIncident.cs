using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class HealthIncident : Incident
    {
        public string Disease { get; set; }
        public int ConfirmedCases { get; set; }
        public int Fatalities { get; set; }
        public int Recovered { get; set; }
    }
}
