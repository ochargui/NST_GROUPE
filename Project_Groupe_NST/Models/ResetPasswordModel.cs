using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class ResetPasswordModel

    { 
           
            public string NewPassword { get; set; }

           
            public string ConfirmPassword { get; set; }

           
            public string ResetCode { get; set; }
        }
    }

