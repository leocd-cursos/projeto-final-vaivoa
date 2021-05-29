using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace CardVaiVoa.Models
{
    public class UserCard
    {
        internal object Users;

        public int Id { get; set; }
        public string NumberCard { get; set; }
        
        public int KeyId { get; set; }
      
    }
}
