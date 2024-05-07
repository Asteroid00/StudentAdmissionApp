using StudentAdmissionAppApi.Dtos;

namespace StudentAdmissionAppApi.Service.Contract
{
    public interface IStageService
    {
        ServiceResponse<IEnumerable<StageDto>> GetAllStages();
    }
}
