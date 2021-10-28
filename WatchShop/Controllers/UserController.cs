using BotDetect.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WatchShop.EntityFramework;
using WatchShop.Models;

namespace WatchShop.Controllers
{
    public class UserController : Controller
    {
        WatchShopContext db = new WatchShopContext();
        // GET: User
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "RegisterCapcha", "Mã captcha không đúng!")]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Count(x => x.UserName == model.UserName) > 0)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (db.Users.Count(x => x.Email == model.Email) > 0)
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.Name = model.Name;
                    user.Password = model.Password;
                    user.Phone = model.Phone;
                    user.Email = model.Email;
                    user.Address = model.Address;
                    user.CreatedDate = DateTime.Now;
                    user.Status = true;
                    user.UserRoleId = Common.CommonConst.MemberId;
                    if (!string.IsNullOrEmpty(model.ProvinceID))
                    {
                        user.ProvinceId = int.Parse(model.ProvinceID);
                    }
                    if (!string.IsNullOrEmpty(model.DistrictID))
                    {
                        user.DistrictId = int.Parse(model.DistrictID);
                    }
                    try
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                        ViewBag.Success = "Đăng ký thành công";
                        model = new Register();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");

                        //debug
                        foreach (var eve in ex.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        throw;
                    }
                }
                MvcCaptcha.ResetCaptcha("registerCapcha");
            }
            else
            {

            }    
            return View(model);
        }
        public JsonResult LoadProvince()
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/assets/client/data/Provinces_Data.xml"));

            var xElements = xmlDoc.Element("Root").Elements("Item").Where(x => x.Attribute("type").Value == "province");
            var list = new List<Province>();
            Province province = null;
            foreach (var item in xElements)
            {
                province = new Province();
                province.ID = int.Parse(item.Attribute("id").Value);
                province.Name = item.Attribute("value").Value;
                list.Add(province);

            }
            return Json(new
            {
                data = list,
                status = true
            });
        }
        public JsonResult LoadDistrict(int provinceID)
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/assets/client/data/Provinces_Data.xml"));

            var xElement = xmlDoc.Element("Root").Elements("Item")
                .Single(x => x.Attribute("type").Value == "province" && int.Parse(x.Attribute("id").Value) == provinceID);

            var list = new List<District>();
            District district = null;
            foreach (var item in xElement.Elements("Item").Where(x => x.Attribute("type").Value == "district"))
            {
                district = new District();
                district.ID = int.Parse(item.Attribute("id").Value);
                district.Name = item.Attribute("value").Value;
                district.ProvinceID = int.Parse(xElement.Attribute("id").Value);
                list.Add(district);

            }
            return Json(new
            {
                data = list,
                status = true
            });
        }
    }
}