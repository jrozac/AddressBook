using System.ComponentModel.DataAnnotations;
using TestAssignment.AddressBook.Dtos;
using TestAssignment.AddressBook.Repositories;

namespace TestAssignment.AddressBook.DataValidation
{

    /// <summary>
    /// Phone number unique validation attribute
    /// </summary>
    public class PhoneUniqueAttribute : ValidationAttribute
    {

        public PhoneUniqueAttribute()
        {
            ErrorMessage = "Phone number is already used by another entry.";
            ErrorMessageResourceName = "Phone number is already used by another entry.";
        }

        /// <summary>
        /// Validate phone number availability
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            // get validation object id (null for new objects - ContactDataDto)
            var id = (validationContext.ObjectInstance as ContactDto)?.Id;

            // get existing object by phone number
            var repository = (IContactsRepository) validationContext.GetService(typeof(IContactsRepository));
            var existingObj = repository.GetByPhoneNumber(value as string);

            // number is available if it does not exist or it is taken by current contact
            var status = existingObj == null || existingObj.Id == id;

            // return validation result
            return status ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }

    }
}
