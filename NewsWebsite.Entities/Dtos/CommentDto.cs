using NewsWebsite.Entities.Concrete;
using NewsWebsite.Shared.Entity.Abstract;

namespace NewsWebsite.Entities.Dtos
{
    public class CommentDto : DtoGetBase
    {
        public Comment Comment { get; set; }
    }
}
