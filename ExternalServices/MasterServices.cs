using ComServRef;

namespace ABDM.ExternalServices
{
    public class MasterService:IMasterService
    {
        public async Task<object> GetSalutationList()
        {
            CommonServiceClient client =
                new CommonServiceClient();

            var response =
                await client.GetSalutatioLstAsync();

            return response.GetSalutatioLstResult;
        }

        public async Task<object> GetCityList()
        {
            CommonServiceClient client =
                new CommonServiceClient();

            var response =
                await client.GetCityListAsync();

            return response.GetCityListResult;
        }

        public async Task<object> GetStateList()
        {
            CommonServiceClient client =
                new CommonServiceClient();

            var response =
                await client.GetStateLstAsync();

            return response.GetStateLstResult;
        }

        public async Task<object> GetCountryList()
        {
            CommonServiceClient client =
                new CommonServiceClient();

            var response =
                await client.GetCountryLstAsync();

            return response.GetCountryLstResult;
        }

        public async Task<object> GetDistrictList()
        {
            CommonServiceClient client =
                new CommonServiceClient();

            var response =
                await client.GetDistrictLstAsync();

            return response.GetDistrictLstResult;
        }

        public async Task<object> GetAreaList()
        {
            CommonServiceClient client =
                new CommonServiceClient();

            var response =
                await client.GetAreaListAsync();

            return response.GetAreaListResult;
        }
    }
}
