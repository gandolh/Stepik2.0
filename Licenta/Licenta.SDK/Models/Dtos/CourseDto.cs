﻿namespace Licenta.SDK.Models.Dtos
{
    public class CourseDto : IDtoWithId
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
    }
}
