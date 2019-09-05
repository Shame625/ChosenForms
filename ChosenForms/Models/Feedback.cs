using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ChosenForms.Models
{
    public class Feedback
    {
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        public IFormFile File { get; set; }
    }
}