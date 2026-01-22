using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MultipleFormValidation.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        public CustomerDetailsModel CustomerDetails { get; set; } = new();
        public AttendeeListModel AttendeeList { get; set; } = new();
        public BillingAddressData BillingAddress { get; set; } = new();

        public void Save()
        {


        }
    }

    public class CustomerDetailsModel : IValidatableObject
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool IsCompany { get; set; }

        public string CompanyNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsCompany)
            {
                if (string.IsNullOrWhiteSpace(CompanyNumber))
                {
                    yield return new ValidationResult("Company number is required!",
                        [nameof(CompanyNumber)]);
                }
            }
        }
    }

    public class AttendeeListModel : IValidatableObject
    {
        public List<AttendeeModel> Attendees { get; set; } = new();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Attendees.Any())
            {
                yield return new ValidationResult("You need to add at least one attendee!",
                    [nameof(Attendees)]);
            }
        }

        public void Add()
        {
            Attendees.Add(new AttendeeModel());
        }

        public void Remove(AttendeeModel attendee)
        {
            Attendees.Remove(attendee);
        }
    }

    public class AttendeeModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class BillingAddressData
    {
        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Zip { get; set; }
    }
}
