using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootstrapMvcSample.Controllers;
using CrudGestionContenido.Domain;
using CrudGestionContenido.Domain.Services;
using CrudGestionContenido.Web.Models;
using AutoMapper;

namespace CrudGestionContenido.Web.Controllers
{
    public class DepartamentosController : BootstrapBaseController
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IWriteOnlyRepository _writeOnlyRepository;

        public DepartamentosController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
        }

        //
        // GET: /Empleados/
        public ActionResult Index()
        {
            var usersList = _readOnlyRepository.GetAll<Departamento>();

            var castedList = new List<DepartamentoModel>();

            foreach (var account in usersList)
            {
                castedList.Add(Mapper.Map<DepartamentoModel>(account));
            }

            return View(castedList);
        }

        [HttpPost]
        public ActionResult Create(DepartamentoModel model)
        {
            if (ModelState.IsValid)
            {
                _writeOnlyRepository.Create(Mapper.Map<Departamento>(model));
                Success("Depto agregado");
                return RedirectToAction("Index");
            }
            Error("there were some errors in your form.");
            return View(model);
        }

        public ActionResult Create()
        {

            var empModel = new DepartamentoModel();

            return View(empModel);
        }


        public ActionResult Delete(int Id)
        {
            var emp = _readOnlyRepository.First<Departamento>(x => x.Id == Id);
            _writeOnlyRepository.Archive(emp);
            Success("Eliminado correctamente");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var empModel = Mapper.Map<DepartamentoModel>(_readOnlyRepository.First<Departamento>(x => x.Id == Id));          
            return View(empModel);
        }

        [HttpPost]
        public ActionResult Edit(DepartamentoModel model)
        {
            if (ModelState.IsValid)
            {
                _writeOnlyRepository.Update(Mapper.Map<Departamento>(model));
                Success("Departamento actualizado");
                return RedirectToAction("Index");
            }
            Error("there were some errors in your form.");
            return View(model);
        }
    }
}
