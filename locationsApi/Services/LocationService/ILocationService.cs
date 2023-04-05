using Domain.DTOs;
using Domain.Handlers;

namespace Services.LocationService
{
    public interface ILocationService
    {
        Task<ResponsePackage<bool>> SaveLocationAsync(SaveLocationPayload saveLocationPayload);
        Task<ResponsePackage<bool>> EditLocationAsync(EditLocationPayload editLocationPayload);
        Task<ResponsePackage<bool>> DeleteLocationAsync(int id);
        Task<LocationDto> GetLocationAsync(int id);
        Task<List<LocationDto>> GetAllLocationsAsync();
        Task<List<LocationDto>> GetLocationsBetweenTimesAsync();
    }
}
