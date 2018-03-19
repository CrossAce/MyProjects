using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models.DataModels
{
    public class PortfolioDataModel
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string ImageLocation { get; set; }

        public string CVLocation { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int ExperienceYears { get; set; }

        public string EducationHighSchool { get; set; }

        public string EducationCollege { get; set; }

        public string Experience { get; set; }

        public string AboutMe { get; set; }

        public string Services { get; set; }

        public string PhoneNumber { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }
    }
}
