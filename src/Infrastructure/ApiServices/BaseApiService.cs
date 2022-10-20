using System.Net.Http;
using System.Text.Json;

namespace OBilet.CaseStudy.Infrastructure.ApiServices
{
    public partial class BaseApiService
    {
        public StringContent PrepareStringContent<T>(T requestModel) where T : new()
        {
            string content = JsonSerializer.Serialize(requestModel);

            return new StringContent(content, System.Text.Encoding.UTF8, "application/json");
        }
    }
}