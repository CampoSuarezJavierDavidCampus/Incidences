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
public class TypeIncidenceController : BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _Mapper;

    public TypeIncidenceController (IUnitOfWork unitOfWork,IMapper mapper){
        _UnitOfWork = unitOfWork;
        _Mapper = mapper;
    }

    [HttpGet]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<TypeIncidence>> Get(){
       var records = await _UnitOfWork.TypeIncidences.Find();
       return _Mapper.Map<List<TypeIncidence>>(records);
    }

    [HttpGet("{id}")]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TypeIncidence>> Get(int id){
       var record = await _UnitOfWork.TypeIncidences.FindByIntId(id);
       if (record == null){
           return NotFound();
       }
       return _Mapper.Map<TypeIncidence>(record);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TypeIncidence>>> Get11([FromQuery] PageParam param){
       IPager<TypeIncidence> pager = await _UnitOfWork.TypeIncidences.Find(param);
       pager.Records = (IEnumerable<TypeIncidence>)_Mapper.Map<List<TypeIncidence>>(pager.Records);        
       return CreatedAtAction("TypeIncidence",pager);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TypeIncidence>> Post(TypeIncidence recordDto){
       var record = _Mapper.Map<TypeIncidence>(recordDto);
       _UnitOfWork.TypeIncidences.Add(record);
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
    public async Task<ActionResult<TypeIncidence>> Put(int id, [FromBody]TypeIncidence? recordDto){
       if(recordDto == null)
           return NotFound();
       var record = _Mapper.Map<TypeIncidence>(recordDto);
       record.IdPk = id;
       _UnitOfWork.TypeIncidences.Update(record);
       await _UnitOfWork.SaveChanges();
       return recordDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
       var record = await _UnitOfWork.TypeIncidences.FindByIntId(id);
       if(record == null){
           return NotFound();
       }
       _UnitOfWork.TypeIncidences.Remove(record);
       await _UnitOfWork.SaveChanges();
       return NoContent();
    }
}