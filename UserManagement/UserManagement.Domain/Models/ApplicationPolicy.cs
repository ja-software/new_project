using System.Collections.Generic;

namespace UserManagement.Domain.Models
{
    public class ApplicationPolicy
    {
        public ApplicationPolicy()
        {
            ApplicationPolicyRoles = new HashSet<ApplicationPolicyRole>();
        }
        public int Id { set; get; }
        public string Name { set; get; }

        public ICollection<ApplicationPolicyRole> ApplicationPolicyRoles { set; get; }
    }
}
