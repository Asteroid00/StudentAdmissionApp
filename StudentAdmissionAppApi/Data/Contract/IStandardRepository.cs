using StudentAdmissionAppApi.Models;

namespace StudentAdmissionAppApi.Data.Contract
{
    public interface IStandardRepository
    {
        IEnumerable<Standards> GetStandard();

        IEnumerable<Standards> GetPaginatedStandards(int page, int pageSize);

        IEnumerable<Standards> GetStandardByStageId(int id);

    }
}
