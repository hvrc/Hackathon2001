using System.ComponentModel.DataAnnotations;

namespace Hackathon2001.Models
{
    // Define an enumeration to represent technical interests
    public enum TechnicalInterest
    {
        IoT,                // Internet of Things
        Cognitive,          // Cognitive Computing
        Wearable,           // Wearable Computing
        AR_VR               // Augmented / Virtual Reality
    }

    // Define a static class to store display names for technical interests
    public static class TechnicalInterestDisplayNames
    {
        // Define a dictionary to map TechnicalInterest enum values to their display names
        public static readonly Dictionary<TechnicalInterest, string> DisplayNames = new Dictionary<TechnicalInterest, string>
        {
            { TechnicalInterest.IoT, "Internet of Things" },
            { TechnicalInterest.Cognitive, "Cognitive Computing" },
            { TechnicalInterest.Wearable, "Wearable Computing" },
            { TechnicalInterest.AR_VR, "Augmented / Virtual Reality" }
        };
    }

    public class HackathonInvite
    {
        // Use data annotations for validation rules

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }

        public TechnicalInterest Interest { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your Twitter account")]
        public string TwitterAccount { get; set; }

        public bool? WillAttend { get; set; }
    }
}
