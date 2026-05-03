namespace ABDM.ExternalServices
{
    public interface IMasterService
    {
        Task<object> GetSalutationList();
        Task<object> GetCityList();
        Task<object> GetStateList();
        Task<object> GetCountryList();
        Task<object> GetDistrictList();
        Task<object> GetAreaList();
    }
}
