using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Recruitment.Web.App_Code;
using Recruitment.Web.App_Code.dsDataTableAdapters;

namespace Recruitment.Web.Infrastructure
{
    public class Core
    {
        public static string CarouselmagePath => "~/img/carousel/";
        private static dsData.CompanyInfoDataTable _companyInfo;

        public static void StatUp()
        {
            _companyInfo = new dsData.CompanyInfoDataTable();
            CompanyInfoTableAdapter adp = new CompanyInfoTableAdapter();
            adp.Fill(_companyInfo);
        }

        public static string CompanyName => _companyInfo.Count > 0 ? _companyInfo[0].CompanyName : string.Empty;
        public static string AboutUs => _companyInfo.Count > 0 ? _companyInfo[0].AboutUs : string.Empty;
        public static string CompanyEmail => _companyInfo.Count > 0 ? _companyInfo[0].CompanyEmail : string.Empty;
        public static string CompanyPhone1 => _companyInfo.Count > 0 ? _companyInfo[0].CompanyPhone1 : string.Empty;
        public static string CompanyPhone2 => _companyInfo.Count > 0 ? _companyInfo[0].CompanyPhone2 : string.Empty;
        public static string CompanyMobile1 => _companyInfo.Count > 0 ? _companyInfo[0].CompanyMobile1 : string.Empty;
        public static string CompanyMobile2 => _companyInfo.Count > 0 ? _companyInfo[0].CompanyMobile2 : string.Empty;
        public static string CompanyAddress => _companyInfo.Count > 0 ? _companyInfo[0].CompanyAddress : string.Empty;
        public static string Facebook => _companyInfo.Count > 0 ? _companyInfo[0].facebook : string.Empty;
        public static string Twitter => _companyInfo.Count > 0 ? _companyInfo[0].twitter : string.Empty;
        public static string Youtube => _companyInfo.Count > 0 ? _companyInfo[0].youtube : string.Empty;
        public static string Instagram => _companyInfo.Count > 0 ? _companyInfo[0].instagram : string.Empty;
        public static string Dribbble => _companyInfo.Count > 0 ? _companyInfo[0].dribbble : string.Empty;
        public static string Linkedin => _companyInfo.Count > 0 ? _companyInfo[0].linkedin : string.Empty;

    }
}