using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Model;

namespace Recruitment.Module.Core
{
    public interface IModelListViewExt : IModelNode
    {
        [DefaultValue("")]
        string AdditionalCriteria { get; set; }
    }
}
