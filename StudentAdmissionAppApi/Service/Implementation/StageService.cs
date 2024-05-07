using StudentAdmissionAppApi.Data.Contract;
using StudentAdmissionAppApi.Dtos;
using StudentAdmissionAppApi.Service.Contract;

namespace StudentAdmissionAppApi.Service.Implementation
{
    public class StageService : IStageService
    {
        private readonly IStageRepository _stageRepository;

        public StageService(IStageRepository stageRepository)
        {
            _stageRepository = stageRepository;
        }

        public ServiceResponse<IEnumerable<StageDto>> GetAllStages()
        {
            var response = new ServiceResponse<IEnumerable<StageDto>>();

            var stages = _stageRepository.GetStage();

            if (stages != null && stages.Any())
            {
                List<StageDto> stageDtos = new List<StageDto>();
                foreach (var stage in stages)
                {
                    stageDtos.Add(new StageDto() { StageId = stage.StageId, StageName = stage.StageName, StageDescription = stage.StageDescription });
                }
                response.Data = stageDtos;
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
