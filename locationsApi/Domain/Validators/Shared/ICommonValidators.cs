namespace Domain.Validators.Shared
{
    public interface ICommonValidators
    {
        Task<bool> BeAValidAge(DateTime date);
    }
}
