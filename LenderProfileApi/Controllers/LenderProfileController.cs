using AutoMapper;
using LenderProfileApi.Dto;
using LenderProfileApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
namespace LenderProfileApi.Controllers
{

    public class LenderProfileController : ApiController
    {
        private readonly ApplicationContext _context;
        public LenderProfileController()
        {
            _context = new ApplicationContext();
        }

        public IHttpActionResult GetLenderProfile()
        {
            return Ok(_context.Loans
                .Include(l => l.Lender)
                .Include(l => l.CibilScore)
                .ToList().
                Select(Mapper.Map<Loan, LoanDto>));
        }

        public IHttpActionResult GetLenderProfile(int id)
        {
            var loan = _context.Loans
                 .Include(l => l.Lender)
                .Include(l => l.CibilScore)
                .Where(l => l.Id == id)
                .Select(Mapper.Map<Loan, LoanDto>);
            return Ok(loan);
        }

        [HttpPost]
        public IHttpActionResult SaveLenderProfile(SaveLenderProfileDto LenderProfile)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            if (LenderProfile.Loan.Id == 0)
            {
                var lender = Mapper.Map<Lender>(LenderProfile.Lender);
                var loan = Mapper.Map<Loan>(LenderProfile.Loan);

                _context.Lenders.Add(lender);
                _context.SaveChanges();

                loan.LenderId = lender.Id;
                _context.Loans.Add(loan);

                _context.SaveChanges();
            }
            else
            {
                var lenderInDb = _context.Lenders.Single(l => l.Id == LenderProfile.Lender.Id);
                var loanInDb = _context.Loans.Single(l => l.Id == LenderProfile.Loan.Id);

                Mapper.Map(LenderProfile.Lender, lenderInDb);
                Mapper.Map(LenderProfile.Loan, loanInDb);

                _context.SaveChanges();
            }

            return Ok("Saved");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var loan = _context.Loans.SingleOrDefault(l => l.Id == id);
            var lender = _context.Lenders.SingleOrDefault(l => l.Id == loan.Id);
            _context.Loans.Remove(loan);
            _context.Lenders.Remove(lender);
            _context.SaveChanges();
            return Ok("Deleted");
        }










    }
}
