using AutoMapper;
using Database.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
   public class FilesRepository : RepositoryBase<Files, bnbar022dce4hrtds2xdContext>
    {
        private readonly bnbar022dce4hrtds2xdContext _context;
        private readonly IMapper _mapper;
        public FilesRepository(bnbar022dce4hrtds2xdContext context, IMapper mapper)
            :base(context)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<FilesDTO> getByIdCustom(int id )
        {
         
                Files file = await GetbyId(id);
                FilesDTO result = _mapper.Map<FilesDTO>(file);
                return result;
          

        }


        public async Task<List<FilesAllDTO>> GetFilesAll(int Id_assignment)
        {

            List<Files> filesList = new List<Files>();
            filesList =  _context.Files.Where(x => x.id_assignment == Id_assignment).ToList();
            List<FilesAllDTO> DtoReturn = new List<FilesAllDTO>();
            foreach(var i in filesList)
            {
                var intern = _context.Interns.FirstOrDefaultAsync(x => x.IdUser == i.IdUser);
                var assignments = _context.Assignments.FirstOrDefaultAsync(x => x.Id_Assignment == i.id_assignment);
                FilesAllDTO dto = _mapper.Map<FilesAllDTO>(i);
                dto.Intern = _mapper.Map<InternDTO>(intern);
                dto.Assignments = _mapper.Map<AssignmentsDTO>(assignments);
                DtoReturn.Add(dto);
                  
            }
            return DtoReturn;
        }


        public async Task<List<FilesDTO>> getalla()
        {
            var files = await GetAll();
            var list = new List<FilesDTO>();
            foreach (var i in files)
            {
                FilesDTO result = _mapper.Map<FilesDTO>(i);
                list.Add(result);

            }
            return list;


        }

        public async Task<FilesDTO> addCustom(FilesDTO dto)
        {
           
                Files file = _mapper.Map<Files>(dto);
                Files result = await Add(file);
                FilesDTO returns = _mapper.Map<FilesDTO>(result);
                return returns;
           


        }

        public async Task<FilesDTO> updateCustom(int id, FilesDTOPost dto)
        {
            Files file = await GetbyId(id);
            //file.Path = dto.Path;
            //file.FileName = dto.FileName;
            var result = await Update(file);
            FilesDTO returns = _mapper.Map<FilesDTO>(result);
            return returns;



        }

    }
}
