﻿namespace Licenta.SDK.Models.Dtos
{
    public class RegisterReqDto
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int UserType { get; set; } = 0;
    }
}
