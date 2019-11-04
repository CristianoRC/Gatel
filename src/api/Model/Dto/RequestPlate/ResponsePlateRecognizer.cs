using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Model.Dto.RequestPlate
{
    public class ResponsePlateRecognizer
    {
        [JsonProperty("Processing_time")] public double ProcessingTime { get; set; }
        public List<Result> Results { get; set; }
        public string Filename { get; set; }
        public int Version { get; set; }
        [JsonProperty("Camera_id")] public object CameraId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}