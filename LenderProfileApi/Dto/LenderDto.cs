using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LenderProfileApi.Dto
{
    public class LenderDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(12)]
        public string MobileNo { get; set; }

        [StringLength(12)]
        public string AlternateMobileNo { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }
    }
}