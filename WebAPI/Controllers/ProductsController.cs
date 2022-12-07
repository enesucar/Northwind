using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Repository;
using WebAPI.Entities;
using MediatR;
using WebAPI.Features.Products.Queries.GetListProduct;
using WebAPI.Features.Products.Commands.CreateCreateOrderCommandRequestProduct;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList()
        {
            var query = await _mediator.Send(new GetAllProductQueryRequest() { BypassCache = false });
            return Ok(query);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CreateProductCommandRequest request)
        {
            var query = await _mediator.Send(request);
            return Ok(query);
        }
    }
}
