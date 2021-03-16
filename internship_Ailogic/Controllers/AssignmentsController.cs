using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Repository;

namespace internship_Ailogic.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController
    {
        private readonly AssignmentsRepository _assignmentsRepository;
        public AssignmentsController(AssignmentsRepository assignmentsRepository)
        {
            _assignmentsRepository = assignmentsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AssignmentsDTO>>> Get()
        {
            return await _assignmentsRepository.GetAllCustom();
        }
    }
}
