using AutoMapper;
using CAT20.Core.Models.Control;
using CAT20.Core.Models.Vote;
using CAT20.Core.Models.User;
using CAT20.WebApi.Resources.Control;
using CAT20.WebApi.Resources.User;
using CAT20.WebApi.Resources.User.Save;
using CAT20.WebApi.Resources.Vote;
using CAT20.WebApi.Resources.Vote.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAT20.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            //CreateMap<Product, ProductResource>();
            //CreateMap<Invoice, InvoiceResource>().ForMember(x => x.InvoiceItemResource, x => x.MapFrom(x => x.InvoiceItems)) ;
            //CreateMap<InvoiceItems, InvoiceItemResource>();
            CreateMap<Province, ProvinceResource>();
            CreateMap<BankDetail, BankDetailResource>();
            CreateMap<District, DistrictResource>();
            CreateMap<Gender, GenderResource>();
            CreateMap<Language, LanguageResource>();
            CreateMap<Month, MonthResource>();
            CreateMap<Office, OfficeResource>();
            CreateMap<OfficeType, OfficeTypeResource>();
            CreateMap<Province, ProvinceResource>();
            CreateMap<Sabha, SabhaResource>();
            CreateMap<SelectedLanguage, SelectedLanguageResource>();
            CreateMap<Year, YearResource>();


            CreateMap<Programme, ProgrammeResource>();
            CreateMap<AccountBalanceDetail, AccountBalanceDetailResource>();
            CreateMap<AccountDetail, AccountDetailResource>();
            CreateMap<BalancesheetBalance, BalancesheetBalanceResource>();
            CreateMap<BalancesheetSubtitle, BalancesheetSubtitleResource>();
            CreateMap<BalancesheetTitle, BalancesheetTitleResource>();
            CreateMap<Project, ProjectResource>();
            CreateMap<SubProject, SubProjectResource>();
            CreateMap<IncomeSubtitle, IncomeSubtitleResource>();
            CreateMap<IncomeTitle, IncomeTitleResource>();
            CreateMap<VoteAllocation, VoteAllocationResource>();
            CreateMap<VoteDetail, VoteDetailResource>();
            
            
            CreateMap<UserDetail, UserDetailResource>();
            CreateMap<LoginDetail, LoginResource>();
            CreateMap<Previledge, PreviledgeResource>();
            CreateMap<UserHasPreviledge, UserHasPreviledgeResource>();
            CreateMap<UserRecoverQuestion, UserRecoverQuestionResource>();

            // Resource to Domain

            //CreateMap<ProductResource, Product>();
            //CreateMap<SaveProductResource, Product>();

            //CreateMap<InvoiceResource, Invoice>().ForMember(x => x.InvoiceItems, x => x.MapFrom(x => x.InvoiceItemResource));
            //CreateMap<SaveInvoiceResource, Invoice>().ForMember(x => x.InvoiceItems, x => x.MapFrom(x => x.SaveInvoiceItemResource));

            //CreateMap<InvoiceItemResource, InvoiceItems>();
            //CreateMap<SaveInvoiceItemResource, InvoiceItems>();

            CreateMap<AccountBalanceDetailResource, AccountBalanceDetail>();
            CreateMap<SaveAccountBalanceDetailResource, AccountBalanceDetail>();

            CreateMap<AccountDetailResource, AccountDetail>();
            CreateMap<SaveAccountDetailResource, AccountDetail>();

            CreateMap<BalancesheetBalanceResource, BalancesheetBalance>();
            CreateMap<SaveBalancesheetBalanceResource, BalancesheetBalance>();

            CreateMap<BalancesheetSubtitleResource, BalancesheetSubtitle>();
            CreateMap<SaveBalancesheetSubtitleResource, BalancesheetSubtitle>();

            CreateMap<BalancesheetTitleResource, BalancesheetTitle>();
            CreateMap<SaveBalancesheetTitleResource, BalancesheetTitle>();

            CreateMap<ProjectResource, Project>();
            CreateMap<SaveProjectResource, Project>();

            CreateMap<SubProjectResource, SubProject>();
            CreateMap<SaveSubProjectResource, SubProject>();

            CreateMap<IncomeSubtitleResource, IncomeSubtitle>();
            CreateMap<SaveIncomeSubtitleResource, IncomeSubtitle>();

            CreateMap<IncomeTitleResource, IncomeTitle>();
            CreateMap<SaveIncomeTitleResource, IncomeTitle>();

            CreateMap<VoteAllocationResource, VoteAllocation>();
            CreateMap<SaveVoteAllocationResource, VoteAllocation>();

            CreateMap<ProgrammeResource, Programme>();
            CreateMap<SaveProgrammeResource, Programme>();

            CreateMap<VoteDetailResource, VoteDetail>();
            CreateMap<SaveVoteDetailResource, VoteDetail>();

            CreateMap<PreviledgeResource, Previledge>();
            CreateMap<SavePreviledgeResource, Previledge>(); 
            
            CreateMap<UserDetailResource, UserDetail>();
            CreateMap<SaveUserDetailResource, UserDetail>();

            CreateMap<LoginResource, UserDetail>();

            CreateMap<UserHasPreviledgeResource, UserHasPreviledge>();
            CreateMap<SaveUserHasPreviledgeResource, UserHasPreviledge>();

            CreateMap<UserRecoverQuestionResource, UserRecoverQuestion>();
            CreateMap<SaveUserRecoverQuestionResource, UserRecoverQuestion>();
        }
    }
}

