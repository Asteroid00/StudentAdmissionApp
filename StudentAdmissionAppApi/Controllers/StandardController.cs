using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdmissionAppApi.Models;
using StudentAdmissionAppApi.Service.Contract;
using StudentAdmissionAppApi.Service.Implementation;

namespace StudentAdmissionAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardController : ControllerBase
    {
        private readonly IStandardService _standardService;

        public StandardController(IStandardService standardService)
        {
            _standardService = standardService;
        }

        [HttpGet("GetAllStandardByPagination")]

        public IActionResult GetAllStandardByPagination(int page , int pageSize)
        {
            var response = _standardService.GetAllStandard(page,pageSize);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetAllStandardByStageId")]

        public IActionResult GetAllStandardByStageId(int stageId)
        {
            var response = _standardService.StandardByStageId(stageId);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetAllStandardWithoutPage")]

        public IActionResult GetAllStandardWithoutPage()
        {
            var response = _standardService.GetAllStandardWithoutPage();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
