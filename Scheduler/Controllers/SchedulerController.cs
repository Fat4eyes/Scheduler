﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Scheduler.Models;

namespace Scheduler.Controllers
{
    public class SchedulerController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (TaskContext db = new TaskContext())
            {
                return View(db.Tasks.ToList());
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Task task)
        {
            using (TaskContext db = new TaskContext())
            {
                if (ModelState.IsValid)
                {
                    db.Tasks.Add(task);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(task);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (TaskContext db = new TaskContext())
            {
                Task task = db.Tasks.Find(id);

                if (task == null)
                {
                    return HttpNotFound();
                }
                return View(task);
            }
        }

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            using (TaskContext db = new TaskContext())
            {
                if (ModelState.IsValid)
                {
                    Task oldTask = db.Tasks.Find(task.TaskId);

                    oldTask.Topic = task.Topic;
                    oldTask.Note = task.Note;
                    oldTask.Date = task.Date;

                    //db.Entry(task).State = EntityState.Modified;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(task);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (TaskContext db = new TaskContext())
            {
                Task task = db.Tasks.Find(id);

                if (task == null)
                {
                    return HttpNotFound();
                }

                return View(task);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (TaskContext db = new TaskContext())
            {
                Task task = db.Tasks.Find(id);

                db.Tasks.Remove(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}
