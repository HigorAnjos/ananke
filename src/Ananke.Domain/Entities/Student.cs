﻿using Ananke.Domain.ValueObjects;

namespace Ananke.Domain.Entities
{
    public class Student
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public CredentialsPuc Credentials { get; set; }

        public Student() 
        {
            Name = string.Empty; 
            Password = string.Empty; 
            Email = string.Empty;
            Credentials = new CredentialsPuc();
        }
    }
}
