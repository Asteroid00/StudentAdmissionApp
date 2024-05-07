using StudentAdmissionAppApi.Data.Contract;
using StudentAdmissionAppApi.Models;

namespace StudentAdmissionAppApi.Data.Implementation
{
    public class StageRepository : IStageRepository
    {
        private readonly AppDBContext _appDbContext;

        public StageRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Stages> GetStage()
        {
            List<Stages> stages = _appDbContext.Stages.ToList();
            return stages;
        }
    }
}
