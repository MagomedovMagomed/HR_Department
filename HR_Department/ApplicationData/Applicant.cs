//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HR_Department.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Applicant
    {
        public int Id_applicant { get; set; }
        public string Surename_applicant { get; set; }
        public string Name_applicant { get; set; }
        public string Lastname_applicant { get; set; }
        public string Telephon { get; set; }
        public string SNILS { get; set; }
        public string Email { get; set; }
        public System.DateTime Date_of_the_interview { get; set; }
        public int Id_post { get; set; }
        public Nullable<bool> document_education { get; set; }
        public string Cover_lettter { get; set; }
        public int Id_substation { get; set; }
        public string Note { get; set; }
        public int Id_the_result_of_the_meeting { get; set; }
        public string Where_by_whom_experience { get; set; }
        public Nullable<int> Id_Count_interview { get; set; }
    
        public virtual Count_unterview Count_unterview { get; set; }
        public virtual Post Post { get; set; }
        public virtual Substation Substation { get; set; }
        public virtual The_result_of_the_meeting The_result_of_the_meeting { get; set; }
    }
}
