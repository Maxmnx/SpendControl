using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpendControl.Data;
using SpendControl.Models;
using System.Collections.Generic;
using System.Linq;

namespace SpendControl.Controllers
{
    public class MaterialsController : Controller
    {

        private readonly ApplicationDbContext _db;
        private static Warehouse _warehouse;
        private readonly UserManager<User> _userManager;

        public MaterialsController(ApplicationDbContext db, UserManager<User> users)
        {
            _db = db;
            _userManager = users;
        }

        public IActionResult Index(int id)
        {
            IEnumerable<Material> rawMaterials = _db.Materials;
            _warehouse = _db.Warehouses.Find(id);

            List<Material> materials = new List<Material>();
            foreach (Material ьaterial in rawMaterials)
            {
                if (ьaterial.WarehouseId == id)
                {
                    materials.Add(ьaterial);
                }
            }
            return View(_warehouse);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Material material)
        {
            
            material.Warehouse = _warehouse;
            material.WarehouseId = _warehouse.Id;
            _db.Warehouses.Find(_warehouse.Id).Materials.Add(material);
            _db.SaveChanges();

            int warehouseId = material.Warehouse.Id;
            return RedirectToRoute(new { action = "Index", controller = "Materials", id= material.Warehouse.Id });

        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Material toDelete = _db.Materials.Find(id);
                if (toDelete == null)
                {
                    return NotFound();
                }
                _db.Materials.Remove(toDelete);
                _db.SaveChanges(true);
            }

            return RedirectToRoute(new { action = "Index", controller = "Materials", id = _warehouse.Id });
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Material toEdit = _db.Materials.Find(id);
            if (toEdit == null)
            {
                return NotFound();
            }

            return View(toEdit);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Material rawMaterial)
        {

            _db.Materials.Update(rawMaterial);
            _db.SaveChanges();
            return RedirectToRoute(new { action = "Index", controller = "Materials", id = _warehouse.Id });

        }

        public IActionResult AddUsers()
        {

            List<UserWarehouse> userWarehouses = new List<UserWarehouse>(_db.UserWarehouses.Where(x => x.WarehouseId == _warehouse.Id));
            List<User> users = new List<User>(_userManager.Users);

            List<UserViewModel> userViews = new List<UserViewModel>();

            

            foreach (UserWarehouse user in userWarehouses)
            {
                userViews.Add(new UserViewModel()
                {
                    Username = user.UserName,
                    WarehouseId = user.WarehouseId,
                    canEdit = user.canEdit,
                    canDelete = user.canDelete,
                    canAddMaterials = user.canAddMaterials,
                    canUseMaterials = user.canUseMaterials,
                    canDeleteMaterials = user.canDeleteMaterials,
                    existed = true
                });
            }

            foreach(var user in users)
            {
                if (!userViews.Any(x => x.Username.Equals(user.UserName))){
                    userViews.Add(new UserViewModel(){ 
                        Username = user.UserName, 
                        WarehouseId = _warehouse.Id, 
                    });
                }
            }

            var toRemove = userViews.Where(x => x.Username.Equals(this.User.Identity.Name));
            userViews.Remove(toRemove.First());

            return View(userViews);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUsers(IEnumerable<UserViewModel> userViews)
        {

            List<UserWarehouse> userWarehouses = 
                new List<UserWarehouse>(_db.UserWarehouses.Where(x => x.WarehouseId == _warehouse.Id));

            foreach(var userView in userViews)
            {
                if(userView.existed){
                    UserWarehouse userWarehouse = userWarehouses.Find(x => x.UserName.Equals(userView.Username));

                    userWarehouse.canEdit = userView.canEdit;
                    userWarehouse.canDelete = userView.canDelete;
                    userWarehouse.canAddMaterials = userView.canAddMaterials;
                    userWarehouse.canUseMaterials = userView.canUseMaterials;
                    userWarehouse.canDeleteMaterials = userView.canDeleteMaterials;

                    _db.UserWarehouses.Update(userWarehouse);
                }
                else
                {
                    UserWarehouse userWarehouse = new UserWarehouse();

                    userWarehouse.UserName = userView.Username;
                    userWarehouse.WarehouseId = _warehouse.Id;
                    userWarehouse.canEdit = userView.canEdit;
                    userWarehouse.canDelete = userView.canDelete;
                    userWarehouse.canAddMaterials = userView.canAddMaterials;
                    userWarehouse.canUseMaterials = userView.canUseMaterials;
                    userWarehouse.canDeleteMaterials = userView.canDeleteMaterials;

                    _db.UserWarehouses.Add(userWarehouse);
                }
            }
            
            _db.SaveChanges();
            return View("Index");

        }

    }

    public class UserViewModel
    {

        public string Username { get; set; }

        public int WarehouseId { get; set; }

        public bool canEdit { get; set; }

        public bool canDelete { get; set; }

        public bool canAddMaterials { get; set; }

        public bool canUseMaterials { get; set; }

        public bool canDeleteMaterials { get; set; }

        public bool existed { get; set; }

    }
}
