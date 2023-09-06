using Api.Controllers;
using Api.Dtos;
using AutoMapper;
using Api.Helpers.Paginator;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Domain.Interface.Pagination;

namespace ApiIncidencias.Controllers;
[ApiVersion("1.0")]
public class PersonController : BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _Mapper;

    public PersonController (IUnitOfWork unitOfWork,IMapper mapper){
        _UnitOfWork = unitOfWork;
        _Mapper = mapper;
    }

    [HttpGet]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<Person>> Get(){
       var records = await _UnitOfWork.Person.Find();
       return _Mapper.Map<List<Person>>(records);
    }

    [HttpGet("{id}")]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Person>> Get(string id){
       var record = await _UnitOfWork.Person.FindByStringId(id);
       if (record == null){
           return NotFound();
       }
       return _Mapper.Map<Person>(record);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<Person>>> Get11([FromQuery] PageParam param){
       IPager<Person> pager = await _UnitOfWork.Person.Find(param);
       pager.Records = (IEnumerable<Person>)_Mapper.Map<List<Person>>(pager.Records);        
       return CreatedAtAction("Person",pager);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Person>> Post(Person recordDto){
       var record = _Mapper.Map<Person>(recordDto);
       _UnitOfWork.Person.Add(record);
       await _UnitOfWork.SaveChanges();
       if (record == null){
           return BadRequest();
       }
       return CreatedAtAction(nameof(Post),new {id= record.IdPk, recordDto});
    }

    [HttpPut("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Person>> Put(string id, [FromBody]Person? recordDto){
       if(recordDto == null)
           return NotFound();
       var record = _Mapper.Map<Person>(recordDto);
       record.IdPk = id;
       _UnitOfWork.Person.Update(record);
       await _UnitOfWork.SaveChanges();
       return recordDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
       var record = await _UnitOfWork.Person.FindByStringId(id);
       if(record == null){
           return NotFound();
       }
       _UnitOfWork.Person.Remove(record);
       await _UnitOfWork.SaveChanges();
       return NoContent();
    }
}