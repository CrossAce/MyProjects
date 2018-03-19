using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Models.ViewModels
{
    public class PortfoliosViewModel
    {
        public PortfoliosViewModel()
        {
            PortfolioViewModels = new List<PortfolioViewModel>();
        }
        public IEnumerable<PortfolioViewModel> PortfolioViewModels { get; set; }
    }
}
