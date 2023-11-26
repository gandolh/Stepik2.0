using Licenta.Sdk.Models.Interfaces;

namespace Licenta.Sdk.Models.Dtos
{
    public class WithTrackDataDto : IWithTrackDataDto
    {
        public string OpId { get; set; } = "";
        public string SessionId { get; set; } = "";
    }
}
