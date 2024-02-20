using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly IValidator<ApplicantCreateReq> _createValidator;
        private readonly IValidator<ApplicantUpdateReq> _updateValidator;

        public ApplicantController(IApplicantService applicantService, ILogger<ApplicantController> logger, IValidator<ApplicantCreateReq> createValidator, IValidator<ApplicantUpdateReq> updateValidator)
        {
            _applicantService = applicantService;
            _logger = logger;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [Route("Add", Name = "Add")]
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ApplicantCreateReq req)
        {
            // validate request
            var validationResult = _createValidator.Validate(req);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            await _applicantService.Add(req);

            return Created();
        }

        [Route("GetById", Name ="GetById")]
        [HttpGet]
        public async Task<ActionResult<ApplicantDto>> GetById([FromQuery] Guid id)
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
        public async Task<ActionResult<ApplicantDto>> Update(Guid Id, [FromBody] ApplicantUpdateReq req)
        {
            var validationResult = _updateValidator.Validate(req);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            var updateApplicant = await _applicantService.Update(req);
            if (updateApplicant is null)
            {
                return BadRequest();
            }
            return Ok(updateApplicant);
        }

        [Route("Delete", Name = "Delete")]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Guid id)
        {
            await _applicantService.Delete(id);
            return Accepted();
        }

    }
}
