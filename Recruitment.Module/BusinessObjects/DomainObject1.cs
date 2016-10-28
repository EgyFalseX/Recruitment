using System.Linq;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace Recruitment.Module.BusinessObjects
{
    //[DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [DomainComponent, DefaultClassOptions]
    public class DomainObject1
    {
        // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public DomainObject1(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        //Dennis: This attribute is required to specify a
        [QueryProjections("Employee_Linq;Orders_Sum_Linq")]
        public static IQueryable OrdersLinq(Session s)
        {
            XPQuery<Order> orders = new XPQuery<Order>(s);
            var queryOrders = from o in orders
                orderby o.Employee.FirstName ascending
                group o by o.Employee.FirstName + " " + o.Employee.LastName
                into oo
                where oo.Sum(o => o.Freight) > 10000
                select new
                {
                    OrderID = oo.Sum(o => o.OrderID),
                    Employee_Linq = oo.Key,
                    Orders_Sum_Linq = oo.Sum(o => o.Freight)
                };
            return queryOrders;
        }
    }
}