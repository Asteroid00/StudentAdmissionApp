using Microsoft.AspNetCore.Mvc;
using StudentAdmissionMVC.Infrastructure;
using StudentAdmissionMVC.ViewModels;

namespace StudentAdmissionMVC.Controllers
{
    public class ReportController : Controller
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;
        private string endPoint;

        public ReportController(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
            endPoint = _configuration["EndPoint:CivicaApi"];
        }

        [HttpGet]
        public IActionResult Index()
        {
            ServiceResponse<IEnumerable<ReportViewModel>> response = new ServiceResponse<IEnumerable<ReportViewModel>>();

            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<ReportViewModel>>>
                ($"{endPoint}Student/GetAdmissionReport", HttpMethod.Get, HttpContext.Request);

            if (response.Success)
            {
                return View(response.Data);
            }

            return View(new List<ReportViewModel>());
        }
    }
}
