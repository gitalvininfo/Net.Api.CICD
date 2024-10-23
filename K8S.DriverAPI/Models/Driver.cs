﻿

namespace K8S.DriverAPI.Models
{
    public class Driver : BaseEntity
    {
        public Driver()
        {
            Achievements = [];
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int DriverNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Achievement>? Achievements { get; set; }
    }
}
