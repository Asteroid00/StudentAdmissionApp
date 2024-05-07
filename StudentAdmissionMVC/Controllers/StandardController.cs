using Microsoft.AspNetCore.Mvc;
using StudentAdmissionMVC.Infrastructure;
using StudentAdmissionMVC.ViewModels;

namespace StudentAdmissionMVC.Controllers
{
    public class StandardController : Controller
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;
        private string endPoint;

        public StandardController(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
            endPoint = _configuration["EndPoint:CivicaApi"];
        }

        [HttpGet]
        public IActionResult Index()
        {
            ServiceResponse<IEnumerable<StandardViewModel>> response = new ServiceResponse<IEnumerable<StandardViewModel>>();

            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<StandardViewModel>>>
                ($"{endPoint}Standard/GetAllStandardByPagination", HttpMethod.Get, HttpContext.Request);

            if (response.Success)
            {
                return View(response.Data);
            }

            return View(new List<StandardViewModel>());
        }


        [HttpGet]
        public IActionResult Index1()
        {
            ServiceResponse<IEnumerable<StandardTableViewModel>> response = new ServiceResponse<IEnumerable<StandardTableViewModel>>();

            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<StandardTableViewModel>>>
                ($"{endPoint}Standard/GetAllStandardWithoutPage", HttpMethod.Get, HttpContext.Request);

            if (response.Success)
            {
                return View(response.Data);
            }

            return View(new List<StandardTableViewModel>());
        }


    }
}
