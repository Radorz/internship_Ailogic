using System;
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
        }
        private void Maprequest()
        {
            CreateMap<ApplyInternshipDTO, RequestInternship>().ReverseMap();
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
