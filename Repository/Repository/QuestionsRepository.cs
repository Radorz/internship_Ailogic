using AutoMapper;
using Database.Models;
using DTO;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Repository.Repository
{
    public class QuestionsRepository : RepositoryBase<QuestionsRepository, bnbar022dce4hrtds2xdContext> 
    {
        private readonly IMapper _mapper;
        public QuestionsRepository(bnbar022dce4hrtds2xdContext context, IMapper mapper) :base(context)
        {
            _mapper = mapper;
        }

        public async Task<QuestionsDTOPost> AddCustom(QuestionsDTOPost dto)
        {
            var questions = _mapper.Map<Questions>(dto);
            try
            {
                await _context.Set<Questions>().AddAsync(questions);
                await _context.SaveChangesAsync();
                return dto;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        

    }
}
