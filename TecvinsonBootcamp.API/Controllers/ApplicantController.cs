using FluentValidation;
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
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Add(ApplicantCreateReq req)
        {
            // validate request
            var validationResult = _createValidator.Validate(req);
            if (validationResult != null)
            {
                return BadRequest(validationResult);
            }
            await _applicantService.Add(req);

            return Created();
        }

        [Route("GetById", Name ="GetById")]
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ApplicantDto>> GetById(Guid id)
        {
            var applicant = await _applicantService.GetApplicantById(id);

            return Ok(applicant);
        }


        [Route("GetAll", Name ="GetAll")]
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<ApplicantDto>>> GetAll()
        {
            return Ok(await _applicantService.GetAllApplicants());
        }


        [Route("Update", Name = "Update")]
        [HttpPut]
        [ProducesResponseType<ApplicantUpdateReq>(201)]
        [ProducesResponseType<ApplicantUpdateReq>(500)]
        [ProducesResponseType<ApplicantUpdateReq>(503)]
        [ProducesResponseType<ApplicantUpdateReq>(400)]
        public async Task<ActionResult<ApplicantDto>> Update(ApplicantUpdateReq req)
        {
            var validateResult = _updateValidator.Validate(req);
            if (validateResult != null)
            {
                return BadRequest(validateResult);
            }
            return Ok(await _applicantService.Update(req));
        }

        [Route("Delete", Name = "Delete")]
        [HttpDelete]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _applicantService.Delete(id);
            return Accepted();
        }

    }
}
