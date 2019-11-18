using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Exceptions;
using Model.Dto.RequestPlate;
using Newtonsoft.Json;

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
            
            //TODO: Remover a criação do arquivo físoc, e usar apenas o local
            var imagePath = CreatePhysicalFile(imageBase64);

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), _requestUrl))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Token {_requestToken}");

                    var multipartContent = new MultipartFormDataContent();
                    multipartContent.Add(new ByteArrayContent(File.ReadAllBytes(imagePath)), "upload",
                        Path.GetFileName(imagePath));
                    multipartContent.Add(new StringContent("br"), "regions");
                    request.Content = multipartContent;

                    var response = await httpClient.SendAsync(request);

                    DeletePhysicalFile(imagePath);

                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResponsePlateRecognizer>(content);
                }
            }
        }


        private static string CreatePhysicalFile(string imageBase64)
        {
            var imageBytes = Convert.FromBase64String(imageBase64);
            var imagePath = $"{Path.GetTempPath()}{Guid.NewGuid()}.jpg";

            using (var imageFile = new FileStream(imagePath, FileMode.Create))
            {
                imageFile.Write(imageBytes, 0, imageBytes.Length);
                imageFile.Flush();
            }

            return imagePath;
        }

        private static void DeletePhysicalFile(string filePath)
        {
            File.Delete(filePath);
        }
    }
}