using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerAssistant.Models
{
    public class FeedBack
    {
        public System.Guid Id { get; set; }

        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string FIO { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
