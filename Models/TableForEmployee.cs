//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagerAssistant
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TableForEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TableForEmployee()
        {
            this.Project = new HashSet<Project>();
        }
    
        public System.Guid Id { get; set; }

        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Изменение")]
        [DataType(DataType.Text)]
        public string Changes { get; set; }

        [Display(Name = "Начало работ")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateStart { get; set; }

        [Display(Name = "Конец работ")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateEnd { get; set; }
       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Project { get; set; }
    }
}
