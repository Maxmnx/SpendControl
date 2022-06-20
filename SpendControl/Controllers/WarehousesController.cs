using Microsoft.AspNetCore.Mvc;
using SpendControl.Data;
using SpendControl.Models;
using System.Collections.Generic;
using System.Linq;

namespace SpendControl.Controllers
{
    public class WarehousesController : Controller
    {

        private readonly ApplicationDbContext _db;

        public WarehousesController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            List<UserWarehouse> warehouses = new List<UserWarehouse>(_db.UserWarehouses);
            
            string userName = this.User.Identity.Name;
            List<UserWarehouse> filteredWarehouses = warehouses.FindAll(x => x.UserName.Equals(userName));

            foreach(UserWarehouse warehouse in filteredWarehouses)
            {
                warehouse.Warehouse = _db.Warehouses.Find(warehouse.WarehouseId);
            }

            return View(filteredWarehouses);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Warehouse warehouse)
        {
            
            warehouse.CreatorName = this.User.Identity.Name;
            _db.Warehouses.Add(warehouse);
            UserWarehouse userWarehouse = new UserWarehouse();
            userWarehouse.UserName = this.User.Identity.Name;
            userWarehouse.Warehouse = warehouse;
            userWarehouse.canDelete = true;
            userWarehouse.canEdit = true;
            userWarehouse.canAddMaterials = true;
            userWarehouse.canUseMaterials = true;
            userWarehouse.canDeleteMaterials = true;
            _db.UserWarehouses.Add(userWarehouse);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public IActionResult Delete(int? id)
        {
            if(id != null)
            {
                Warehouse toDelete = _db.Warehouses.Find(id);
                if(toDelete == null)
                {
                    return NotFound();
                }
                _db.Warehouses.Remove(toDelete);
                _db.SaveChanges(true);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Warehouse toEdit = _db.Warehouses.Find(id);
            if(toEdit == null)
            {
                return NotFound();
            }

            return View(toEdit);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Warehouse warehouse)
        {

            _db.Warehouses.Update(warehouse);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


        public IActionResult Open(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Warehouse toEdit = _db.Warehouses.Find(id);
            if (toEdit == null)
            {
                return NotFound();
            }

            return RedirectToRoute(new { action = "Index", controller = "Materials", id });
        }

    }
}

