using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperation.Controllers
{
    public class VegeController : Controller
    {
        DbDataContext dc = new DbDataContext();
        // GET: Vege
        public ActionResult Index()
        {

            var VegetableDetails = from x in dc.VegeDatas select x;
            return View(VegetableDetails);
        }

        // GET: Vege/Details/5
        public ActionResult Details(int id)
        {
            var getVegeDetails = dc.VegeDatas.Single(x => x.Veg_id == id);
            return View(getVegeDetails);
        }
    

        // GET: Vege/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vege/Create
        [HttpPost]
        
        public ActionResult Create(VegeData Collection)
        {
           
            try
            {
                // TODO: Add insert logic here
                dc.VegeDatas.InsertOnSubmit(Collection);
                dc.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Vege/Edit/5
        public ActionResult Edit(int id)
        {

            var getVegeDetails = dc.VegeDatas.Single(x => x.Veg_id == id);
            return View(getVegeDetails);

        }

        // POST: Vege/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VegeData collection)
        {
            try
            {
                // TODO: Add update logic here
                VegeData vegitableUpdate = dc.VegeDatas.Single(x => x.Veg_id == id);
                vegitableUpdate.VegetableName = collection.VegetableName;
                vegitableUpdate.VegetableType = collection.VegetableType;
                vegitableUpdate.VegetablePrice = collection.VegetablePrice;
                vegitableUpdate.FarmerName = collection.FarmerName;
                vegitableUpdate.ProductionState = collection.ProductionState;
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vege/Delete/5
        public ActionResult Delete(int id)
        {
            var getVegeDetails = dc.VegeDatas.Single(x => x.Veg_id == id);
            return View(getVegeDetails);

        }

        // POST: Vege/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, VegeData collection)
        {

            try
            {

                var VegetableDelete = dc.VegeDatas.Single(x => x.Veg_id == id);
                dc.VegeDatas.DeleteOnSubmit(VegetableDelete);
                // TODO: Add delete logic here
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
