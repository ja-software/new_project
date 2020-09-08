using Common.Application.Persistance.Abstraction;
using Common.Domain.Module;
using CrossCutting.Persistance.Repositories;
using UserManagement.Persistance;

namespace Common.Persistance.Concrete
{
    public sealed  class AttachmentTypeRepository : Repository<AttachmentType>, IAttachmentTypeRepository
    {
        public AttachmentTypeRepository(CommonDbContext context)
            : base(context)
        {
            Context = context;
        }

        public CommonDbContext Context { get; }
    }
}
