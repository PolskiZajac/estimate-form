using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using EFDataAccessLibrary.Features.Estimates;
using WebAPI.Commands;
using WebAPI.Queries;

namespace WebAPI.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimatesModel : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public EstimatesModel(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstimateDto>>> Get()
        {
            var query = new GetAllEstimatesQuery();
            var result = await _mediator.Send(query);
            return Ok(_mapper.Map<List<Estimate>, List<EstimateDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstimateDto>> Get(int id)
        {
            var query = new GetEstimateByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(_mapper.Map<EstimateDto>(result));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Estimate estimate)
        {
            var command = new CreateEstimateCommand(estimate);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Estimate estimate)
        {
            var command = new UpdateEstimateByIdCommand(id, estimate);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteEstimateByIdCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
