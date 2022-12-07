using CMS.Models;
using CMS.Repository.Interface;
using CMS.Utilities;
using CMS.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(int Id)
        {
            var model = _unitOfWork.GenericRepository<Category>().GetById(Id);
            _unitOfWork.GenericRepository<Category>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<CategoryViewModel> GetAll(int pageNumber, int PageSize)
        {
            var cm = new CategoryViewModel();
            int totalCount;
            List<CategoryViewModel> vmList = new List<CategoryViewModel>();
            try
            {
                int ExcludeRecords = (PageSize * pageNumber) - PageSize;
                var modelList = _unitOfWork.GenericRepository<Category>().GetAll()
                    .Skip(ExcludeRecords).Take(PageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Category>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModellList(modelList);
            }
            catch (Exception ex)
            {

                throw;
            }
            var Result = new PagedResult<CategoryViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = PageSize
            };
            return Result;
        }

        private List<CategoryViewModel> ConvertModelToViewModellList(List<Category> modelList)
        {
            return modelList.Select(x => new CategoryViewModel(x)).ToList();
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var modellist = _unitOfWork.GenericRepository<Category>().GetAll().ToList();
            var vmList = ConvertModelToViewModellList(modellist);
            return vmList;
        }

        public CategoryViewModel GetById(int Id)
        {
            var model = _unitOfWork.GenericRepository<Category>().GetById(Id);
            var vm = new CategoryViewModel(model);
            return vm;
        }

        public void Insert(CategoryViewModel category)
        {
            var model = new CategoryViewModel().ConvertViewModel(category);
            _unitOfWork.GenericRepository<Category>().Add(model);
            _unitOfWork.Save();
        }

        public void Update(CategoryViewModel category)
        {
            var model = new CategoryViewModel().ConvertViewModel(category);
            var ModelById = _unitOfWork.GenericRepository<Category>().GetById(model.Id);
            ModelById.Title = model.Title;
            ModelById.CreatedDate = model.CreatedDate;

            _unitOfWork.GenericRepository<Category>().Update(ModelById);
            _unitOfWork.Save();
        }
    }
}
