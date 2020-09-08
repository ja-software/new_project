using System;

namespace UserManagement.Domain.Models
{
    public class ApplicationPolicyRole
    {
        public int Id { set; get; }
        public int ApplicationPolicyId { set; get; }
        public Guid ApplicationRoleId { set; get; }
        public ApplicationPolicy ApplicationPolicy { set; get; }
        public ApplicationRole ApplicationRole { set; get; }
    }
}
