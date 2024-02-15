using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TecvinsonBootcamp.Domain.Entities;
using TecvinsonBootcamp.Services.Contracts;
using TecvinsonBootcamp.Services.Interfaces;

namespace TecvinsonBootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        private readonly ILogger<ApplicantController> _logger;
        public ApplicantController(IApplicantService applicantService, ILogger<ApplicantController> logger)
        {
            _applicantService = applicantService;
            _logger = logger;

        }

        [Route("Add", Name = "Add")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<ActionResult> Add(ApplicantCreateReq req)
        {
            await _applicantService.Add(req);
            return Ok();
        }

        [Route("GetById", Name ="GetById")]
        [HttpGet]
        public async Task<ActionResult<ApplicantDto>> GetById(Guid id)
        {
            var applicant = await _applicantService.GetApplicantById(id);

            return Ok(applicant);

        }

        [Route("GetAll", Name ="GetAll")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicantDto>>> GetAll()
        {
            return Ok(await _applicantService.GetAllApplicants());
        }

        [Route("Update", Name = "Update")]
        [HttpPut]
        public async Task<ActionResult<ApplicantDto>> Update(ApplicantUpdateReq req)
        {
            return Ok(await _applicantService.Update(req));
        }

        [Route("Delete", Name = "Delete")]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _applicantService.Delete(id);
            return Accepted();
        }

    }
}
