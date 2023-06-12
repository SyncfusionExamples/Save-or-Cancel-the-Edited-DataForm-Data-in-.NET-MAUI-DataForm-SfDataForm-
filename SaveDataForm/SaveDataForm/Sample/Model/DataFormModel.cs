using System.ComponentModel.DataAnnotations;

namespace SaveDataForm
{
    public class DataFormModel
    {
        public DataFormModel()
        {
            this.Name = string.Empty;
            this.Email = string.Empty;
            this.FeedBack = string.Empty;
        }

        [Display(Name = "Name", Prompt = "Enter your name")]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Display(Prompt = "Enter your MailID")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your MailID")]
        public string Email { get; set; }

        public DateTime date { get; set; }

        [Display(Name = "EventName", Prompt = "Select your event name")]
        [Required(ErrorMessage = "Please enter event name")]
        public string EventName { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Prompt = "Enter your feedback here")]
        public string FeedBack { get; set; }
    }
}