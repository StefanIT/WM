using EfApplication.DTOs;
using EfApplication.DTOs.Create;
using EfApplication.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private EfGetProductsCommand _getProductsCommand;
		private EfGetCategoriesCommand _getCategories;
        private EfGetSuppliersCommand _getSuppliers;
        private EfGetManufacturersCommand _getManufacturers;
		private EfGetProductCommand _getProductCommand;
		private EfAddProductCommand _addProduct;
		private EfEditProductCommand _editProduct;
		public ProductController(EfGetProductsCommand getProductsCommand, EfAddProductCommand addProduct, EfGetCategoriesCommand getCategories, EfGetSuppliersCommand getSuppliers, EfGetManufacturersCommand getManufacturers, EfGetProductCommand getProductCommand, EfEditProductCommand editProduct)
        {
            _getProductsCommand = getProductsCommand;
            _addProduct = addProduct;
            _getCategories = getCategories;
            _getSuppliers = getSuppliers;
            _getManufacturers = getManufacturers;
			_getProductCommand = getProductCommand;
			_editProduct = editProduct;
        }
        // GET: Product
        public ActionResult Index()
        {
            var data = _getProductsCommand.Execute();
			//ViewBag.Products = _getProductsCommand.ReadFromJson();
            return View(data);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(_getCategories.Execute(), "CategoryId", "CategoryName");
            ViewBag.Suppliers = _getSuppliers.Execute();
            ViewBag.Manufacturers = _getManufacturers.Execute();
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(CreateProductDto productDto)
        {
            try
            {
				// TODO: Add insert logic here
				_addProduct.Execute(productDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
			var product = _getProductCommand.Execute(id);
			ViewBag.Categories = new SelectList(_getCategories.Execute(), "CategoryId", "CategoryName");
			ViewBag.Suppliers = _getSuppliers.Execute();
			ViewBag.Manufacturers = _getManufacturers.Execute();
			return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CreateProductDto dto)
        {
            try
            {
				// TODO: Add update logic here
				_editProduct.Execute(dto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
