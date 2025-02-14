using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class EmergencyResponseTeam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; } // E.g., "Firefighters", "Paramedics"
        public string ContactNumber { get; set; }
        public List<Incident> AssignedIncidents { get; set; }
    }
}
