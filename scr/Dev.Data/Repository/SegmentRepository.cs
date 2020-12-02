using Dev.Business.Interfaces;
using Dev.Business.Models;
using Dev.Data.Context;

namespace Dev.Data.Repository
{
    public class SegmentRepository : Repository<Segment>, ISegmentRepository
    {
        public SegmentRepository(MeuDbContext context) : base (context)
        { }
    }
}
