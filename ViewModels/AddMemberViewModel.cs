using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MemberApp.ViewModels
{
    public class AddMemberViewModel
    {

        [StringLength(50)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public bool IsMale { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }

        public string Country { get; set; }
        public string City { get; set; }


        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        public string Notes { get; set; }


        [Display(Name = "Member Status")]
        public bool IsActive { get; set; }
        public HttpPostedFileBase UploadedImage { get; set; }





    }
}