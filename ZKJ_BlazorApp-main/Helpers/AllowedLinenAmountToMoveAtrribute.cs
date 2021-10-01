using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Helpers
{
    public class AllowedLinenAmountToMoveAtrribute : ValidationAttribute
    {

        public AllowedLinenAmountToMoveAtrribute(int amount)
        {
            AmountToMove = amount;
        }
        //public string GetErrorMessage() =>
        //    $"Amount can not be bigger the {AmountToMove}";
        public int AmountToMove{ get; }
        public int BaseAmount { get; }

        protected override ValidationResult IsValid(object inputValue, ValidationContext validationContext)
        {
             // var amount1 = ((Move)inputValue).AmountToMove;
            // var amount = (Move)validationContext.ObjectInstance;
           //  var comp = amount1.AmountToMove;

            if ((int)inputValue > AmountToMove)
            {
                return new ValidationResult($"The value is too big");
            }
            else
            {
                return ValidationResult.Success;
            }


        }
    }
}
