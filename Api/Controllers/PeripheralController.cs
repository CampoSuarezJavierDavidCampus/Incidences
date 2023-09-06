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
public class PeripheralController : BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _Mapper;

    public PeripheralController (IUnitOfWork unitOfWork,IMapper mapper){
        _UnitOfWork = unitOfWork;
        _Mapper = mapper;
    }

    [HttpGet]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<PeripheralDto>> Get(){
       var records = await _UnitOfWork.Peripherals.Find();
       return _Mapper.Map<List<PeripheralDto>>(records);
    }

    [HttpGet("{id}")]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PeripheralDto>> Get(int id){
       var record = await _UnitOfWork.Peripherals.FindByIntId(id);
       if (record == null){
           return NotFound();
       }
       return _Mapper.Map<PeripheralDto>(record);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PeripheralDto>>> Get11([FromQuery] PageParam param){
       IPager<Peripheral> pager = await _UnitOfWork.Peripherals.Find(param);
       pager.Records = (IEnumerable<Peripheral>)_Mapper.Map<List<PeripheralDto>>(pager.Records);        
       return CreatedAtAction("Peripheral",pager);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PeripheralDto>> Post(PeripheralDto recordDto){
       var record = _Mapper.Map<Peripheral>(recordDto);
       _UnitOfWork.Peripherals.Add(record);
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
    public async Task<ActionResult<PeripheralDto>> Put(int id, [FromBody]PeripheralDto? recordDto){
       if(recordDto == null)
           return NotFound();
       var record = _Mapper.Map<Peripheral>(recordDto);
       record.IdPk = id;
       _UnitOfWork.Peripherals.Update(record);
       await _UnitOfWork.SaveChanges();
       return recordDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
       var record = await _UnitOfWork.Peripherals.FindByIntId(id);
       if(record == null){
           return NotFound();
       }
       _UnitOfWork.Peripherals.Remove(record);
       await _UnitOfWork.SaveChanges();
       return NoContent();
    }
}