using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentAdmissionMVC.Infrastructure;
using StudentAdmissionMVC.ViewModels;

namespace StudentAdmissionMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;
        private string endPoint;

        public StudentController(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
            endPoint = _configuration["EndPoint:CivicaApi"];
        }

        [HttpGet]
        public IActionResult Index()
        {
            ServiceResponse<IEnumerable<StudentViewModel>> response = new ServiceResponse<IEnumerable<StudentViewModel>>();

            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<StudentViewModel>>>
                ($"{endPoint}Student/GetAllStudents", HttpMethod.Get, HttpContext.Request);

            if (response.Success)
            {
                return View(response.Data);
            }

            return View(new List<StudentViewModel>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Stages = GetAllStages();
            return View(studentViewModel);
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string apiUrl = $"{endPoint}Student/AddStudent";
                var response = _httpClientService.PostHttpResponseMessage(apiUrl, viewModel, HttpContext.Request);
                if (response.IsSuccessStatusCode)
                {
                    string successResponse = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(successResponse);
                    TempData["successMessage"] = serviceResponse.Message;

                    return RedirectToAction("Index");

                }
                else
                {
                    string errorMessage = response.Content.ReadAsStringAsync().Result;
                    var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(errorMessage);
                    if (errorMessage != null)
                    {
                        TempData["errorMessage"] = errorResponse.Message;
                    }
                    else
                    {
                        TempData["errorMessage"] = "Something went wrong. Please try after sometime.";
                    }

                }
                return RedirectToAction("Index");
            }
            viewModel.Stages = GetAllStages();
            return View(viewModel);
        }


        [HttpGet]
        private List<StandardStageViewModel> GetAllStages()
        {
            ServiceResponse<IEnumerable<StandardStageViewModel>> response = new ServiceResponse<IEnumerable<StandardStageViewModel>>();

            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<StandardStageViewModel>>>
                ($"{endPoint}Stage/GetAll", HttpMethod.Get, HttpContext.Request);

            if (response.Success)
            {
                return response.Data.ToList();
            }

            return new List<StandardStageViewModel>();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var apiUrl = $"{endPoint}Student/GetStudentById/" + id;
            var response = _httpClientService.GetHttpResponseMessage<UpdateStudentViewModel>(apiUrl, HttpContext.Request);

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<UpdateStudentViewModel>>(data);

                if (serviceResponse != null && serviceResponse.Success && serviceResponse.Data != null)
                {
                    return View(serviceResponse.Data);
                }
                else
                {
                    TempData["errorMessage"] = serviceResponse.Message;
                    return RedirectToAction("Index");
                }

            }
            else
            {
                string errorData = response.Content.ReadAsStringAsync().Result;
                var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<UpdateStudentViewModel>>(errorData);

                if (errorResponse != null)
                {
                    TempData["errorMessage"] = errorResponse.Message;
                }
                else
                {
                    TempData["errorMessage"] = "Something went wrong. Please try after sometime.";
                }
                return RedirectToAction("Index");
            }


        }

        [HttpPost]
        public IActionResult Edit(UpdateStudentViewModel updateStudent)
        {
            if (ModelState.IsValid)
            {

                var apiUrl = $"{endPoint}Student/UpdateStudent";
                HttpResponseMessage response = _httpClientService.PutHttpResponseMessage(apiUrl, updateStudent, HttpContext.Request);
                if (response.IsSuccessStatusCode)
                {
                    string successResponse = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(successResponse);
                    TempData["successMessage"] = serviceResponse.Message;

                    return RedirectToAction("Index");


                }
                else
                {
                    string errorMessage = response.Content.ReadAsStringAsync().Result;
                    var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(errorMessage);
                    if (errorMessage != null)
                    {
                        TempData["errorMessage"] = errorResponse.Message;
                    }
                    else
                    {
                        TempData["errorMessage"] = "Something went wrong. Please try after sometime.";
                    }

                }
            }
            return View(updateStudent);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var apiUrl = $"{endPoint}Student/GetStudentById/" + id;
            var response = _httpClientService.GetHttpResponseMessage<UpdateStudentViewModel>(apiUrl, HttpContext.Request);
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<UpdateStudentViewModel>>(data);
                if (serviceResponse != null && serviceResponse.Success && serviceResponse.Data != null)
                {
                    return View(serviceResponse.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = serviceResponse.Message;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                string errorData = response.Content.ReadAsStringAsync().Result;
                var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<UpdateStudentViewModel>>(errorData);
                if (errorResponse != null)
                {
                    TempData["ErrorMessage"] = errorResponse.Message;
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong.Please try after sometime.";
                }
                return RedirectToAction("Index");
            }

        }


    }
}
