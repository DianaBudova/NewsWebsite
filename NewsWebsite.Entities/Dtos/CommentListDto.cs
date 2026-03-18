using System.Collections.Generic;
using NewsWebsite.Entities.Concrete;
using NewsWebsite.Shared.Entity.Abstract;

namespace NewsWebsite.Entities.Dtos
{
    public class CommentListDto : DtoGetBase
    {
        public IList<Comment> Comments { get; set; }
    }
}
