using Newtonsoft.Json;

namespace DragonsOfMugloar.DTOs
{
    [JsonObject(Title = "dragon")]
    public class DragonDtoWrapper
    {
        [JsonProperty(PropertyName = "dragon")]
        public DragonDto Dragon { get; set; }
    }
}