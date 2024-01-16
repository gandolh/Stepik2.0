using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.SDK.Models.Dtos
{
    public class FullCourseDto : CourseDto
    {
        public List<ModuleDto> Modules { get; set; } = new(); 
    }
}
