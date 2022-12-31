using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ms_tracker.Context;
using ms_tracker.Models;
using ms_tracker.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ms_tracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly TrackerContext _context;
        private readonly IMapper _mapper;

        public ProjetoController(TrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult CreateProject([FromBody] AddProjetoDto projetoDto)
        {
            Projeto projeto = _mapper.Map<Projeto>(projetoDto);
            _context.Add(projeto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProjectById), new { id = projeto.Id}, projeto);
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var projeto = _context.Projetos.FirstOrDefault(projeto => projeto.Id == id);

            if(projeto == null) return NotFound();

            var projetoDto = _mapper.Map<ReadProjetoDto>(projeto);

            return Ok(projetoDto);
        }
        
        [HttpGet]
        public IEnumerable<ReadProjetoDto> GetProjects([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _mapper.Map<List<ReadProjetoDto>>(_context.Projetos).OrderBy(proj => proj.Id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, [FromBody] UpdateProjetoDto projetoDto)
        {
            var projeto = _context.Projetos.FirstOrDefault(projeto => projeto.Id == id);

            if(projeto == null) return NotFound();

            _mapper.Map(projetoDto, projeto);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var projeto = _context.Projetos.FirstOrDefault(projeto => projeto.Id == id);

            if(projeto == null) return NotFound();

            _context.Remove(projeto);
            _context.SaveChanges();
            return NoContent();
        }

    }
}