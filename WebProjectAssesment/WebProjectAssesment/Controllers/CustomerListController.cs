using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProjectAssesment.Controllers
{
    [Authorize]// only authorize user can have acces of CustomerList Controller
    public class CustomerListController : Controller
    {
        //Conecting the database using entity model
        webDatabaseEntities db=new webDatabaseEntities();

        // GET: CustomerList
        public ActionResult Index(int id = 0)
        {
            //Return the customer record to view
            ViewBag.CustomerList=db.tblCustomers.ToList();

            //check is id is present in view /if present then send  data of that Id to view
            if (id > 0)
            {
                tblCustomer obj = db.tblCustomers.Find(id);
                if (obj != null)
                {
                    return View(obj);
                }
            }
            return View();
        }

        
        [HttpPost]
        //POST: customers data in database
        public ActionResult SaveCust(tblCustomer cust)
        {
            //Validate the Model State
            if (ModelState.IsValid)
            {
                try
                {   //check user is valid
                    if (User.Identity.IsAuthenticated)
                    {
                        //attach object of customer model
                        var customer = db.tblCustomers.Attach(cust);

                        //if id is present it update the database or Id is not present then it Save data in database
                        db.Entry(cust).State = cust.Id > 0 ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;

                        //commit the Transaction of database
                        db.SaveChanges();

                        // return message to the view
                        ViewData["msg"] = "Saved succesfully.";   
                        
                    }

                }
                catch (Exception er)
                {
                    return View(er.Message);
                }
            }
            //return the updated List to View
            ViewBag.CustomerList = db.tblCustomers.ToList();

            //Clear the ModelState
            ModelState.Clear();

            
            return RedirectToAction("index");

        }

        // this Function Delete record from database    
        [HttpGet]
        public ActionResult DeleteCust(int id)        {

            try
            {   //find data using selected id from the database 
                tblCustomer obj = db.tblCustomers.Find(id);
                if (obj != null)
                {
                    //Delete Record from database
                    db.tblCustomers.Remove(obj);

                    db.SaveChanges();
                    TempData["msg"] = "Deleted Sucsessfully.";
                }

            }
            catch (Exception er)
            {
                return View(er.Message);
            }

            return RedirectToAction("index","customerList");
        }







    }







}