using CMS.Models;
using CMS.Repository.Interface;
using CMS.Utilities;
using CMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(int Id)
        {
            var model = _unitOfWork.GenericRepository<Post>().GetById(Id);
            _unitOfWork.GenericRepository<Post>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<PostViewModel> GetAll(int pageNumber, int PageSize)
        {
            var cm = new PostViewModel();
            int totalCount;
            List<PostViewModel> vmList = new List<PostViewModel>();
            try
            {
                int ExcludeRecords = (PageSize * pageNumber) - PageSize;
                var modelList = _unitOfWork.GenericRepository<Post>().GetAll()
                    .Skip(ExcludeRecords).Take(PageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Post>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModellList(modelList);
            }
            catch (Exception ex)
            {

                throw;
            }
            var Result = new PagedResult<PostViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = PageSize
            };
            return Result;
        }

        private List<PostViewModel> ConvertModelToViewModellList(List<Post> modelList)
        {
            return modelList.Select(x => new PostViewModel(x)).ToList();
        }

        public IEnumerable<PostViewModel> GetAll()
        {
            var modellist = _unitOfWork.GenericRepository<Post>().GetAll().ToList();
            var vmList = ConvertModelToViewModellList(modellist);
            return vmList;
        }

        public PostViewModel GetById(int Id)
        {
            var model = _unitOfWork.GenericRepository<Post>().GetById(Id);
            var vm = new PostViewModel(model);
            return vm;
        }

        public void Insert(PostViewModel post)
        {
            var model = new PostViewModel().ConvertViewModel(post);
            _unitOfWork.GenericRepository<Post>().Add(model);
            _unitOfWork.Save();
        }

        public void Update(PostViewModel post)
        {
            var model = new PostViewModel().ConvertViewModel(post);
            var ModelById = _unitOfWork.GenericRepository<Post>().GetById(model.Id);
            ModelById.Title = model.Title;
            ModelById.Description = model.Description;
            ModelById.CreatedDate = model.CreatedDate;
            ModelById.PublishDate = model.PublishDate;

            _unitOfWork.GenericRepository<Post>().Update(ModelById);
            _unitOfWork.Save();
        }
    }
}
