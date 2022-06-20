using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpendControl.Data;
using SpendControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpendControl.Controllers
{
    public class TransportationsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public TransportationsController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            List<Transportation> transportations = new List<Transportation>(_db.Transportations);

            List<UserWarehouse> warehouses = new
                List<UserWarehouse>(_db.UserWarehouses.Where(x => x.UserName.Equals(this.User.Identity.Name)));


            List<Transportation> filteredTransportations = new List<Transportation>();

            foreach(var transportation in transportations)
            {
                if (transportation != null)
                {
                    transportation.SenderWarehouse = _db.Warehouses.Find(transportation.SenderWarehouseId);
                    transportation.TargetWarehouse = _db.Warehouses.Find(transportation.TargetWarehouseId);
                    if (warehouses.Any(x => x.WarehouseId == transportation.TargetWarehouseId) ||
                        warehouses.Any(x => x.WarehouseId == transportation.SenderWarehouseId))
                    {
                        filteredTransportations.Add(transportation);
                    }
                }
            }

            return View(filteredTransportations);
        }

        public IActionResult Create()
        {
            /*List<UserWarehouse> warehouses = new List<UserWarehouse>(_db.UserWarehouses.Where(x => x.UserName.Equals(this.User.Identity.Name)));
            ViewData["Warehouses"] = from warehouse in warehouses
                                     select new SelectListItem { Text = warehouse.Warehouse.Name, Value = warehouse.WarehouseId.ToString() };*/

            var model = new ViewTransportationModel();

            model.Transportation = new Transportation();
            model.Warehouses = from warehouse in _db.UserWarehouses
                               where warehouse.UserName.Equals(this.User.Identity.Name)
                               select new SelectListItem { Text = warehouse.Warehouse.Name, Value = warehouse.WarehouseId.ToString() };
                           

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ViewTransportationModel model)
        {
            model.Transportation.SenderWarehouse = _db.Warehouses.Find(model.SenderWarehouseId);

            model.Transportation.SenderWarehouse.Materials = 
                new List<Material>(_db.Materials.Where(x => x.WarehouseId == model.SenderWarehouseId));

            model.Transportation.TargetWarehouse = _db.Warehouses.Find(model.TargetWarehouseId);
            Warehouse transportWarehouse = new Warehouse();

            transportWarehouse.CreatorName = "";
            
            transportWarehouse.Address = "transport";
            transportWarehouse.Name = "transport";
            transportWarehouse.Description = "transport";
            _db.Warehouses.Add(transportWarehouse);
            _db.SaveChanges();

            model.Transportation.TransportWarehouse = transportWarehouse;

            foreach (var material in model.Transportation.SenderWarehouse.Materials)
            {
                model.Transportation.TransportWarehouse.Materials.Add(material);
                //model.Transportation.SenderWarehouse.Materials.Remove(material);
            }
            
            Transportation transport = model.Transportation;

            transport.SendDate = DateTime.Now;
            transport.IsArrived = false;
            transport.SenderWarehouseId = model.SenderWarehouseId;
            
            transport.TargetWarehouseId = model.TargetWarehouseId;
            
            transport.TransportWarehouseId = transportWarehouse.Id;
            

            _db.Transportations.Add(model.Transportation);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


        public IActionResult Accept(int? id)
        {
            
            if (id != null)
            {
                Transportation toAccept = _db.Transportations.Find(id);
                if (toAccept == null)
                {
                    return NotFound();
                }
                Warehouse transport = toAccept.TransportWarehouse = _db.Warehouses.Find(toAccept.TransportWarehouseId);
                Warehouse target = toAccept.TargetWarehouse = _db.Warehouses.Find(toAccept.TargetWarehouseId);

                transport.Materials =
                new List<Material>(_db.Materials.Where(x => x.WarehouseId == toAccept.TransportWarehouseId));
                foreach(var material in transport.Materials)
                {
                    target.Materials.Add(material);
                }
                
                toAccept.ArrivalDate = DateTime.Now;
                toAccept.IsArrived = true;

                _db.SaveChanges();
            }

            return RedirectToAction("Index");
            
        }

    }

    public class ViewTransportationModel
    {
        public Transportation Transportation { get; set; }

        public IEnumerable<SelectListItem> Warehouses { get; set; }

        public int SenderWarehouseId { get; set; }

        public int TargetWarehouseId { get; set; }

    }
}
