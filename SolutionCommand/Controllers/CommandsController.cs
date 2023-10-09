using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solution.Data;
using Solution.Dtos;
using Solution.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _repository;

        private readonly IMapper _mapper;

        public CommandsController(ICommandAPIRepo repository, IMapper mapper)
        {
            _repository = repository;

            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommand(CommandCreatedDto commandCreatedDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreatedDto);

            await _repository.CreateCommand(commandModel);

            await _repository.SaveChangesAsync();

            return Created("", commandModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetCommands()
        {
            var commands = await _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommandById(int id)
        {
            var command = await _repository.GetCommandById(id);

            if (command is null)
                return NotFound();

            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComamnd(int id)
        {
            var commandModelFromRepo = await _repository.GetCommandById(id);

            if (commandModelFromRepo is null)
                return NotFound();

            _repository.DeleteCommand(commandModelFromRepo);

            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComamnd(int id, CommandUpdateDto updateDto)
        {
            var commandModelFromRepo = await _repository.GetCommandById(id);

            if (commandModelFromRepo is null)
                return NotFound();

            _mapper.Map(updateDto, commandModelFromRepo);

            await _repository.UpdateCommand(commandModelFromRepo);

            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}