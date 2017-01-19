using System;
using System.ComponentModel.DataAnnotations;
using WebSample.Attributes;
using WebSample.Attributes.Validation;
using WebSample.Resources;

namespace WebSample.ViewModels
{
    public class UserViewModel
    {
        [Label(typeof(Labels), "Email")]
        [RequiredEx]
        [EmailValidation]
        public string Email { get; set; }

        [Label("FirstName")]
        [RequiredEx]
        public string FirstName { get; set; }

        [Label("LastName")]
        [RequiredEx]
        public string LastName { get; set; }

        [Label("DoB")]
        [DisplayFormat(DataFormatString = "MM/dd/yyyy")]
        [RequiredEx]
        [AgeValidation(18)]
        public DateTime? DoB { get; set; }

        public UserViewModel()
        {
            DoB = new DateTime(2015,11,24);
        }
    }
}
