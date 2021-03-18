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
using System.Web.Mvc;

namespace Repository.Repository
{
    public class QuestionsRepository : RepositoryBase<Questions, bnbar022dce4hrtds2xdContext> 
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

        public async Task<List<QuestionsDTO>> GetAllCustom()
        {
            List<QuestionsDTO> questionsList = new List<QuestionsDTO>();
            var questions = await _context.Set<Questions>().ToListAsync();
            foreach (var i in questions)
            {
                var question = _mapper.Map<QuestionsDTO>(i);
                question.IdEvaluation = i.IdEvaluation;
                var evaluation = await _context.Evaluations.FirstOrDefaultAsync(x => x.IdEvaluation == i.IdEvaluation);
                question.Evaluations = _mapper.Map<EvaluationsDTO>(evaluation);
                questionsList.Add(question);
            }
            return questionsList;
        }

        public async Task<QuestionsDTO> GetByIdCustom(int id)
        {
            var question = await _context.Set<Questions>().FirstOrDefaultAsync(x => x.IdQuestion == id);
            var questionsDTO = _mapper.Map<QuestionsDTO>(question);
            var evaluation = await _context.Set<Evaluations>().FindAsync(question.IdEvaluation);
            questionsDTO.Evaluations = _mapper.Map<EvaluationsDTO>(evaluation);
            return questionsDTO;
        }

   

        public async Task<bool> UpdateCustom(int id, QuestionsDTOPost dto)
        {
            var question = await _context.Set<Questions>().FindAsync(id);
            if (question == null)
            {
                return false;
            }
            try
            {
                //intern = _mapper.Map<Interns>(dto);
                question.IdQuestion = id;
                question.IdEvaluation = dto.IdEvaluation;
                question.Question = dto.Question;
                _context.Entry(question).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
