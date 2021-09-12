using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactsUI.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Phone]
        [DisplayName("Mobile Phone")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(20)]
        public string MobilePhone { get; set; }

        [DisplayName("Job Title")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string JobTitle { get; set; }

        [DisplayName("BirthDate")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
