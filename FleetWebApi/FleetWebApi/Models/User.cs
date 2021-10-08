﻿namespace FleetWebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Account Account { get; set; }
    }
}
