using CMS.Utilities;
using CMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.IServices
{
    public interface ICategoryService
    {
        PagedResult<CategoryViewModel> GetAll(int pageNumber, int PageSize);
        CategoryViewModel GetById(int Id);
        void Update(CategoryViewModel model);
        void Insert(CategoryViewModel model);
        void Delete(int Id);
        IEnumerable<CategoryViewModel> GetAll();
    }
}
