using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //validations

namespace WebApplication1.Models
{
    public class CreateCard
    {
        [StringLength(maximumLength:20, MinimumLength =12, ErrorMessage = "Holder name is invalid and it should be between 12 and 20 symbols")]
        public string HolderName { get; set; }

        [RegularExpression("\\d{4}-\\d{4}-\\d{4}-\\d{4}")]
        public string Number { get; set; }

        [RegularExpression("\\d{2}/\\d{2}")]
         public string ExpireDate { get; set; }
    }
}
