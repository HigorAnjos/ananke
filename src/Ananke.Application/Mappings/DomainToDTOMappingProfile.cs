using Ananke.Application.DTOs;
using Ananke.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Ananke.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Course, MediaProjectionDTO>()
                .ForMember(dest => dest.FirstExam, opt => opt.MapFrom(src => src.Exams[0]))
                .ForMember(dest => dest.SecondExam, opt => opt.MapFrom(src => src.Exams[1]))
                .ForMember(dest => dest.ThirdExam, opt => opt.MapFrom(src => src.Exams[2]))
                .ForMember(dest => dest.QuarterExam, opt => opt.MapFrom(src => src.Exams[3]))
                .ForMember(dest => dest.MediaSemester, opt => opt.MapFrom(src => src.CalcularMediaSemestral()))
                .ReverseMap();
        }
    }
}
