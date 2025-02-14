using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class IncidentMetrics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IncidentReportId { get; set; }
        public int NumberOfCasualties { get; set; }
        public int NumberOfInjuries { get; set; }
        public int FinancialLoss { get; set; } // In USD
        public double RecoveryTime { get; set; } // In days
    }
}
