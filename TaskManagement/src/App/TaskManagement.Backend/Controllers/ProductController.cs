using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using TaskManagement.Core.Product.Command;
using TaskManagement.Core.Product.Query;
using TaskManagement.Services.Model;

namespace TaskManagement.Backend.Controllers;



[Route("api/[controller]")]
[ApiController]
public class ProductController :ControllerBase
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;   
    }
    [HttpGet]   
    public async Task <ActionResult<VmProduct>> Get()
    {
        var data = await _mediator.Send(new GetAllProductQuery());
        return Ok(data);    
    }
    [HttpGet("Id")]
    public async Task<ActionResult <VmProduct>>Get(int Id)
    {
        var data = await _mediator.Send (new GetProductById(Id));
        return Ok(data);    
    }
    [HttpPost]

    public async Task <ActionResult <VmProduct>>PostAsync([FromBody]VmProduct vmProduct)
    {
        var data = await _mediator.Send(new CreateProduct(vmProduct));
        return Ok(data);
    }
    [HttpPut("Id")]

    public async Task<ActionResult<VmProduct>> PutAsync(int id,[FromBody] VmProduct vmProduct)
    {
        var data = await _mediator.Send(new UpdateProduct(id,vmProduct));
        return Ok(data);
    }
    [HttpDelete("id")]
    public async Task<ActionResult<VmProduct>> DeleteAsync(int id)
    {
        var data = await _mediator.Send(new DeleteProduct(id));
        return Ok(data);
    }
}