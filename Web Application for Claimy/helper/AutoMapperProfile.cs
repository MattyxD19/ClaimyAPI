using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Application_for_Claimy.Models;
using Web_Application_for_Claimy.Models.Customers;

namespace Web_Application_for_Claimy.helper
{
    public class AutoMapperProfile : Profile
    {
            public AutoMapperProfile()
            {
                CreateMap<CustomerEntity, CustomerModel>();
                CreateMap<RegisterCustomer, CustomerEntity>();
                CreateMap<CustomerUpdate, CustomerEntity>();
            }
        
    }
}