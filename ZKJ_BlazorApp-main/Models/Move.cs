using BlazorApp.Helpers;
using System.ComponentModel.DataAnnotations;


namespace BlazorApp.Models
{
    //It is a class to keep some data for a very short time. just to acomplish a task.
    public class Move
    {
        [Required]
        public int WarehauseToMove { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "Wartość nie może być ujemna lub większa od 10000")]
        public int AmountToMove { get; set; }

        public decimal SingleBruttoValue { get; set; }

     
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }      
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Compare(nameof(Move.Password), ErrorMessage = "The password confirmation does not match")]
        public string ConfirmPassword { get; set; }


    }
}
