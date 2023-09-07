using Api.Controllers;
using Api.Dtos;
using AutoMapper;
using Api.Helpers.Paginator;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Domain.Interface.Pagination;
using Microsoft.AspNetCore.Authorization;

namespace ApiIncidencias.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class AreaController : BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _Mapper;

    public AreaController (IUnitOfWork unitOfWork,IMapper mapper){
        _UnitOfWork = unitOfWork;
        _Mapper = mapper;
    }

    [HttpGet]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<AreaDto>> Get(){
       var records = await _UnitOfWork.Areas.Find();
       return _Mapper.Map<List<AreaDto>>(records);
    }

    [HttpGet("{id}")]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaDto>> Get(int id){
       var record = await _UnitOfWork.Areas.FindByIntId(id);
       if (record == null){
           return NotFound();
       }
       return _Mapper.Map<AreaDto>(record);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IPager<Area>>> Get11([FromQuery] PageParam param){
       IPager<Area> pager = await _UnitOfWork.Areas.Find(param);
       IPager<AreaDto> pagerDto = new Pager<AreaDto>(_Mapper.Map<List<AreaDto>>(pager.Records),param);       
       return CreatedAtAction(nameof(Get),pagerDto);
    }

    [HttpPost]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaDto>> Post(AreaDto recordDto){
       var record = _Mapper.Map<Area>(recordDto);
       _UnitOfWork.Areas.Add(record);
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
    public async Task<ActionResult<AreaDto>> Put(int id, [FromBody]AreaDto? recordDto){
       if(recordDto == null)
           return NotFound();
       var record = _Mapper.Map<Area>(recordDto);
       record.IdPk = id;
       _UnitOfWork.Areas.Update(record);
       await _UnitOfWork.SaveChanges();
       return recordDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
       var record = await _UnitOfWork.Areas.FindByIntId(id);
       if(record == null){
           return NotFound();
       }
       _UnitOfWork.Areas.Remove(record);
       await _UnitOfWork.SaveChanges();
       return NoContent();
    }
}