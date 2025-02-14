using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Alert
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AlertMessage { get; set; }
        public string Severity { get; set; } // E.g., "Critical", "Warning"
        public DateTime Timestamp { get; set; }
        public List<Stakeholder> Recipients { get; set; }
    }
}
