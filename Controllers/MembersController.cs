using MemberApp.Models;
using MemberApp.ViewModels;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MemberApp.Controllers
{

    [Authorize]
    public class MembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Members

        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create

        public ActionResult Create()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddMemberViewModel viewMember)
        {
            if (ModelState.IsValid)
            {

                // we can also use auto mapper here
                var member = new Member();
                member.FirstName = viewMember.FirstName;
                member.LastName = viewMember.LastName;
                member.Email = viewMember.Email;
                member.BirthDate = viewMember.BirthDate;
                member.Country = viewMember.Country;
                member.City = viewMember.City;
                member.IsActive = viewMember.IsActive;
                member.IsMale = viewMember.IsMale;
                member.Notes = viewMember.Notes;
                member.PhoneNumber = viewMember.PhoneNumber;


                if (viewMember.UploadedImage != null && viewMember.UploadedImage.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(viewMember.UploadedImage.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/imgs"), fileName);
                    viewMember.UploadedImage.SaveAs(filePath);
                    member.PhotoPath = filePath;
                }



                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(viewMember);
        }







        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Create", member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,IsMale,BirthDate,Country,City,PhoneNumber,Email,Notes,IsActive,ProfileImage")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
