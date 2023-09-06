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
public class DetailIncidenceController : BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _Mapper;

    public DetailIncidenceController (IUnitOfWork unitOfWork,IMapper mapper){
        _UnitOfWork = unitOfWork;
        _Mapper = mapper;
    }

    [HttpGet]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<DetailIncidence>> Get(){
       var records = await _UnitOfWork.DetailIncidences.Find();
       return _Mapper.Map<List<DetailIncidence>>(records);
    }

    [HttpGet("{id}")]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetailIncidence>> Get(int id){
       var record = await _UnitOfWork.DetailIncidences.FindByIntId(id);
       if (record == null){
           return NotFound();
       }
       return _Mapper.Map<DetailIncidence>(record);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DetailIncidence>>> Get11([FromQuery] PageParam param){
       IPager<DetailIncidence> pager = await _UnitOfWork.DetailIncidences.Find(param);
       pager.Records = (IEnumerable<DetailIncidence>)_Mapper.Map<List<DetailIncidence>>(pager.Records);        
       return CreatedAtAction("DetailIncidence",pager);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetailIncidence>> Post(DetailIncidence recordDto){
       var record = _Mapper.Map<DetailIncidence>(recordDto);
       _UnitOfWork.DetailIncidences.Add(record);
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
    public async Task<ActionResult<DetailIncidence>> Put(int id, [FromBody]DetailIncidence? recordDto){
       if(recordDto == null)
           return NotFound();
       var record = _Mapper.Map<DetailIncidence>(recordDto);
       record.IdPk = id;
       _UnitOfWork.DetailIncidences.Update(record);
       await _UnitOfWork.SaveChanges();
       return recordDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
       var record = await _UnitOfWork.DetailIncidences.FindByIntId(id);
       if(record == null){
           return NotFound();
       }
       _UnitOfWork.DetailIncidences.Remove(record);
       await _UnitOfWork.SaveChanges();
       return NoContent();
    }
}