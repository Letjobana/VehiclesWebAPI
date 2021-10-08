using System.Collections.Generic;

namespace FleetWebApi.Models
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
