﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prj666vc.Controllers
{
    public class VirtualClassController : Controller
    {
        //
        // GET: /VirtualClass/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /VirtualClass/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult CourseList()
        {
            return View();
        }

        public ActionResult SearchCourse()
        {
            return View();
        }

        //
        // GET: /VirtualClass/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /VirtualClass/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /VirtualClass/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /VirtualClass/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /VirtualClass/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /VirtualClass/Delete/5

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
