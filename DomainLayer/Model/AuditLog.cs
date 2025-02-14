using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public  class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Action { get; set; } // E.g., "Created", "Updated", "Deleted"
        public DateTime Timestamp { get; set; }
        public string PerformedBy { get; set; }
        public int IncidentReportId { get; set; }
    }
}
