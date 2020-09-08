using CrossCutting.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Domain.ViewModels
{
    public class RuleFilterViewModel : FilterVModel<RuleViewModel>
    {
        public string Name { set; get; }
    }
}
