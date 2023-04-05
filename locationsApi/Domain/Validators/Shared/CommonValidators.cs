namespace Domain.Validators.Shared
{
    public class CommonValidators : ICommonValidators
    {
        public async Task<bool> BeAValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;
            if (dobYear <= currentYear && dobYear > (currentYear - 120))
            {
                return true;
            }
            return false;
        }
    }
}
