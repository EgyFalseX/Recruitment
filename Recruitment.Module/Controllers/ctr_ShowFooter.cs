using DevExpress.ExpressApp;

namespace Recruitment.Module.Controllers
{
    // ReSharper disable once InconsistentNaming
    public class ctr_ShowFooter : ViewController<ListView>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            View.Model.IsFooterVisible = true;
        }
    }
}
