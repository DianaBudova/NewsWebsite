using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewsWebsite.Entities.Dtos
{
    public class CategoryUpdateDto
    {
        [Required] public int Id { get; set; }

        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Please, write a {0}.")]
        [MaxLength(70, ErrorMessage = "The {0} should not exceed {1} characters.")]
        [MinLength(5, ErrorMessage = "The {0} should not be less than {1} characters.")]
        public string Name { get; set; }

        [DisplayName("Category Description")]
        [MaxLength(500, ErrorMessage = "The {0} should not exceed {1} characters.")]
        [MinLength(5, ErrorMessage = "The {0} should not be less than {1} characters.")]
        public string Description { get; set; }

        [DisplayName("Is it active?")]
        [Required(ErrorMessage = "Please, write a {0}.")] 
        public bool IsActive { get; set; }
      
        [DisplayName("Is it deleted?")]
        [Required(ErrorMessage = "Please, write a {0}.")]
        public bool IsDeleted { get; set; }
    }
}