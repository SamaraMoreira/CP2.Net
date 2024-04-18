﻿using System.ComponentModel.DataAnnotations;

namespace CP2.Net.DTOs
{
    public record RegisterDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "As senhas não coincidem.")]
        public string ComparePassword { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
