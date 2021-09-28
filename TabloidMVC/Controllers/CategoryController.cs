﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabloidMVC.Repositories;
using TabloidMVC.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace TabloidMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _catRepo;

        //dependency injection
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _catRepo = categoryRepository;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            List<Category> categories = _catRepo.GetAll();
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            List<Category> categories = _catRepo.GetAll();
            if (categories.Any(c => c.Name == category.Name))
            {
                ModelState.AddModelError("", "Category already exists.");
                return View(category);
            }
            else
            {
                try
                {
                    _catRepo.AddCategory(category);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(category);
                }
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = _catRepo.
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}