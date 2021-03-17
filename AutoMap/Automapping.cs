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
            MapIntern();
            MapInternCreation();
            MapInternships();
            Maprequestpost();
            MapApplyInterns();
            MapFiles();
            MapFilespost()
        }
        private void Maprequest()
        {
            CreateMap<ApplyInternshipDTO, RequestInternship>().ReverseMap();
        }
        private void Maprequestpost()
        {
            CreateMap<ApplyInternshipDTOPost, RequestInternship>().ReverseMap();
        }
        private void MapIntern()
        {
            CreateMap<InternDTO, Interns>().ReverseMap().
            ForMember(dest => dest.User, opt => opt.Ignore());
        }

        private void MapInternCreation()
        {
            CreateMap<InternCreationDTO, Interns>().ReverseMap();
            
        }


        private void MapInternships()
        {
            CreateMap<InternshipsDTO, Internship>().ReverseMap();

        }

        private void MapApplyInterns()
        {
            CreateMap<ApplyInternshipDTOPost, Interns>().ReverseMap()
                .ForMember(dest => dest.Email, opt => opt.Ignore());
        }

        private void MapFiles()
        {
            CreateMap<FilesDTO, Files>().ReverseMap();
        }

        private void MapFilespost()
        {
            CreateMap<FilesDTOPost, Files>().ReverseMap();
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
