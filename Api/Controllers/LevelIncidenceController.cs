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
public class LevelIncidenceController : BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _Mapper;

    public LevelIncidenceController (IUnitOfWork unitOfWork,IMapper mapper){
        _UnitOfWork = unitOfWork;
        _Mapper = mapper;
    }

    [HttpGet]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<LevelIncidenceDto>> Get(){
       var records = await _UnitOfWork.LevelIncidences.Find();
       return _Mapper.Map<List<LevelIncidenceDto>>(records);
    }

    [HttpGet("{id}")]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LevelIncidenceDto>> Get(int id){
       var record = await _UnitOfWork.LevelIncidences.FindByIntId(id);
       if (record == null){
           return NotFound();
       }
       return _Mapper.Map<LevelIncidenceDto>(record);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<LevelIncidenceDto>>> Get11([FromQuery] PageParam param){
       IPager<LevelIncidence> pager = await _UnitOfWork.LevelIncidences.Find(param);
       pager.Records = (IEnumerable<LevelIncidence>)_Mapper.Map<List<LevelIncidenceDto>>(pager.Records);        
       return CreatedAtAction("LevelIncidence",pager);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LevelIncidenceDto>> Post(LevelIncidenceDto recordDto){
       var record = _Mapper.Map<LevelIncidence>(recordDto);
       _UnitOfWork.LevelIncidences.Add(record);
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
    public async Task<ActionResult<LevelIncidenceDto>> Put(int id, [FromBody]LevelIncidenceDto? recordDto){
       if(recordDto == null)
           return NotFound();
       var record = _Mapper.Map<LevelIncidence>(recordDto);
       record.IdPk = id;
       _UnitOfWork.LevelIncidences.Update(record);
       await _UnitOfWork.SaveChanges();
       return recordDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
       var record = await _UnitOfWork.LevelIncidences.FindByIntId(id);
       if(record == null){
           return NotFound();
       }
       _UnitOfWork.LevelIncidences.Remove(record);
       await _UnitOfWork.SaveChanges();
       return NoContent();
    }
}