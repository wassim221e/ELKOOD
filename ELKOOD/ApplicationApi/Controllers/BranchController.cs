using Application.Features.MainBranch.Commands.AddBasicProduction;
using Application.Features.MainBranch.Commands.AddDistribution;
using Application.Features.MainBranch.Commands.CreateMainBranch;
using Application.Features.MainBranch.Commands.DeleteMainBranch;
using Application.Features.MainBranch.Commands.UpdateMainBranch;
using Application.Features.MainBranch.Queries.GetAllDistribution;
using Application.Features.MainBranch.Queries.GetAllMainBranch;
using Application.Features.MainBranch.Queries.GetBasicProductionRange;
using Application.Features.MainBranch.Queries.GetMainBranchDetails;
using Application.Features.SecondaryBranch.Commands.CreateSecondaryBranch;
using Application.Features.SecondaryBranch.Commands.DeleteSecondaryBranch;
using Application.Features.SecondaryBranch.Commands.UpdateSecondaryBranch;
using Application.Features.SecondaryBranch.Queries.GetAllSecondaryBranch;
using Application.Features.SecondaryBranch.Queries.GetSecondaryBranchDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;

namespace ApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : Controller
    {
        private readonly IMediator _mediator;

        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("MainBranch", Name = "CreateMainBranch")]
        public async Task<ActionResult> CreateBranch(CreateMainBranchCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var mainBranch = await _mediator.Send(model);
            return Ok(mainBranch);
        }
        [HttpPost("SecondaryBranch", Name = "CreateSecondaryBranch")]
        public async Task<ActionResult> CreateSecondaryBranch(CreateSecondaryBranchCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var mainBranch = await _mediator.Send(model);
            return Ok(mainBranch);
        }
        [HttpPost("MainBranch/BasicProduction", Name = "AddBasicProduction")]
        public async Task<ActionResult> AddBasicProduction(AddBasicProductionCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _mediator.Send(model);
            return Ok();
        }
        [HttpPost("MainBranch/Distribution", Name = "AddDistribution")]
        public async Task<ActionResult> AddDistribution(AddDistributionQuery model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _mediator.Send(model);
            return Ok();
        }
        [HttpPut("MainBranch", Name = "UpdateMainBranch")]
        public async Task<ActionResult> UpdateBranch([FromForm]UpdateMainBranchCommand model)
        {

            await _mediator.Send(model);
            return Ok();
        }
        [HttpPut("SecondaryBranch", Name = "UpdateSecondaryBranch")]
        public async Task<ActionResult> UpdateSecondaryBranch([FromForm] UpdateSecondaryBranchCommand model)
        {

            await _mediator.Send(model);
            return Ok();
        }
        [HttpGet("MainBranch/Details", Name = "GetMainBranchDetails")]
        public async Task<ActionResult> GetMainBranchDetails([FromQuery] GetMainBranchDetailsQuery model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _mediator.Send(model));
        }

        [HttpGet("MainBranch/All", Name = "GetAllMainBranch")]
        public async Task<ActionResult> GetAllBranch([FromQuery] GetAllMainBranchQuery model)
        {
            var MainBranchViewModels = await _mediator.Send(model);
            return Ok(MainBranchViewModels);
        }

        [HttpGet("SecondaryBranch/Details", Name = "GetSecondaryBranchDetails")]
        public async Task<ActionResult> GetSecondaryBranchDetails([FromQuery] GetSecondaryBranchDetailsQuery model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Branch = await _mediator.Send(model);
            return Ok(Branch);
        }
        [HttpGet("SecondaryBranch/All", Name = "GetAllSecondaryBranch")]
        public async Task<ActionResult> GetallSecondaryBranch([FromQuery] GetAllSecondaryBranchQuery model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _mediator.Send(model));

        }

        [HttpGet("MainBranch/AmountRange", Name = "GetAmountOfDateRange")]
        public async Task<ActionResult> GetAmountOfDateRange([FromQuery] GetBasicProductionRangeQuery model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("MainBranch/Distribution/all",Name ="GetAllDistribution")]
        public async Task<ActionResult> GetAllDistribution([FromQuery]GetAllDistributionQuery model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _mediator.Send(model));
           
        }
        [HttpDelete("MainBranch", Name = "DeleteMainBranch")]
        public async Task<ActionResult> DeleteBranch([FromQuery] DeleteMainBranchCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _mediator.Send(model);
            return Ok();
        }
        [HttpDelete("SecondaryBranch",Name ="DeleteSecondaryBranch")]
        public async Task<ActionResult> DeleteSecondaryBranch([FromQuery]DeleteSecondaryBranchCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _mediator.Send(model);
            return Ok();
                
        }
    }
}
