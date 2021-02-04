using System.ComponentModel.DataAnnotations;

namespace SharedProject
{
    public class Person
    {
        [Key]
        [Range(1,int.MaxValue,ErrorMessage ="Id required")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name required")]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "Age required")]
        public int Age { get; set; }
    }
}
