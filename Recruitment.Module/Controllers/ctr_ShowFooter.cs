using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Module.Controllers
{
    public class ctr_ShowFooter : ViewController<ListView>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            View.Model.IsFooterVisible = true;
        }
    }
}
