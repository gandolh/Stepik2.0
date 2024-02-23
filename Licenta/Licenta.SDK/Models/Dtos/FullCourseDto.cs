using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.SDK.Models.Dtos
{
    public class FullCourseDto : CourseDto, IDtoWithId
    {
        public List<FullModuleDto> Modules { get; set; } = new();
        public List<PortalUserDto> Teachers { get; set; } = new();
        public List<PortalUserDto> Students { get; set; } = new();
    }
}
