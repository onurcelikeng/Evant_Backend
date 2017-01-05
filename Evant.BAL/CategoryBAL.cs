using Evant.BO;
using Evant.BO.Models;
using Evant.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evant.BAL
{
    public sealed class CategoryBAL
    {
        private CategoryDAL categoryDal;


        public CategoryBAL()
        {
            categoryDal = new CategoryDAL();
        }


        public List<CategoryModel> GetAllCategories()
        {
            return categoryDal.GetAllCategories();
        }

        public List<CategoryBO> GetBestCategories()
        {
            return categoryDal.GetBestCategories();
        }
    }
}