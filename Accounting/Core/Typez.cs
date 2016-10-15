namespace Accounting.Core
{
    public static class Typez
    {
        public enum EnumAccNature
        {
            [DevExpress.Persistent.Base.ImageName("Action_Workflow_Deactivate")]
            Debt = 1,
            [DevExpress.Persistent.Base.ImageName("Action_Workflow_Activate")]
            Credit = 2
        }

    }
}
