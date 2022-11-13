
using AutoMapper;
using CD_first_withDI.Models;
using CD_first_withDI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CD_first_withDI
{
  
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Shoes, ShoesViewModel>()
                .ReverseMap();

        }
    }
}
