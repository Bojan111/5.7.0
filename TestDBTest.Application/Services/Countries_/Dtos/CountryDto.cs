using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestDBTest.Services
{
    [AutoMap(typeof(Entities.Countries))]
    public class CountryDto : EntityDto
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
