using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiplomaDataModel.Option;

namespace OptionsWebSite.Controllers
{
    public class ChoicesController : Controller
    {
        private OptionContext db = new OptionContext();

        // GET: Choices
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var choices = db.Choices.Include(c => c.FirstOption).Include(c => c.FourthOption).Include(c => c.SecondOption).Include(c => c.ThirdOption).Include(c => c.YearTerm);

            ViewBag.validYearTerms = populateDropDown();

            return View(choices.ToList());
        }

        private List<SelectListItem> populateDropDown()
        {
            List<SelectListItem> validYearTerms = new List<SelectListItem>();
            var isDefaultYearTerm = db.YearTerms.Where(y => y.IsDefault.Equals(true)).FirstOrDefault();
            SelectListItem isDefaultItem = new SelectListItem()
            {
                Text = isDefaultYearTerm.Year + " " + getTerm(isDefaultYearTerm.Term),
                Value = isDefaultYearTerm.YearTermId.ToString()
            };
            validYearTerms.Add(isDefaultItem);

            var listYearTerms = db.YearTerms.ToList();
            foreach (YearTerm yearTerm in listYearTerms)
            {
                if (!yearTerm.IsDefault)
                {
                    var term = getTerm(yearTerm.Term);
                    SelectListItem temp = new SelectListItem
                    {
                        Text = yearTerm.Year + " " + term,
                        Value = yearTerm.YearTermId.ToString()
                    };
                    validYearTerms.Add(temp);
                }
            }
            return validYearTerms;
        }

        private string getTerm(int termNumber)
        {
            var term = "";
            if (termNumber == 30)
            {
                term = "Fall";
            }
            else if (termNumber == 20)
            {
                term = "Spring/Summer";
            }
            else
            {
                term = "Winter";
            }
            return term;
        }

        public string getCurrentTerm()
        {
            var vend = (from vnd in db.YearTerms
                        where vnd.IsDefault == true
                        select vnd).First(); 
            string result = "";
            if (vend.Term == 10)
            {
                result = "Winter";
            } else if (vend.Term == 20)
            {
                result = "Spring/Summer";
            }
            else
            {
                result = "Fall";
            }
            return vend.Year + " " + result;
        }

        private bool validChoice(Choice choice)
        {
            // Check for non-duplicate options
            List<int> ChoiceList = new List<int>();
            ChoiceList.Add((int)choice.FirstChoiceOptionId);
            ChoiceList.Add((int)choice.SecondChoiceOptionId);
            ChoiceList.Add((int)choice.ThirdChoiceOptionId);
            ChoiceList.Add((int)choice.FourthChoiceOptionId);

            if (ChoiceList.Count != ChoiceList.Distinct().Count())
            {
                return false;
            }
            return true;
        }

        private bool checkChoices(Choice choice)
        {
            /*
            int result = db.Choices.Where(c => c.StudentId == choice.StudentId
            && c.YearTermId == choice.YearTermId).Count();

            if (result == 0)
            {
                return true;
            }
            return false;
            */
            int termId = getActive();
            int vend = (from vnd in db.Choices
                        where vnd.YearTermId == termId && vnd.StudentId == choice.StudentId
                        select vnd).Count();
            if (vend == 0)
                return true;
            return false;
        }

        public int getActive()
        {
            var vend = (from vnd in db.YearTerms
                        where vnd.IsDefault == true
                        select vnd).First();
            return vend.YearTermId;
        }

        public IEnumerable<Option> getCurrentCourses()
        {
            List<Option> list = null;
            var vend = (from vnd in db.Options
                        where vnd.IsActive == true
                        select vnd);
            list = vend.ToList();
            return list;
        }

