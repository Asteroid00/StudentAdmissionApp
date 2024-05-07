using Microsoft.EntityFrameworkCore;
using StudentAdmissionAppApi.Data.Contract;
using StudentAdmissionAppApi.Models;

namespace StudentAdmissionAppApi.Data.Implementation
{
    public class StandardRepository : IStandardRepository
    {
        private readonly AppDBContext _dbContext;

        public StandardRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Standards> GetStandard()
        {
            List<Standards> standards = _dbContext.Standards.Include(C=>C.Stage).ToList();
            return standards;
        }

        public IEnumerable<Standards> GetPaginatedStandards(int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;
            return _dbContext.Standards
                .OrderBy(c => c.StandardId)
                .Skip(skip)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Standards> GetStandardByStageId(int id)
        {
            List<Standards> standards = _dbContext.Standards.Include(c => c.Stage).ToList();
            var result = standards.Where(p => p.StageId == id).ToList();
            return result;
        }


    }
}
