using System.Text.Json.Serialization;

namespace LAHJA.Data.UI.Models
{
    public class QueryRequestTextToSpeechHeader
    {
        [JsonPropertyName("Authorization")]
        public string Authorization { get; set; } = "Bearer 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";

        [JsonPropertyName("Content-Type")]
        public string ContentType { get; set; } = "application/json";
    }

    public class QueryRequestTextToSpeech
    {
        [JsonPropertyName("Url")]
        public string Url { get; set; } = "https://api-inference.huggingface.co/models/wasmdashai/vits-ar-sa-huba-v2";

        [JsonPropertyName("Headers")]
        public QueryRequestTextToSpeechHeader Headers { get; set; } = new QueryRequestTextToSpeechHeader();

        [JsonPropertyName("Method")]
        public string Method { get; set; } = "POST";

        [JsonPropertyName("Data")]
        public string Data { get; set; } = "السلام عليكم ورحمة الله";

        [JsonPropertyName("TagId")]
        public string TagId { get; set; } = "OutputPlayerId";
    }
}
