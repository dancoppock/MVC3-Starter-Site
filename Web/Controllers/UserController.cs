using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Infrastructure.Storage;

//Controller for a User
namespace Web.Controllers
{
    public class UserController : Controller
    {
        const int PageSize=10;
        ISession _session;
        public UserController(ISession session){
            _session=session;
        }

        public ActionResult Index(int? pg)
        {
            int pageIndex=0;
            if(pg.HasValue){
                pageIndex=pg.Value;
            }

            var items = _session.All<User>().OrderByDescending(x => x.CreatedOn);
            var list = new PagedList<User>(items, pageIndex, PageSize);
            return View(list);
        }


        public ActionResult Details(string id)
        {
            var guid = new Guid(id);
            var item = _session.Single<User>(x => x.ID == guid);
            return View(item);
        }


        //[Authorize(Roles="Administrator")]
        public ActionResult Create()
        {
            var item = new User();
            return View(item);
        } 


        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles="Administrator")]
        public ActionResult Create(FormCollection collection)
        {
            
            //var item = new User();
            var item = new User() { CreatedOn = DateTime.Now};

            //please don't omit this...
            var whiteList=new string[]{"UserName","OpenID","Friendly","LastLogin","ModifiedOn"};
            UpdateModel(item,whiteList,collection.ToValueProvider());

            var dummy = item;

            if(ModelState.IsValid){
                try
                {
                    _session.Add<User>(item);
                    _session.CommitChanges();
                    this.FlashInfo("User saved...");
                    return RedirectToAction("Index");
                }
                catch
                {
                    this.FlashError("There was an error saving this record");
                    return View(item);
                }
            }
            return View(item);

        }
 
        //[Authorize(Roles="Administrator")]
        public ActionResult Edit(string id)
        {
            var guid = new Guid(id);
            var item = _session.Single<User>(x => x.ID == guid);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles="Administrator")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var guid = new Guid(id);
            var item = _session.Single<User>(x => x.ID == guid);
            //please don't omit this...
            var whiteList=new string[]{"OpenID","Friendly"};
            UpdateModel(item,whiteList,collection.ToValueProvider());

            if(ModelState.IsValid){
                try
                {
                    _session.Update<User>(item);
                    _session.CommitChanges();
                    this.FlashInfo("User saved...");
                    return RedirectToAction("Index");
                }
                catch
                {
                    this.FlashError("There was an error saving this record");
                    return View(item);
                }
            }
            return View(item);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles="Administrator")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var guid = new Guid(id);
            var item = _session.Single<User>(x => x.ID == guid);
            try
            {
                _session.Delete<User>(item);
                _session.CommitChanges();
                this.FlashInfo("User deleted...");
                return RedirectToAction("Index");
            }
            catch
            {
                this.FlashError("There was an error deleting this record");
                return View("Edit",item);
            }
        }
    }
}
