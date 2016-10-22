﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Recruitment.Module.BusinessObjects.Recruitment
{

    public partial class rec_Employer_Order_Detail : XPLiteObject
    {
        int frec_employer_order_detail_id;
        [Key(true)]
        public int rec_employer_order_detail_id
        {
            get { return frec_employer_order_detail_id; }
            set { SetPropertyValue<int>("rec_employer_order_detail_id", ref frec_employer_order_detail_id, value); }
        }
        rec_Employer_Order frec_employer_order_detail_rec_employer_order_id;
        [Indexed(Name = @"irec_employer_order_detail_rec_employer_order_id_rec_Employer_Order_Detail")]
        [Association(@"rec_Employer_Order_DetailReferencesrec_Employer_Order")]
        public rec_Employer_Order rec_employer_order_detail_rec_employer_order_id
        {
            get { return frec_employer_order_detail_rec_employer_order_id; }
            set { SetPropertyValue<rec_Employer_Order>("rec_employer_order_detail_rec_employer_order_id", ref frec_employer_order_detail_rec_employer_order_id, value); }
        }
        rec_Industry frec_employer_order_detail_industry_id;
        [Indexed(Name = @"irec_employer_order_detail_industry_id_rec_Employer_Order_Detail")]
        [Association(@"rec_Employer_Order_DetailReferencesrec_Industry")]
        public rec_Industry rec_employer_order_detail_industry_id
        {
            get { return frec_employer_order_detail_industry_id; }
            set { SetPropertyValue<rec_Industry>("rec_employer_order_detail_industry_id", ref frec_employer_order_detail_industry_id, value); }
        }
        int frec_employer_order_detail_count;
        public int rec_employer_order_detail_count
        {
            get { return frec_employer_order_detail_count; }
            set { SetPropertyValue<int>("rec_employer_order_detail_count", ref frec_employer_order_detail_count, value); }
        }
        string frec_employer_order_detail_visa_name;
        [Size(50)]
        public string rec_employer_order_detail_visa_name
        {
            get { return frec_employer_order_detail_visa_name; }
            set { SetPropertyValue<string>("rec_employer_order_detail_visa_name", ref frec_employer_order_detail_visa_name, value); }
        }
        rec_Medical_Insurance_Types frec_employer_order_detail_rec_medical_insurance_types_id;
        [Indexed(Name = @"irec_employer_order_detail_rec_medical_insurance_types_id_rec_Employer_Order_Detail")]
        [Association(@"rec_Employer_Order_DetailReferencesrec_Medical_Insurance_Types")]
        public rec_Medical_Insurance_Types rec_employer_order_detail_rec_medical_insurance_types_id
        {
            get { return frec_employer_order_detail_rec_medical_insurance_types_id; }
            set { SetPropertyValue<rec_Medical_Insurance_Types>("rec_employer_order_detail_rec_medical_insurance_types_id", ref frec_employer_order_detail_rec_medical_insurance_types_id, value); }
        }
        bool frec_employer_order_detail_can_bring_family;
        public bool rec_employer_order_detail_can_bring_family
        {
            get { return frec_employer_order_detail_can_bring_family; }
            set { SetPropertyValue<bool>("rec_employer_order_detail_can_bring_family", ref frec_employer_order_detail_can_bring_family, value); }
        }
        rec_Position frec_employer_order_detail_position_id;
        [Indexed(Name = @"irec_employer_order_detail_position_id_rec_Employer_Order_Detail")]
        [Association(@"rec_Employer_Order_DetailReferencesrec_Position")]
        public rec_Position rec_employer_order_detail_position_id
        {
            get { return frec_employer_order_detail_position_id; }
            set { SetPropertyValue<rec_Position>("rec_employer_order_detail_position_id", ref frec_employer_order_detail_position_id, value); }
        }
        double frec_employer_order_detail_salary;
        public double rec_employer_order_detail_salary
        {
            get { return frec_employer_order_detail_salary; }
            set { SetPropertyValue<double>("rec_employer_order_detail_salary", ref frec_employer_order_detail_salary, value); }
        }
        rec_Housing_Type frec_employer_order_detail_rec_housing_type;
        [Indexed(Name = @"irec_employer_order_detail_rec_housing_type_rec_Employer_Order_Detail")]
        [Association(@"rec_Employer_Order_DetailReferencesrec_Housing_Type")]
        public rec_Housing_Type rec_employer_order_detail_rec_housing_type
        {
            get { return frec_employer_order_detail_rec_housing_type; }
            set { SetPropertyValue<rec_Housing_Type>("rec_employer_order_detail_rec_housing_type", ref frec_employer_order_detail_rec_housing_type, value); }
        }
        double frec_employer_order_detail_housing_value;
        public double rec_employer_order_detail_housing_value
        {
            get { return frec_employer_order_detail_housing_value; }
            set { SetPropertyValue<double>("rec_employer_order_detail_housing_value", ref frec_employer_order_detail_housing_value, value); }
        }
        rec_Residence_Type frec_employer_order_detail_rec_residence_type_id;
        [Indexed(Name = @"irec_employer_order_detail_rec_residence_type_id_rec_Employer_Order_Detail")]
        [Association(@"rec_Employer_Order_DetailReferencesrec_Residence_Type")]
        public rec_Residence_Type rec_employer_order_detail_rec_residence_type_id
        {
            get { return frec_employer_order_detail_rec_residence_type_id; }
            set { SetPropertyValue<rec_Residence_Type>("rec_employer_order_detail_rec_residence_type_id", ref frec_employer_order_detail_rec_residence_type_id, value); }
        }
        rec_Ticket_Type frec_employer_order_detail_rec_ticket_type_id;
        [Indexed(Name = @"irec_employer_order_detail_rec_ticket_type_id_rec_Employer_Order_Detail")]
        [Association(@"rec_Employer_Order_DetailReferencesrec_Ticket_Type")]
        public rec_Ticket_Type rec_employer_order_detail_rec_ticket_type_id
        {
            get { return frec_employer_order_detail_rec_ticket_type_id; }
            set { SetPropertyValue<rec_Ticket_Type>("rec_employer_order_detail_rec_ticket_type_id", ref frec_employer_order_detail_rec_ticket_type_id, value); }
        }
        double frec_employer_order_detail_working_hours;
        public double rec_employer_order_detail_working_hours
        {
            get { return frec_employer_order_detail_working_hours; }
            set { SetPropertyValue<double>("rec_employer_order_detail_working_hours", ref frec_employer_order_detail_working_hours, value); }
        }
        int frec_employer_order_detail_annual_vacation_days;
        public int rec_employer_order_detail_annual_vacation_days
        {
            get { return frec_employer_order_detail_annual_vacation_days; }
            set { SetPropertyValue<int>("rec_employer_order_detail_annual_vacation_days", ref frec_employer_order_detail_annual_vacation_days, value); }
        }
        rec_Annual_Vacation_Type frec_employer_order_detail_rec_annual_vacation_type_id;
        [Indexed(Name = @"irec_employer_order_detail_rec_annual_vacation_type_id_rec_Employer_Order_Detail")]
        [Association(@"rec_Employer_Order_DetailReferencesrec_Annual_Vacation_Type")]
        public rec_Annual_Vacation_Type rec_employer_order_detail_rec_annual_vacation_type_id
        {
            get { return frec_employer_order_detail_rec_annual_vacation_type_id; }
            set { SetPropertyValue<rec_Annual_Vacation_Type>("rec_employer_order_detail_rec_annual_vacation_type_id", ref frec_employer_order_detail_rec_annual_vacation_type_id, value); }
        }
        double frec_employer_order_detail_overtime;
        public double rec_employer_order_detail_overtime
        {
            get { return frec_employer_order_detail_overtime; }
            set { SetPropertyValue<double>("rec_employer_order_detail_overtime", ref frec_employer_order_detail_overtime, value); }
        }
        string frec_employer_order_detail_description;
        [Size(1000)]
        public string rec_employer_order_detail_description
        {
            get { return frec_employer_order_detail_description; }
            set { SetPropertyValue<string>("rec_employer_order_detail_description", ref frec_employer_order_detail_description, value); }
        }
        short frec_employer_order_detail_experience_years_start;
        public short rec_employer_order_detail_experience_years_start
        {
            get { return frec_employer_order_detail_experience_years_start; }
            set { SetPropertyValue<short>("rec_employer_order_detail_experience_years_start", ref frec_employer_order_detail_experience_years_start, value); }
        }
        short frec_employer_order_detail_experience_years_end;
        public short rec_employer_order_detail_experience_years_end
        {
            get { return frec_employer_order_detail_experience_years_end; }
            set { SetPropertyValue<short>("rec_employer_order_detail_experience_years_end", ref frec_employer_order_detail_experience_years_end, value); }
        }
        [Association(@"rec_Employer_Order_Detail_CallReferencesrec_Employer_Order_Detail")]
        public XPCollection<rec_Employer_Order_Detail_Call> rec_Employer_Order_Detail_Calls { get { return GetCollection<rec_Employer_Order_Detail_Call>("rec_Employer_Order_Detail_Calls"); } }
        [Association(@"rec_Employer_Order_Detail_Suggest_ApplicatReferencesrec_Employer_Order_Detail")]
        public XPCollection<rec_Employer_Order_Detail_Suggest_Applicat> rec_Employer_Order_Detail_Suggest_Applicats { get { return GetCollection<rec_Employer_Order_Detail_Suggest_Applicat>("rec_Employer_Order_Detail_Suggest_Applicats"); } }
    }

}
