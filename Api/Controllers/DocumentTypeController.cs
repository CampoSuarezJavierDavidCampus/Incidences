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
public class DocumentTypeController : BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _Mapper;

    public DocumentTypeController (IUnitOfWork unitOfWork,IMapper mapper){
        _UnitOfWork = unitOfWork;
        _Mapper = mapper;
    }

    [HttpGet]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<DocumentTypeDto>> Get(){
       var records = await _UnitOfWork.DocumentTypes.Find();
       return _Mapper.Map<List<DocumentTypeDto>>(records);
    }

    [HttpGet("{id}")]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocumentTypeDto>> Get(int id){
       var record = await _UnitOfWork.DocumentTypes.FindByIntId(id);
       if (record == null){
           return NotFound();
       }
       return _Mapper.Map<DocumentTypeDto>(record);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DocumentTypeDto>>> Get11([FromQuery] PageParam param){
       IPager<DocumentType> pager = await _UnitOfWork.DocumentTypes.Find(param);
       pager.Records = (IEnumerable<DocumentType>)_Mapper.Map<List<DocumentTypeDto>>(pager.Records);        
       return CreatedAtAction("DocumentType",pager);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocumentTypeDto>> Post(DocumentTypeDto recordDto){
       var record = _Mapper.Map<DocumentType>(recordDto);
       _UnitOfWork.DocumentTypes.Add(record);
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
    public async Task<ActionResult<DocumentTypeDto>> Put(int id, [FromBody]DocumentTypeDto? recordDto){
       if(recordDto == null)
           return NotFound();
       var record = _Mapper.Map<DocumentType>(recordDto);
       record.IdPk = id;
       _UnitOfWork.DocumentTypes.Update(record);
       await _UnitOfWork.SaveChanges();
       return recordDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
       var record = await _UnitOfWork.DocumentTypes.FindByIntId(id);
       if(record == null){
           return NotFound();
       }
       _UnitOfWork.DocumentTypes.Remove(record);
       await _UnitOfWork.SaveChanges();
       return NoContent();
    }
}