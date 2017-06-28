using Newtonsoft.Json;

namespace DragonsOfMugloar.DTOs
{
    public class DragonDto
    {
        [JsonProperty(PropertyName = "scaleThickness")]
        public int ScaleThickness { get; set; }

        [JsonProperty(PropertyName = "clawSharpness")]
        public int ClawSharpness { get; set; }

        [JsonProperty(PropertyName = "wingStrength")]
        public int WingStrength { get; set; }

        [JsonProperty(PropertyName = "fireBreath")]
        public int FireBreath { get; set; }
    }
}
