using StudentAdmissionAppApi.Data.Contract;
using StudentAdmissionAppApi.Dtos;
using StudentAdmissionAppApi.Models;
using StudentAdmissionAppApi.Service.Contract;

namespace StudentAdmissionAppApi.Service.Implementation
{
    public class StandardService : IStandardService
    {
        private readonly IStandardRepository _standardRepository;

        public StandardService(IStandardRepository standardRepository)
        {
            _standardRepository = standardRepository;
        }

        public ServiceResponse<IEnumerable<StandardDto>> GetAllStandard(int page, int pageSize)
        {
            var response = new ServiceResponse<IEnumerable<StandardDto>>();
            var standards = _standardRepository.GetPaginatedStandards(page,pageSize);

            if (standards != null && standards.Any())
            {
                List<StandardDto> standardDtos = new List<StandardDto>();
                foreach (var standard in standards)
                {
                    standardDtos.Add(new StandardDto()
                    { 
                        StandardId = standard.StandardId,
                        StandardName = standard.StandardName,
                        ClassTeacherName = standard.ClassTeacherName 
                    });
                }
                response.Data = standardDtos;
            }
            else
            {
                response.Success = false;
                response.Message = "No record found!";
            }
            return response;
        }


        public ServiceResponse<IEnumerable<StandardDto>> GetAllStandardWithoutPage()
        {
            var response = new ServiceResponse<IEnumerable<StandardDto>>();
            var standards = _standardRepository.GetStandard();

            if (standards != null && standards.Any())
            {
                List<StandardDto> standardDtos = new List<StandardDto>();
                foreach (var standard in standards)
                {
                    standardDtos.Add(new StandardDto()
                    {
                        StandardId = standard.StandardId,
                        StageId = standard.StageId,
                        StageName = standard.Stage.StageName,
                        StageDescription = standard.Stage.StageDescription,
                        StandardName = standard.StandardName,
                        ClassTeacherName = standard.ClassTeacherName
                    });
                }
                response.Data = standardDtos;
            }
            else
            {
                response.Success = false;
                response.Message = "No record found!";
            }
            return response;
        }

        public ServiceResponse<IEnumerable<StandardDto>> StandardByStageId(int id)
        {
            var response = new ServiceResponse<IEnumerable<StandardDto>>();
            var standards = _standardRepository.GetStandardByStageId(id);

            if (standards != null && standards.Any())
            {
                List<StandardDto> standardDtos = new List<StandardDto>();
                foreach (var standard in standards)
                {
                    standardDtos.Add(new StandardDto() { StandardId = standard.StandardId, StandardName = standard.StandardName, ClassTeacherName = standard.ClassTeacherName });
                }
                response.Data = standardDtos;
            }
            else
            {
                response.Success = false;
                response.Message = "No record found!";
            }
            return response;
        }


    }
}
