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
    public class RequestInternshipRepository : RepositoryBase<RequestInternship, bnbar022dce4hrtds2xdContext>
    {
        private readonly IMapper _mapper;

      

        public RequestInternshipRepository(bnbar022dce4hrtds2xdContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;

        }
        public async Task<bool> Apply(ApplyInternshipDTOPost dto)
        {
            try
            {
                var request = _mapper.Map<RequestInternship>(dto);
                var idinternship = _context.Internship.FirstOrDefault(a => a.Status == true);
                if (idinternship == null)
                {
                    return false;
                }
                else {
                    request.IdInternship = idinternship.IdInternship;
                    await Add(request);
                    return true;
                }
            }   catch(Exception e)
            {
                return (false);
            }
            

        }

        public async Task<List<ApplyInternshipDTO>> getlist()
        {
            List<RequestInternship> list = await _context.RequestInternship.ToListAsync();
            List<ApplyInternshipDTO> listdto = new List<ApplyInternshipDTO>();
            foreach(var i in list)
            {
                var request = _mapper.Map<ApplyInternshipDTO>(i);
                listdto.Add(request);
            }

            return listdto;
        }
    }
}
