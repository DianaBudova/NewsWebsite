using NewsWebsite.Shared.Entity.Abstract;

namespace NewsWebsite.Entities.Concrete
{
    public class Comment : EntityBase, IEntity
    {
        public string Text { get; set; }
        public int NewsPostId { get; set; }
        public NewsPost NewsPost { get; set; }
        public int LanguageId{ get; set; }
        public Language Language { get; set; }
        
    }
}