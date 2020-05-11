using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nuance.NPA.Domain.Source.Interface.Business;
using Nuance.NPA.DTO;

namespace Nuance.NPA.API.Source.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SourceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISourceDomainService _sourceDomainService;
        private readonly ILogger<SourceController> _logger;
        private readonly Guid _fakeUser = Guid.NewGuid();

        public SourceController(ILogger<SourceController> logger, IMapper mapper, ISourceDomainService sourceDomainService)
        {
            _logger = logger;
            _sourceDomainService = sourceDomainService;
            _mapper = mapper;
        }


        /// <summary>
        /// Returns a news list that matches with the filtered criteria
        /// 2. Design registering to a news sources to get the news content
        /// </summary>
        /// <param name="sourceDto"></param>
        /// <response code="200">Returns a List of the filtered news.</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SourceDto sourceDto = null)
        {
            sourceDto.UserId = _fakeUser;
            var source = await _sourceDomainService.RegistrationAsync(sourceDto);
            return Ok(source);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            SourceDto sourceDto = new SourceDto();
            var list = await _sourceDomainService.GetSoruceAsync(sourceDto);
            return Ok(list);
        }
    }
}
