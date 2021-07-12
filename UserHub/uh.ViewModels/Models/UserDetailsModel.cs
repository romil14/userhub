using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uh.ViewModels.Models
{
    public class UserDetailsDto
    {
        public int UserDetailsId { get; set; }

        
        public string Name { get; set; }

       
        public string Email { get; set; }

      
        public string Password { get; set; }

      
        public string UserName { get; set; }

     
        public DateTime DateOfBirth { get; set; }

      
        public char Gender { get; set; }

        public int Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
    }
}
