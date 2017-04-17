using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<Entity.Applicant, Models.ApplicantBasicViewModel>()
                .ForMember(dest => dest.Contact_Email, opt => opt.MapFrom(src => (src.Contacts.Count == 0) ?null:src.Contacts.First().Address.Email))
                .ForMember(dest => dest.Contact_FName, opt => opt.MapFrom(src => (src.Contacts.Count == 0) ? null : src.Contacts.First().FName))
                  .ForMember(dest => dest.Contact_MName, opt => opt.MapFrom(src => (src.Contacts.Count == 0) ? null : src.Contacts.First().MName))
                    .ForMember(dest => dest.Contact_MobilePhone, opt => opt.MapFrom(src => (src.Contacts.Count == 0) ? null : src.Contacts.First().Address.PhoneBooks.Where(p => p.Type == "Mobile").First().Phone))
                    .ForMember(dest => dest.Contact_OfficePhone, opt => opt.MapFrom(src => (src.Contacts.Count == 0) ? null : src.Contacts.First().Address.PhoneBooks.Where(p => p.Type == "Office").First().Phone));

                cfg.CreateMap<Entity.Student, Models.Admission.StudentInfoViewModel>().ReverseMap();

                cfg.CreateMap<Models.Staff.StaffClaimViewModel, Entity.Staff>()
                   .ForMember(dest => dest.Address,
               opts => opts.MapFrom(src => new Entity.Address() { Email = src.Email }))
                .AfterMap((srs, dest) => dest.Address.PhoneBooks.Add(new Entity.PhoneBook { Phone = srs.MobilePhone, Type= "Mobile"}));


            });
        }
    }
}