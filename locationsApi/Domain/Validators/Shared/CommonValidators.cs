using Domain.DTOs;

namespace Domain.Validators.Shared
{
    public class CommonValidators : ICommonValidators
    {
        public bool IsValidString(string str)
        {
            TimeSpan timeSpan;
            return TimeSpan.TryParse(str, out timeSpan);
        }
    }
}
