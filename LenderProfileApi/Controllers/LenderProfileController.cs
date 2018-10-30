using AutoMapper;
using LenderProfileApi.Dto;
using LenderProfileApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LenderProfileApi.Controllers
{
    
    public class LenderProfileController : ApiController
    {
        private readonly ApplicationContext _context;
        public LenderProfileController()
        {
            _context = new ApplicationContext();
        }



        [HttpPost]
        public IHttpActionResult SaveLenderProfile(SaveLenderProfileDto LenderProfile)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var lender = Mapper.Map<Lender>(LenderProfile.Lender);
            var loan = Mapper.Map<Loan>(LenderProfile.Loan);

            _context.Lenders.Add(lender);
            _context.SaveChanges();

            loan.LenderId = lender.Id;
            _context.Loans.Add(loan);

            _context.SaveChanges();

            return Ok();
        }




    }
}
