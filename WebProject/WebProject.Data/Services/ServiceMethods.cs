using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebProject.Models.BindingModels;
using WebProject.Models.ViewModels;
using WebProject.Models.DataModels;
using System.IO;
using System.Drawing;

namespace WebProject.Data.Services
{
    public class ServiceMethods
    {
        //public

        public void UploadPortfolio(PortfolioBindingModel model, string Creator, string imageLocation)
        {
            try
            {
                PortfolioDataModel dataModel = new PortfolioDataModel
                {
                    ImageLocation = imageLocation,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Email = Creator,
                    Age = model.Age,
                    EducationHighSchool = model.EducationHighSchool,
                    EducationCollege = model.EducationCollege,
                    Experience = model.Experience,
                    ExperienceYears = model.ExperienceYears,
                    AboutMe = model.AboutMe,
                    Services = model.Services,
                    Facebook = model.FacebookAccount,
                    Twitter = model.TwitterAccount,
                    CVLocation = ""
                };
                using (var context = new PortfolioDatabase())
                {
                    if (context.Portfolio_table != null)
                    {
                        if (context.Portfolio_table
                                   .FirstOrDefault(u => u.Email == Creator) == null)
                        {
                            context.Portfolio_table.Add(dataModel);
                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        context.Portfolio_table.Add(dataModel);
                        context.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePortfolio(PortfolioBindingModel model, string Creator, string ImageLocation)
        {
            try
            {
                PortfolioDataModel dataModel = new PortfolioDataModel
                {
                    ImageLocation = ImageLocation,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Email = Creator,
                    Age = model.Age,
                    EducationHighSchool = model.EducationHighSchool,
                    EducationCollege = model.EducationCollege,
                    Experience = model.Experience,
                    ExperienceYears = model.ExperienceYears,
                    AboutMe = model.AboutMe,
                    Services = model.Services,
                    Facebook = model.FacebookAccount,
                    Twitter = model.TwitterAccount,
                    CVLocation = ""
                };
                using (var context = new PortfolioDatabase())
                {
                    var result = context.Portfolio_table.FirstOrDefault(p => p.Email == Creator);

                    if(ImageLocation == "")
                    dataModel.ImageLocation = result.ImageLocation;

                    context.Portfolio_table.Remove(result);
                    context.Portfolio_table.Add(dataModel);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PortfolioBindingModel GetPortfolioBindingModel(int? id)
        {
            if(id > -1)
            {
                using (var context = new PortfolioDatabase())
                {
                    var result = context.Portfolio_table
                                        .FirstOrDefault(p => p.Id == id);
                    if (result != null)
                    {
                        var bindingModel = new PortfolioBindingModel()
                        {

                            FirstName = result.FirstName,
                            LastName = result.LastName,
                            PhoneNumber = result.PhoneNumber,
                            Age = result.Age,
                            EducationHighSchool = result.EducationHighSchool,
                            EducationCollege = result.EducationCollege,
                            Experience = result.Experience,
                            ExperienceYears = result.ExperienceYears,
                            AboutMe = result.AboutMe,
                            Services = result.Services,
                            FacebookAccount = result.Facebook,
                            TwitterAccount = result.Twitter
                        };
                        return bindingModel;
                    }
                }
            }        
            return null;
        }

        public void DeletePortfolio(int? id)
        {
            if(id > -1)
            {
                using (var context = new PortfolioDatabase())
                {
                    var result = context.Portfolio_table.FirstOrDefault(p => p.Id == id);
                    if(result != null)
                    {
                        System.IO.File.Delete(result.ImageLocation);
                        context.Portfolio_table.Remove(result);
                        context.SaveChanges();
                    }
                    
                }
            }
        }

        public PortfolioViewModel Details(int? id)
        {
            if(id > -1)
            {
                using (var context = new PortfolioDatabase())
                {
                    var dataModel = context.Portfolio_table
                        .FirstOrDefault(d => d.Id == id);

                    if(dataModel != null)
                    return GetViewModel(dataModel);
                }
            }
            return null; 
        }

        public PortfolioViewModel GetMyPortfolio(string User)
        {
            using (var context = new PortfolioDatabase())
            {
                if(context.Portfolio_table != null)
                {
                    var result = context.Portfolio_table
                        .FirstOrDefault(u => u.Email == User);
                    if(result != null)
                    {
                        var viewModel = GetViewModel(result);                      
                        return viewModel;
                    }            
                }
                
            }
            return null;
        }

        public PortfoliosViewModel GetViewPortfoliosViewModel()
        {
            List<PortfolioViewModel> data = new List<PortfolioViewModel>();
            using (var context = new PortfolioDatabase())
            {
                foreach (var m in context.Portfolio_table)
                {
                    var temp = GetViewModel(m);
                    data.Add(temp);
                }
            }

            return new PortfoliosViewModel() { PortfolioViewModels = data };
        }


        //private

        private byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private PortfolioViewModel GetViewModel(PortfolioDataModel dataModel)
        {
            var viewModel = new PortfolioViewModel()
            {
                Id = dataModel.Id,
                FirstName = dataModel.FirstName,
                LastName = dataModel.LastName,
                PhoneNumber = dataModel.PhoneNumber,
                Email = dataModel.Email,
                Age = dataModel.Age,
                EducationHighSchool = dataModel.EducationHighSchool,
                EducationCollege = dataModel.EducationCollege,
                Experience = dataModel.Experience,
                ExperienceYears = dataModel.ExperienceYears,
                AboutMe = dataModel.AboutMe,
                Services = dataModel.Services,
                Facebook = dataModel.Facebook,
                Twitter = dataModel.Twitter,
            };


            Image img = Image.FromFile(dataModel.ImageLocation);
            var barr = ImageToByteArray(img);
            viewModel.Image = Convert.ToBase64String(barr);

            return viewModel;
        }


    }
}
