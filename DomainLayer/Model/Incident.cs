
using DomainLayer.Model;

namespace DomainLayer
{
    public class Incident : BaseEntity
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }
        public string Reporter { get; set; }
        public string Contact { get; set; }
    }

}