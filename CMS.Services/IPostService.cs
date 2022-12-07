using CMS.Utilities;
using CMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services
{
    public interface IPostService
    {
        PagedResult<PostViewModel> GetAll(int pageNumber, int PageSize);
        PostViewModel GetById(int Id);
        void Update(PostViewModel model);
        void Insert(PostViewModel model);
        void Delete(int Id);
        IEnumerable<PostViewModel> GetAll();
    }
}
