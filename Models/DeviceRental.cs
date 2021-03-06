using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceRental.Models
{
    public class DeviceRental
    {
        [Key, Column(Order = 0)]
        public int DeviceId { get; set; }
        [Key, Column(Order = 1)]
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Device Device { get; set; }
        public Employee Employee { get; set; }
    }
}
