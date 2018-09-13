using CRUDwithStaticData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDwithStaticData.Controllers
{
    public class HomeController : Controller
    {
        public List<Member> lstMemeber
        {
            get
            {
                return (Session["ListMember"] != null) ? (List<Member>)Session["ListMember"] : new List<Member>();
            }
            set
            {
                Session["ListMember"] = value;
            }
        }

        public ActionResult Index()
        {
            List<Member> tempMember = lstMemeber;

            lstMemeber = tempMember;

            return View(lstMemeber);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member member)
        {
            List<Member> tempMember = lstMemeber;

            tempMember.Add(member);

            lstMemeber = tempMember;

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var tempMember = lstMemeber.Where(x => x.Id == id).First();

            return View(tempMember);
        }

        [HttpPost]
        public ActionResult Edit(Member member)
        {
            List<Member> tempMember = lstMemeber;

            for (int i = 0; i < tempMember.Count; i++)
            {
                if (tempMember[i].Id == member.Id)
                {
                    tempMember[i].Name = member.Name;
                    tempMember[i].Address = member.Address;
                    tempMember[i].Age = member.Age;
                    break;
                }
            }

            lstMemeber = tempMember;

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var tempMember = lstMemeber.Where(x => x.Id == id).First();

            return View(tempMember);
        }

        [HttpPost]
        public ActionResult Delete(int id, Member member)
        {
            lstMemeber = lstMemeber.Where(x => x.Id != id).ToList();
            
            return RedirectToAction("Index");
        }
    }
}