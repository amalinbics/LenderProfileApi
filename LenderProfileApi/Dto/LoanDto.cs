using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LenderProfileApi.Dto
{
    public class LoanDto
    {
        public int Id { get; set; }

        [Required]
        public decimal AnnualIncome { get; set; }

        [Required]
        public int CibilScoreId { get; set; }

        [Required]
        public decimal LoanAmount { get; set; }

        [Required]
        public byte TenureInMonths { get; set; }

        [Required]
        public double RateOfInterest { get; set; }

        [Required]
        public decimal EMI { get; set; }

    }
}