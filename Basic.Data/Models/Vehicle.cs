using Basic.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Basic.Data.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [Range(0, 2000)]
        public double Power { get; set; }
        [StringLength(10)]
        public string NumberPlate { get; set; }
        public VehicleType VehicleType{ get; set; }
    }
}
