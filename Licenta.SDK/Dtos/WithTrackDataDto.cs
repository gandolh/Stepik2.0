using Licenta.SDK.Interfaces;

namespace Licenta.SDK.Dtos
{
    public class WithTrackDataDto : IWithTrackDataDto
    {
        public string OpId { get; set; } = "";
        public string SessionId { get; set; } = "";
    }
}
