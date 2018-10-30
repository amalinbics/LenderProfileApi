using AutoMapper;
using LenderProfileApi.Dto;
using LenderProfileApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LenderProfileApi.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Loan, LoanDto>();
            Mapper.CreateMap<LoanDto, Loan>();

            Mapper.CreateMap<Loan, SaveLoanDto>();
            Mapper.CreateMap<SaveLoanDto, Loan>();

            Mapper.CreateMap<Lender, LenderDto>();
            Mapper.CreateMap<LenderDto, Lender>();

            Mapper.CreateMap<CibilScore, CibilScoreDto>();
            Mapper.CreateMap<CibilScoreDto, CibilScore>();
        }
    }
}