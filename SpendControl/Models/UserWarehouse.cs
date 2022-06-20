using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpendControl.Models
{
    public class UserWarehouse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        [Required]
        public bool canEdit { get; set; }

        [Required]
        public bool canDelete { get; set; }

        [Required]
        public bool canAddMaterials { get; set; }

        [Required]
        public bool canUseMaterials { get; set; }

        [Required]
        public bool canDeleteMaterials { get; set; }
    }
}
