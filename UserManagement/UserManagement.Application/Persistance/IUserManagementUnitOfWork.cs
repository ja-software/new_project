using System.Threading.Tasks;
using UserManagement.Application.Persistance.Abstraction;

namespace UserManagement.Application.Persistance
{
    public interface IUserManagementUnitOfWork //: IUnitOfWork
    {
        IPolicyRepository PolicyRepository { get; }
        IRuleRepository RuleRepository { get; }
        IApplicationPolicyRoleRepository ApplicationPolicyRoleRepository { get; }
        int Save();
        Task<int> SaveAsync();
    }
}
