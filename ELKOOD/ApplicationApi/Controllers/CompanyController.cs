using Application.Features.Company.Commands.AddProduction;
using Application.Features.Company.Commands.CreateCompany;
using Application.Features.Company.Commands.DeleteCompany;
using Application.Features.Company.Commands.UpdateCompany;
using Application.Features.Company.Queries.GetAllCompany;
using Application.Features.Company.Queries.GetCompanyDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name ="CreateCompany")]
        public async Task<ActionResult>CreateCompany(CreateCompanyCommand Company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(Company);
            return Ok(result);
        }
        [HttpPost("AddProduction", Name = "AddProduction")]
        public async Task<ActionResult> AddProduction(AddProductionCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _mediator.Send(model);
            return Ok();

        }
        [HttpPut(Name ="UpdateCompany")]
        public async Task<ActionResult>UpdateCompany(UpdateCompanyCommand Company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(Company);
            return Ok(result);
        }
        [HttpGet(Name = "GetCompanyDetails")]
        public async Task<ActionResult> GetCompanyDetails([FromQuery] GetCompanyDetailsQuery CompanyId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Company = await _mediator.Send(CompanyId);
            return Ok(Company);

        }
        [HttpGet("All", Name = "GetAllCompany")]
        public async Task<ActionResult> GetAllCompany([FromQuery] GetAllCompanyQuery model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpDelete(Name ="DeleteCompany")]
        public async Task<ActionResult>DeleteCompany(DeleteCompanyCommand Company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _mediator.Send(Company);
            return Ok();
        }
       
        
    }
}
