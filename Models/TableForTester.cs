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

    public partial class TableForTester : TableForEmployee
    {

        [Display(Name = "Дата теста")]
        [DataType(DataType.Date)]
        public System.DateTime DateTest { get; set; }

        [Display(Name = "Интеграционные тесты")]
        [DataType(DataType.Text)]
        public string IntegrationTest { get; set; }

        [Display(Name = "Системные тесты")]
        [DataType(DataType.Text)]
        public string SystemTest { get; set; }
    }
}
