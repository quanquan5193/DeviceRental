using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceRental.Models
{
    public class Device
    {
        public Device()
        {
            DeviceRentals = new HashSet<DeviceRental>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string DeviceName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<DeviceRental> DeviceRentals { get; set; }
    }
}
