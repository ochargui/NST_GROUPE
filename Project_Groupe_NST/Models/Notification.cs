using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class Notification
    {
        [Key]
        public int idNot{ get; set; }

        public string IdUserAction{ get; set; }
        public string IdUserReception { get; set; }

        public string Message { get; set; }
        public DateTimeOffset DateNotif { get; set; }
        public int idUsers { get; set; }


    }
}
