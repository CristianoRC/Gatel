using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Exceptions;
using Model.Dto.RequestPlate;
using Newtonsoft.Json;
using static System.Convert;

namespace Business.PlateRecognizer
{
    public class PlateRecognizerBusiness : IPlateRecognizer
    {
        private readonly string _requestToken;
        private readonly string _requestUrl;

        public PlateRecognizerBusiness()
        {
            _requestUrl = "  https://api.platerecognizer.com/v1/plate-reader";
            _requestToken = "8e6808a74f3322f51aaefaf1de87d28148733b97";
        }

        public async Task<ResponsePlateRecognizer> GetPlate(string imageBase64)
        {
            var formData = GetFormData(imageBase64);

            using (var client = GetHttpClientConfigured())
            {
                var responseData = await client.PostAsync(_requestUrl, formData);
                var jsonContent = await responseData.Content.ReadAsStringAsync();

                if (responseData.StatusCode == HttpStatusCode.OK)
                {
                    return ConvertRequestResponse(jsonContent);
                }

                throw new InvalidPlateConversion(jsonContent);
            }
        }

        private ResponsePlateRecognizer ConvertRequestResponse(string json)
        {
            return JsonConvert.DeserializeObject<ResponsePlateRecognizer>(json);
        }

        private HttpClient GetHttpClientConfigured()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", _requestToken);
            return client;
        }

        private MultipartFormDataContent GetFormData(string imageBase64)
        {
            var image = FromBase64String(imageBase64);

            var formData = new MultipartFormDataContent();
            formData.Add(new StreamContent(new MemoryStream(image)), DateTime.Now.ToLongDateString(), "upload.jpg");

            return formData;
        }
    }
}