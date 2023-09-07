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
[ApiVersion("1.1")]
public class CategoryContactController : BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _Mapper;

    public CategoryContactController (IUnitOfWork unitOfWork,IMapper mapper){
        _UnitOfWork = unitOfWork;
        _Mapper = mapper;
    }

    [HttpGet]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<CategoryContactDto>> Get(){
       var records = await _UnitOfWork.CategoryContacts.Find();
       return _Mapper.Map<List<CategoryContactDto>>(records);
    }

    [HttpGet("{id}")]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryContactDto>> Get(int id){
       var record = await _UnitOfWork.CategoryContacts.FindByIntId(id);
       if (record == null){
           return NotFound();
       }
       return _Mapper.Map<CategoryContactDto>(record);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CategoryContactDto>>> Get11([FromQuery] PageParam param){
       IPager<CategoryContact> pager = await _UnitOfWork.CategoryContacts.Find(param);
       pager.Records = (IEnumerable<CategoryContact>)_Mapper.Map<List<CategoryContactDto>>(pager.Records);        
       return CreatedAtAction("CategoryContact",pager);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryContactDto>> Post(CategoryContactDto recordDto){
       var record = _Mapper.Map<CategoryContact>(recordDto);
       _UnitOfWork.CategoryContacts.Add(record);
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
    public async Task<ActionResult<CategoryContactDto>> Put(int id, [FromBody]CategoryContactDto? recordDto){
       if(recordDto == null)
           return NotFound();
       var record = _Mapper.Map<CategoryContact>(recordDto);
       record.IdPk = id;
       _UnitOfWork.CategoryContacts.Update(record);
       await _UnitOfWork.SaveChanges();
       return recordDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
       var record = await _UnitOfWork.CategoryContacts.FindByIntId(id);
       if(record == null){
           return NotFound();
       }
       _UnitOfWork.CategoryContacts.Remove(record);
       await _UnitOfWork.SaveChanges();
       return NoContent();
    }
}