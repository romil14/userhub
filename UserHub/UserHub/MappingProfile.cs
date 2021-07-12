using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uh.Entities.Models;
using uh.ViewModels.Models;

namespace UserHub
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDetails, UserDetailsDto>();
            CreateMap<UserDetailsDto, UserDetails>()
                .ForMember(dest => dest.CreatedOn, opts => opts.Ignore()); ;
        }
    }
}
