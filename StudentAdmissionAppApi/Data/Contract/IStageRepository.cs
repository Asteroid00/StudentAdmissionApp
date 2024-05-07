using StudentAdmissionAppApi.Models;

namespace StudentAdmissionAppApi.Data.Contract
{
    public interface IStageRepository
    {
        IEnumerable<Stages> GetStage();
    }
}
