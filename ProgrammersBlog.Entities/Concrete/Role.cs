using Microsoft.AspNetCore.Identity;

namespace ProgrammersBlog.Entities.Concrete
{
    //PrimaryKey alanı int oldu.
    public class Role:IdentityRole<int>
    {
    }
}
