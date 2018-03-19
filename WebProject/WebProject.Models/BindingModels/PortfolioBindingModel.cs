using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models.BindingModels
{
    public class PortfolioBindingModel
    {
      
        [Required(ErrorMessage = "Please enter your first name!")]
        [Display(Name = "First name")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "First name must be from 1 to 50 characters long!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name!")]
        [Display(Name = "Last name")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Last name must be from 1 to 50 characters long!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your age!")]
        [Range(15.00, 150.00, ErrorMessage = "Age must be between 15 - 150 years")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter your high school name!")]
        [Display(Name = "High school")]
        public string EducationHighSchool { get; set; }

        [Required(ErrorMessage = "Please enter your high collage name!")]
        [Display(Name = "Collage")]
        public string EducationCollege { get; set; }

        [Required(ErrorMessage = "Please enter your high school name!")]
        public string Experience { get; set; }

        [Required(ErrorMessage = "Please enter years of experience!")]
        [Display(Name = "Years of experience")]
        [Range(maximum: 70, minimum: 0,ErrorMessage = "Invalid input!")]
        public int ExperienceYears { get; set; }

        [Required(ErrorMessage = "Please enter something about yourself!")]
        [Display(Name = "About me")]
        public string AboutMe { get; set; }

        [Required(ErrorMessage = "Please enter your services!")]
        [Display(Name = "Services")]
        public string Services { get; set; }

        [Required(ErrorMessage = "Please enter your phone number!")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Facebook account")]
        public string FacebookAccount { get; set; }

        [Display(Name = "Twitter account")]
        public string TwitterAccount { get; set; }

    }
}
