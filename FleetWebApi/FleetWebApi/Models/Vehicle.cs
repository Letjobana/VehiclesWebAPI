using System;

namespace FleetWebApi.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public string LicenseNumber { get; set; }
        public string RegistrationPlate { get; set; }
        public DateTime LicenseExpiry { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}
