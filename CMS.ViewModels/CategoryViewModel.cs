using CMS.Models;
using CMS.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public CategoryViewModel()
        {
            
        }
        public CategoryViewModel(Category model)
        {
            Id = model.Id;
            Title = model.Title;
            CreatedDate = model.CreatedDate;
        }
        public Category ConvertViewModel(CategoryViewModel model)
        {
            return new Category
            {
                Id = model.Id,
                Title = model.Title,
                CreatedDate = model.CreatedDate,
            };
        }
    }
}
