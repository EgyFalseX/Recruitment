using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Generators;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Win.Core
{
    public static class SessionExtensions
    {
        public static ModificationResult Delete<T>(this Session session, CriteriaOperator criteria = null) where T : IXPObject
        {
            ObjectGeneratorCriteriaSet gen_cri = null;
            if (ReferenceEquals(criteria, null))
                criteria = CriteriaOperator.Parse("True");
            else
                gen_cri = ObjectGeneratorCriteriaSet.GetCommonCriteriaSet(criteria);

            XPClassInfo classInfo = session.GetClassInfo(typeof(T));
            var batchWideData = new BatchWideDataHolder4Modification(session);
            int recordsAffected = (int)session.Evaluate<T>(CriteriaOperator.Parse("Count()"), criteria);
            List<ModificationStatement> collection = DeleteQueryGenerator.GenerateDelete(classInfo, gen_cri, batchWideData);
            foreach (ModificationStatement item in collection)
            {
                item.RecordsAffected = recordsAffected;
            }

            ModificationStatement[] collectionToArray = collection.ToArray<ModificationStatement>();
            ModificationResult result = session.DataLayer.ModifyData(collectionToArray);
            return result;
        }
    }

}
