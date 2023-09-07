using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portal.Models.Leave
{
    public class Leave
    {

        [Key]
        public int LeaveId { get; set; }

        public string Purpose { get; set; }

        public DateTime DateFrom { get; set; } = DateTime.Now;

        public DateTime DateTo { get; set; } = DateTime.Now;


        [ForeignKey("UserId")] 
        public string UserId { get; set; } 
        public IdentityUser User { get; set; }
    }
}
