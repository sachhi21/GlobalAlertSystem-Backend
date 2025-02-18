using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOModels
{
    public  class IncidentDto
    {
        public int Id { get; set; }
        public string IncidentType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Severity { get; set; }
        public string Status { get; set; }
        public string Discriminator { get; set; }
        public int EmergencyResponseTeamId { get; set; }
        public string BreachType { get; set; }
        public int AffectedSystems { get; set; }
        public int DataCompromised { get; set; }
        public string Disease { get; set; }
        public int ConfirmedCases { get; set; }
        public int FailedCases { get; set; }
        public int Recovered { get; set; }
        public string AccidentType { get; set; }
        public int Casualties { get; set; }
        public int EstimatedDamage { get; set; }
        public string DisasterType { get; set; }
        public string AffectedAreas { get; set; }
        public double Magnitude { get; set; }
        public int NaturalDisaster_EstimatedDamage { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }


    }
}
