
using DomainLayer.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class Incident : BaseEntity
    {
       
        public string IncidentType { get; set; } // E.g., "Natural Disaster", "Cybersecurity Breach"
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Severity { get; set; } // E.g., "Low", "Medium", "High", "Critical"
        public string Status { get; set; } // E.g., "Reported", "In Progress", "Resolved", "Closed"
        public Location Location { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<Stakeholder> Stakeholders { get; set; }
    }


}