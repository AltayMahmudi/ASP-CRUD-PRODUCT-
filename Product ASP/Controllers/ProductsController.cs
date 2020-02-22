using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_ASP.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_ASP.Models;

namespace Product_ASP.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDBContext _context;
        public ProductsController(ProductDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Products = _context.Products.Include("Category").ToList();
            return View(Products);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text= c.Name,
                Value=c.Id.ToString()
            }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product) 
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            return View(product);
        }

        public IActionResult Delete(int productid)
        {
            var product = _context.Products.Find(productid);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
         
        }

        public IActionResult Edit(int productid)
        {
            var product = _context.Products.Include("Category").FirstOrDefault(p => p.Id == productid);

       
            if (product == null) return NotFound();

            ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            return View(product);
        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            return View(product);
        } 
    }
}