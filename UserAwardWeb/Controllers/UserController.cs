﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserAwardWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Rewarding()
        {
            return View();
        }

        public ActionResult GetAwardsByUser()
        {
            return View();
        }
    }
}