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
    
    public partial class The_result_of_the_meeting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public The_result_of_the_meeting()
        {
            this.Applicant = new HashSet<Applicant>();
        }
    
        public int id_the_result_of_the_meeting { get; set; }
        public string Name_the_result_of_the_meeting { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applicant> Applicant { get; set; }
    }
}
