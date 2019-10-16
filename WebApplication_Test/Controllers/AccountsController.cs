using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_Test.Models;

namespace WebApplication_Test.Controllers
{
    public class AccountsController : Controller
    {
        ConnectDB db = new ConnectDB();
        // GET: Accounts
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(String Email, String Password)
        {
            if (ModelState.IsValid)
            {
                // lấy user đăng nhâp theo email và  pass
                var _u = db.Users.FirstOrDefault(x => x.Email == Email && x.Password == Password);
                if (_u != null)
                {
                    //int id;
                    //user u = db.users.singleordefault(x=>x.userid==id);
                    
                    Session["user"] = _u;
                    return RedirectToAction("Details", new { id=_u.userId});
                }
                else
                {
                    // null =>  đăng nhập sai
                    ModelState.AddModelError("", "Email or Password no exist!");
                   
                    return View();
                }
                

            }
            return View();
        }

        //Logout
        public ActionResult Logout()
        {
            Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Users.Find(id));
        }

        // GET: Accounts/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Accounts/Create
        [HttpPost]
        public ActionResult Register(User u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    db.Users.Add(u);
                    db.SaveChanges();
                    return RedirectToAction("Details",new { id=u.userId});

                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int id)
        {

            return View(db.Users.Find(id));
        }

        // POST: Accounts/Edit/5
        [HttpPost]
        public ActionResult Edit( User u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (u.FirstName==null)
                    {
                        ModelState.AddModelError("", "The FirstName cannot be empty!");
                       
                        return View();
                    }
                    if (u.LastName == null)
                    {
                        ModelState.AddModelError("", "The LastName cannot be empty!");
                       
                        return View();
                    }
                    if (u.Phone == null)
                    {
                        ModelState.AddModelError("", "The Phone cannot be empty!");
                        
                        return View();
                    }
                    if (u.Birthday == null)
                    {
                        ModelState.AddModelError("", "The Birthday cannot be empty!");
                        
                        return View();
                    }
                    var file = Request.Files["Avatar"];
                    if (file != null && file.ContentLength > 0)
                    {
                        string fileName = file.FileName;
                        // tạo đường dẫn lưu file
                        string path = Server.MapPath(@"~/Content/Upload/imageUser/") + fileName;
                        // lưu
                        file.SaveAs(path);
                        // gán avatar  bằng đường dẫn
                        u.Avatar = fileName;
                    }
                    db.Entry(u).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Session["user"] = u;
                    return RedirectToAction("Details",new { id =u.userId });
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Accounts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
