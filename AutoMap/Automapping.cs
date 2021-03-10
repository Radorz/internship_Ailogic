﻿using System;
using AutoMapper;
using Database.Models;
using DTO;

namespace AutoMap
{
    public class Automapping : Profile
    {
        public Automapping()
        {
            Maprequest();
            MapIntern();
        }
        private void Maprequest()
        {
            CreateMap<ApplyInternshipDTO, RequestInternship>().ReverseMap();
           
        }

        private void MapIntern()
        {
            CreateMap<InternDTO, Interns>().ReverseMap().
            ForMember(dest => dest.User, opt => opt.Ignore());
            
        }
        //private void MapearElecciones()
        //{
        //    CreateMap<EleccionesViewModel, Elecciones>().ReverseMap();
        //}



        //private void MapearCandidatos()
        //{
        //    CreateMap<CandidatosViewModel, Candidatos>().ReverseMap().
        //    ForMember(dest => dest.Partido, opt => opt.Ignore()).
        //    ForMember(dest => dest.PuestoElectivo, opt => opt.Ignore());
        //}




    }
}