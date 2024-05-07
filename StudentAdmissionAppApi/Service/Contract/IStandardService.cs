using StudentAdmissionAppApi.Dtos;

namespace StudentAdmissionAppApi.Service.Contract
{
    public interface IStandardService
    {
        ServiceResponse<IEnumerable<StandardDto>> GetAllStandard(int page, int pageSize);

        ServiceResponse<IEnumerable<StandardDto>> StandardByStageId(int id);

        ServiceResponse<IEnumerable<StandardDto>> GetAllStandardWithoutPage();
    }
}
