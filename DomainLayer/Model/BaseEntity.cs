using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        [StringLength(255)]
        [Unicode(false)]
        public string? CreatedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedOn { get; set; }

        [StringLength(255)]
        [Unicode(false)]
        public string? ModifiedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedOn { get; set; }
    }
}
