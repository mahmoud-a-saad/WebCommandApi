using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using webcommand.Data;
using WebCommand.Dtos;
using WebCommand.Models;

namespace webcommand.Controllers
{
    //api commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly WebCommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(WebCommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper=mapper;
        }


       // private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        //get api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDTO>> getallcommands()
        {
            var CommandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(CommandItems));
        }

        //get api/commands/{id} 
        [HttpGet("{id}",Name="GetCommandById")]
        public ActionResult <CommandReadDTO> GetCommandById(int id)
        {
            var CommandItem = _repository.GetCommandById(id);
            if(CommandItem!=null)
            {
                return Ok(_mapper.Map<CommandReadDTO>(CommandItem));
            }
            else
            {
                return NotFound();
            }
        }

        //POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDTO> CreateCommand(CommandCreateDTO commandcreatedto)
        {
            var commandModel = _mapper.Map<Command>(commandcreatedto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var CommandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById),new {id=CommandReadDTO.id,CommandReadDTO});    
            //return Ok(CommandReadDTO);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult <CommandUpdateDTO> UpdateCommand(int id,CommandUpdateDTO commandupdatedto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo==null)
            {
                return NotFound();
            }
            _mapper.Map(commandupdatedto, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //Patch api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult <CommandUpdateDTO> PartialUpdateCommand(int id, JsonPatchDocument<CommandUpdateDTO> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo==null)
            {
                return NotFound();
            } 
            var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandModelFromRepo);  
            patchDoc.ApplyTo(commandToPatch,ModelState) ;
            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commandToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //Delete api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo==null)
            {
                return NotFound();
            } 
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

    }

}