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
public class PlaceController : BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _Mapper;

    public PlaceController (IUnitOfWork unitOfWork,IMapper mapper){
        _UnitOfWork = unitOfWork;
        _Mapper = mapper;
    }

    [HttpGet]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<PlaceDto>> Get(){
       var records = await _UnitOfWork.Places.Find();
       return _Mapper.Map<List<PlaceDto>>(records);
    }

    [HttpGet("{id}")]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PlaceDto>> Get(int id){
       var record = await _UnitOfWork.Places.FindByIntId(id);
       if (record == null){
           return NotFound();
       }
       return _Mapper.Map<PlaceDto>(record);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PlaceDto>>> Get11([FromQuery] PageParam param){
       IPager<Place> pager = await _UnitOfWork.Places.Find(param);
       pager.Records = (IEnumerable<Place>)_Mapper.Map<List<PlaceDto>>(pager.Records);        
       return CreatedAtAction("Place",pager);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PlaceDto>> Post(PlaceDto recordDto){
       var record = _Mapper.Map<Place>(recordDto);
       _UnitOfWork.Places.Add(record);
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
    public async Task<ActionResult<PlaceDto>> Put(int id, [FromBody]PlaceDto? recordDto){
       if(recordDto == null)
           return NotFound();
       var record = _Mapper.Map<Place>(recordDto);
       record.IdPk = id;
       _UnitOfWork.Places.Update(record);
       await _UnitOfWork.SaveChanges();
       return recordDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
       var record = await _UnitOfWork.Places.FindByIntId(id);
       if(record == null){
           return NotFound();
       }
       _UnitOfWork.Places.Remove(record);
       await _UnitOfWork.SaveChanges();
       return NoContent();
    }
}