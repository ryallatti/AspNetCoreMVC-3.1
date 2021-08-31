using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Enums
{
    public enum LanguageEnum
    {
        [Display(Name = "Hindi Language")]
        Hindi = 10,
        [Display(Name = "English Language")]
        English = 20,
        [Display(Name = "Dutch Language")]
        Dutch = 30,
        [Display(Name = "Spanish Language")]
        Spanish = 40
    }
}
