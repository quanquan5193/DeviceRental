using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRental.Models
{
    public class Employee
    {
        public Employee()
        {
            DeviceRentals = new HashSet<DeviceRental>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public virtual ICollection<DeviceRental> DeviceRentals { get; set; }
    }
}
