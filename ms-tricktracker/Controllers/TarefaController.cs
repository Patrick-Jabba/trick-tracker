using AutoMapper;
using ms_tracker.Context;
using ms_tracker.Models;
using ms_tracker.Models.Dtos.Tarefa;
using Microsoft.AspNetCore.Mvc;

namespace ms_tracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TrackerContext _context;
        private readonly IMapper _mapper;

        public TarefaController(TrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] AddTarefaDto tarefaDto)
        {
            Tarefa tarefa = _mapper.Map<Tarefa>(tarefaDto);
            _context.Add(tarefa);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTaskById), new { id = tarefa.Id}, tarefa);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);

            if(tarefa == null) return NotFound();

            var tarefaDto = _mapper.Map<ReadTarefaDto>(tarefa);

            return Ok(tarefaDto);

        }

        [HttpGet]
        public IEnumerable<ReadTarefaDto> GetTasks([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _mapper.Map<List<ReadTarefaDto>>(_context.Tarefas);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, UpdateTarefaDto updateTarefaDto)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);

            if(tarefa == null) return NotFound();

            _mapper.Map(updateTarefaDto, tarefa);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);

            if(tarefa == null) return NotFound();
            _context.Remove(tarefa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}