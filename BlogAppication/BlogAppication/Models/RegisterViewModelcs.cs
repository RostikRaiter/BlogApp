﻿namespace BlogApplication.Models
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; } // Add this line
    }
}