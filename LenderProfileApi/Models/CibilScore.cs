using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LenderProfileApi.Models
{
    public class CibilScore
    {
        public byte Id { get; set; }
        [StringLength(10)]
        [Required]
        public string Score { get; set; }
    }
}