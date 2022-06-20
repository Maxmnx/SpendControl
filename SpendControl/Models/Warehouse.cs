using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpendControl.Models
{
    public class Warehouse
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string CreatorName { get; set; }

        public List<Material> Materials { get; set; } = new List<Material>();


        public void AddMaterials(List<Material> materials)
        {
            if(materials == null)
            {
                return;
            }

            foreach(Material material in materials)
            {
                material.Id = Id;
            }

            /*foreach(var newMaterial in materials)
            {
                if(Materials.Exists(x => x.Name.Equals(newMaterial.Name)))
                {
                    Material material = Materials.Find(x => x.Name.Equals(newMaterial.Name));
                    if(material != null)
                    {
                        material.Quantity += newMaterial.Quantity;
                    }
                }
                else
                {

                    newMaterial.WarehouseId = Id;
                    newMaterial.Warehouse = this;
                    Materials.Add(newMaterial);
                    materials.Remove(newMaterial);
                }
            }*/

            //return materials;
        }
    }
}
