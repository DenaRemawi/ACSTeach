using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcsTechs.Models
{
    public class UserModels
    {

        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string FinalName { get; set; }

         [Required]
        public string UserName { get; set; }

        public string EmailUser { get; set; }

        public string MobileNumber { get; set; }


    }
}