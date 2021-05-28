using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CardVaiVoa.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        //public int UserCardsId { get; set; }
        //public List<UserCards> UserCards { get; set; }
        
    }
}
