

using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class CatagoryAddAjaxViewModel
    {
        public CategoryAddDto CategoryAddDto { get; set; }
        public string CategoryAddPartial { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }
}
