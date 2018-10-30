using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace LenderProfileApi.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("LenderProfile")
        {
        }
        public DbSet<Lender> Lenders { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public DbSet<CibilScore> CibilScores { get; set; }

    }
}