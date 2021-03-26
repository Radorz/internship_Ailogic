﻿using AutoMapper;
using Database.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class EvaluationsRepository : RepositoryBase<Evaluations, bnbar022dce4hrtds2xdContext>
    {
        private readonly IMapper _mapper;
        public EvaluationsRepository(bnbar022dce4hrtds2xdContext context, IMapper mapper) :base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<EvaluationsDTO>> GetAllCustom()
        {
            List<EvaluationsDTO> evaluationsDTOs = new List<EvaluationsDTO>();
            var evaluations = await _context.Set<Evaluations>().ToListAsync();
            foreach (var i in evaluations)
            {
                var evaluation = _mapper.Map<EvaluationsDTO>(i);
                evaluationsDTOs.Add(evaluation);
            }

            return evaluationsDTOs;
        }

        public async Task<EvaluationsDTO> GetByIdCustom(int id)
        {
            var evaluation = await _context.Set<Evaluations>().FindAsync(id);
            if(evaluation == null)
            {
                return null;
            }
            var evaluationDTO = _mapper.Map<EvaluationsDTO>(evaluation);
            return evaluationDTO;
        }

        public async Task<Evaluations> AddCustom(EvaluationsDTOPost dto)
        {
            var evaluation = _mapper.Map<Evaluations>(dto); 
            try
            {
              var eva=  _context.Set<Evaluations>().Add(evaluation);
                await _context.SaveChangesAsync();
                return eva.Entity;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<EvaluationsDTO> UpdateCustom(int id, EvaluationsDTO dto)
        {
         
            var evaluations = _context.Set<Evaluations>().Find(id);
            if (evaluations == null)
            {
                return null;

            }
            evaluations.IdEvaluation = dto.IdEvaluation;
            evaluations.Name = dto.Name;
            evaluations.Description = dto.Description;
                _context.Entry(evaluations).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return dto;

            
            
        }



    }
}