        // GET: Choices/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var choice = db.Choices.Include(c => c.FirstOption).Include(c => c.FourthOption).Include(c => c.SecondOption).Include(c => c.ThirdOption).Include(c => c.YearTerm);
            Choice finalChoice = choice.Where(c => c.ChoiceId == id).First();
            if (finalChoice == null)
            {
                return HttpNotFound();
            }
            return View(finalChoice);
        }

        // GET: Choices/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CurrentTerm = getCurrentTerm();
            ViewBag.StudentId = User.Identity.Name;
            ViewBag.FirstChoiceOptionId = new SelectList(getCurrentCourses(), "OptionId", "Title");
            ViewBag.FourthChoiceOptionId = new SelectList(getCurrentCourses(), "OptionId", "Title");
            ViewBag.SecondChoiceOptionId = new SelectList(getCurrentCourses(), "OptionId", "Title");
            ViewBag.ThirdChoiceOptionId = new SelectList(getCurrentCourses(), "OptionId", "Title");
            ViewBag.YearTermId = new SelectList(db.YearTerms, "YearTermId", "YearTermId");
            return View();
        }

        // POST: Choices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChoiceId,YearTermId,StudentId,StudentFirstName,StudentLastName,FirstChoiceOptionId,SecondChoiceOptionId,ThirdChoiceOptionId,FourthChoiceOptionId,SelectionDate")] Choice choice)
        {
            bool validInput = true;
            if (!validChoice(choice))
            {
                ModelState.AddModelError("", "No Duplication Options");
                validInput = false;
            }

            if (validInput && checkChoices(choice) == false)
            {
                ModelState.AddModelError("", "Can only pick options once");
                validInput = false;
            }


            if (ModelState.IsValid && validInput)
            {
                choice.YearTermId = getActive();
                db.Choices.Add(choice);
                db.SaveChanges();
                return Redirect("/Home/Index");
            }

            ViewBag.FirstChoiceOptionId = new SelectList(getCurrentCourses(), "OptionId", "Title");
            ViewBag.FourthChoiceOptionId = new SelectList(getCurrentCourses(), "OptionId", "Title");
            ViewBag.SecondChoiceOptionId = new SelectList(getCurrentCourses(), "OptionId", "Title");
            ViewBag.ThirdChoiceOptionId = new SelectList(getCurrentCourses(), "OptionId", "Title");
            ViewBag.YearTermId = new SelectList(db.YearTerms, "YearTermId", "YearTermId");
            ViewBag.CurrentTerm = getCurrentTerm();
            ViewBag.StudentId = User.Identity.Name;
            return View(choice);
        }

        // GET: Choices/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirstChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.FirstChoiceOptionId);
            ViewBag.FourthChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.FourthChoiceOptionId);
            ViewBag.SecondChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.SecondChoiceOptionId);
            ViewBag.ThirdChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.ThirdChoiceOptionId);
            ViewBag.YearTermId = new SelectList(db.YearTerms, "YearTermId", "YearTermId", choice.YearTermId);
            return View(choice);
        }

        // POST: Choices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ChoiceId,YearTermId,StudentId,StudentFirstName,StudentLastName,FirstChoiceOptionId,SecondChoiceOptionId,ThirdChoiceOptionId,FourthChoiceOptionId,SelectionDate")] Choice choice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(choice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FirstChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.FirstChoiceOptionId);
            ViewBag.FourthChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.FourthChoiceOptionId);
            ViewBag.SecondChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.SecondChoiceOptionId);
            ViewBag.ThirdChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.ThirdChoiceOptionId);
            ViewBag.YearTermId = new SelectList(db.YearTerms, "YearTermId", "YearTermId", choice.YearTermId);
            return View(choice);
        }

        // GET: Choices/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var choice = db.Choices.Include(c => c.FirstOption).Include(c => c.FourthOption).Include(c => c.SecondOption).Include(c => c.ThirdOption).Include(c => c.YearTerm);
            Choice finalChoice = choice.Where(c => c.ChoiceId == id).First();
            if (finalChoice == null)
            {
                return HttpNotFound();
            }
            return View(finalChoice);
        }

        // POST: Choices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Choice choice = db.Choices.Find(id);
            db.Choices.Remove(choice);
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
