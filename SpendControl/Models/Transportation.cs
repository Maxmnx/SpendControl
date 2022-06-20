using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpendControl.Models
{
    public class Transportation
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        [Required]
        public int SenderWarehouseId { get; set; }
        [Required]
        public Warehouse SenderWarehouse { get; set; }

        [Required]
        public int TargetWarehouseId { get; set; }
        [Required]
        public Warehouse TargetWarehouse { get; set; }

        [Required]
        public int TransportWarehouseId { get; set; }
        [Required]
        public Warehouse TransportWarehouse { get; set; }
        public DateTime SendDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public bool IsArrived { get; set; }

    }
}
