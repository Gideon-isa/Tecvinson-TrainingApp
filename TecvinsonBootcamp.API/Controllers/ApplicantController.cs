using FluentValidation;
using Microsoft.AspNetCore.Mvc;
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
            _logger.LogInformation($"initializing the creation of a new applicant");
            // validate request
            var validationResult = _createValidator.Validate(req);
            if (!validationResult.IsValid)
            {
                _logger.LogInformation($"unable to create user, invalid users input");
                return BadRequest(validationResult);  
            }

            try
            {
                _logger.LogInformation("trying to add applicant");
                await _applicantService.Add(req);
            }
            catch (Exception e)
            {
                _logger.LogError("unable to create user, invalid users input");
                return UnprocessableEntity(e);
                //throw;
            }

            _logger.LogInformation("applicant created successfully");
            return Created();
        }

        [Route("GetById", Name ="GetById")]
        [HttpGet]
        public async Task<ActionResult<ApplicantDto>> GetById([FromQuery] Guid id)
        {
            ApplicantDto applicant = null;
            try
            {
                applicant = await _applicantService.GetApplicantById(id);
            }
            catch (Exception e)
            {
                _logger.LogInformation("");
            }
            
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
        public async Task<ActionResult<ApplicantDto>> Update([FromBody] ApplicantUpdateReq req)
        {
            var validationResult = _updateValidator.Validate(req);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            ApplicantDto updateApplicant;

            try
            {
                updateApplicant = await _applicantService.Update(req);
            }
            catch (ArgumentNullException a)
            {
                _logger.LogInformation("wrong employment status entry");
                _logger.LogError("employment status entered not recognized");
                return BadRequest("employment status entered not recognized");
            }
            catch (NullReferenceException n)
            {
                _logger.LogInformation($" {n.Message}, User with {req.Id} was not found");
                return BadRequest($" {n.Message}, User with {req.Id} was not found");
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest(req);
            }
           

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
