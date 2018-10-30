using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LenderProfileApi.Dto
{
    public class SaveLenderProfileDto
    {
        public LenderDto Lender { get; set; }
        public LoanDto Loan { get; set; }
    }
}