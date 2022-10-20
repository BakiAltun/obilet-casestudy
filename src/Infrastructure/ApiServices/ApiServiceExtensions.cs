using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OBilet.CaseStudy.ApplicationCore.ApiServices.Models;
using OBilet.CaseStudy.ApplicationCore.Interfaces.ApiServices;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace OBilet.CaseStudy.Infrastructure.ApiServices
{
    public static class ApiServiceExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddSingleton<IClientSession, ClientSession>((serviceProvider) =>
            {
                var clientApiService = serviceProvider.GetRequiredService<IClientApiService>();
                return (ClientSession)clientApiService.GetSession();
            });



            services.AddHttpClient<IClientApiService, ClientApiService>(HttpClientConfiguration)
                    .SetHandlerLifetime(TimeSpan.FromMinutes(30));

            services.AddHttpClient<IJourneyApiService, JourneyApiService>(HttpClientConfiguration)
                    .SetHandlerLifetime(TimeSpan.FromMinutes(30));

            services.AddHttpClient<ILocationApiService, LocationApiService>(HttpClientConfiguration)
                    .SetHandlerLifetime(TimeSpan.FromMinutes(30));

            services.AddHttpClient<IJourneyApiService, JourneyApiService>(HttpClientConfiguration)
                    .SetHandlerLifetime(TimeSpan.FromMinutes(30));

            return services;
        }

        private static void HttpClientConfiguration(IServiceProvider serviceProvider, HttpClient httpClient)
        {
            IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
            string accessToken = configuration.GetValue<string>("AccessToken");
            string apiUrl = configuration.GetValue<string>("ApiUri") ?? "https://v2-api.obilet.com/api/";

            httpClient.BaseAddress = new Uri(apiUrl);
            //httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + accessToken);
        }

        public static async Task<TResponse> PostAsync<TResponse>(this HttpClient httpClient, string requestUri, HttpContent httpContent) where TResponse : class
        {
            var httpResponse = await httpClient.PostAsync(requestUri, httpContent);
            httpResponse.EnsureSuccessStatusCode();
            var response = await httpResponse.Content.ReadAsStringAsync();


            return JsonSerializer.Deserialize<TResponse>(response, GetDefaultOptions);
        }

        public static Task<TResponse> PostAsync<TResponse, TRequest>(this HttpClient httpClient, string requestUri, TRequest requestModel) where TResponse : class
        {
            var json = JsonSerializer.Serialize(requestModel, GetDefaultOptions);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            return PostAsync<TResponse>(httpClient, requestUri, content);
        }

        private static JsonSerializerOptions GetDefaultOptions => new(JsonSerializerDefaults.Web)
        {
            WriteIndented = true
        };
    }
}