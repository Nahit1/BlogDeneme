

using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class CatagoryUpdateAjaxViewModel
    {
        public CategoryUpdateDto CategoryUpdatedDto { get; set; }
        public string CategoryUpdatePartial { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }
}
