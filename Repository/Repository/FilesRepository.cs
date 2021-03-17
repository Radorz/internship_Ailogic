using AutoMapper;
using Database.Models;
using DTO;
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

        public async Task<FilesDTO> addCustom(FilesDTOPost dto)
        {
           
                Files file = _mapper.Map<Files>(dto);
                Files result = await Add(file);
                FilesDTO returns = _mapper.Map<FilesDTO>(result);
                return returns;
           


        }

        public async Task<FilesDTO> updateCustom(int id, FilesDTOPost dto)
        {
            Files file = await GetbyId(id);
            file.Path = dto.Path;
            file.FileName = dto.FileName;
            var result = await Update(file);
            FilesDTO returns = _mapper.Map<FilesDTO>(result);
            return returns;



        }

    }
}
