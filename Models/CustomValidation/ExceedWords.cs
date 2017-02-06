using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDbApp.Models.CustomValidation
{
    public class ExceedWords : ValidationAttribute
    {
        private readonly int _wordCnt;

        public ExceedWords(int cnt) : base("{0} has too many words.")
        {
            _wordCnt = cnt;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string[] words = value.ToString().Split(' ');
                if (words.Length > _wordCnt)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
                return ValidationResult.Success;
            }
            return base.IsValid(value, validationContext);
        }
    }
}