using GamingCommunity.Entities;

namespace GamingCommunity.Models
{
    public class UserProfileViewModel : UserProfile
    {
        public string Username { get; set; }
        public int Age
        {
            get
            {
                DateOnly currentDate = DateOnly.FromDateTime(DateTime.Today);

                int age = currentDate.Year - BirthDate.Year;

                if (BirthDate.AddYears(age) > currentDate)
                {
                    age--;
                }

                return age;
            }
        }
    }
}
