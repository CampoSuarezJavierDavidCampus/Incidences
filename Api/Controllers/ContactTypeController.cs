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
public class ContactTypeController : BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _Mapper;

    public ContactTypeController (IUnitOfWork unitOfWork,IMapper mapper){
        _UnitOfWork = unitOfWork;
        _Mapper = mapper;
    }

    [HttpGet]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<ContactTypeDto>> Get(){
       var records = await _UnitOfWork.ContactTypes.Find();
       return _Mapper.Map<List<ContactTypeDto>>(records);
    }

    [HttpGet("{id}")]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactTypeDto>> Get(int id){
       var record = await _UnitOfWork.ContactTypes.FindByIntId(id);
       if (record == null){
           return NotFound();
       }
       return _Mapper.Map<ContactTypeDto>(record);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ContactTypeDto>>> Get11([FromQuery] PageParam param){
       IPager<ContactType> pager = await _UnitOfWork.ContactTypes.Find(param);
       pager.Records = (IEnumerable<ContactType>)_Mapper.Map<List<ContactTypeDto>>(pager.Records);        
       return CreatedAtAction("ContactType",pager);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactTypeDto>> Post(ContactTypeDto recordDto){
       var record = _Mapper.Map<ContactType>(recordDto);
       _UnitOfWork.ContactTypes.Add(record);
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
    public async Task<ActionResult<ContactTypeDto>> Put(int id, [FromBody]ContactTypeDto? recordDto){
       if(recordDto == null)
           return NotFound();
       var record = _Mapper.Map<ContactType>(recordDto);
       record.IdPk = id;
       _UnitOfWork.ContactTypes.Update(record);
       await _UnitOfWork.SaveChanges();
       return recordDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
       var record = await _UnitOfWork.ContactTypes.FindByIntId(id);
       if(record == null){
           return NotFound();
       }
       _UnitOfWork.ContactTypes.Remove(record);
       await _UnitOfWork.SaveChanges();
       return NoContent();
    }
}