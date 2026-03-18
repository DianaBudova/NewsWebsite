using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NewsWebsite.Entities.Concrete;

namespace NewsWebsite.Entities.Dtos
{
    public class NewsPostUpdateDto
    {
        [Required] public int Id { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "The {0} should not be blank.")]
        [MaxLength(100, ErrorMessage = "The {0} should not exceed {1} characters.")]
        [MinLength(5, ErrorMessage = "The {0} should not be less than {1} characters.")]
        public string Title { get; set; }

        [DisplayName("Content")]
        [Required(ErrorMessage = "The {0} should not be blank.")]
        [MinLength(20, ErrorMessage = "The {0} should not be less than {1} characters.")]
        public string Content { get; set; }

        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "The {0} should not be blank.")]
        [MaxLength(250, ErrorMessage = "The {0} should not exceed {1} characters.")]
        [MinLength(5, ErrorMessage = "The {0} should not be less than {1} characters.")]
        public string Thumbnail { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "The {0} should not be blank.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Author")]
        [Required(ErrorMessage = "The {0} should not be blank.")]
        [MaxLength(50, ErrorMessage = "The {0} should not exceed {1} characters.")]
        [MinLength(3, ErrorMessage = "The {0} should not be less than {1} characters.")]
        public string Author { get; set; }

        [DisplayName("Author Description")]
        [Required(ErrorMessage = "The {0} should not be blank.")]
        [MaxLength(200, ErrorMessage = "The {0} should not exceed {1} characters.")]
        [MinLength(3, ErrorMessage = "The {0} should not be less than {1} characters.")]
        public string AuthorDescription { get; set; }

        [DisplayName("Language")]
        [Required(ErrorMessage = "The {0} should not be blank.")]
        public int LanguageId { get; set; }

        public Language Language { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "The {0} should not be blank.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [DisplayName("Is it active?")]
        [Required(ErrorMessage = "The {0} should not be blank.")]
        public bool IsActive { get; set; }

        [DisplayName("Is it deleted?")]
        [Required(ErrorMessage = "The {0} should not be blank.")]
        public bool IsDeleted { get; set; }
    }
}