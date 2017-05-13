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
    public class EmpleadosController : BootstrapBaseController
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IWriteOnlyRepository _writeOnlyRepository;

        public EmpleadosController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
        }

        //
        // GET: /Empleados/
        public ActionResult Index()
        {
            var usersList = _readOnlyRepository.GetAll<Empleado>();
            var deptos = _readOnlyRepository.GetAll<Departamento>();

            var castedList = new List<EmpleadoModel>();

            foreach (var account in usersList)
            {
                var emp = Mapper.Map<EmpleadoModel>(account);
                if (emp.Departamento_id != 0)
                    emp.Departamento_Name = deptos.FirstOrDefault(x => x.Id == emp.Departamento_id).Nombre;

                castedList.Add(emp);
            }

            return View(castedList);
        }

        [HttpPost]
        public ActionResult Create(EmpleadoModel model)
        {
            if (ModelState.IsValid)
            {
                _writeOnlyRepository.Create(Mapper.Map<Empleado>(model));
                Success("Empleado agregado");
                return RedirectToAction("Index");
            }
            Error("there were some errors in your form.");
            return View(model);
        }

        public ActionResult Create()
        {
            var deptos = _readOnlyRepository.GetAll<Departamento>();

            var empModel = new EmpleadoModel();
            List<SelectListItem> lst = new List<SelectListItem>();

            foreach (var depto in deptos)
            {
                lst.Add(new SelectListItem { Value = depto.Id.ToString(), Text = depto.Nombre });
            }

            empModel.Departamentos = new SelectList(lst, "Value", "Text");
            empModel.FechaNacimiento = DateTime.Today;

            return View(empModel);
        }


        public ActionResult Delete(int Id)
        {
            var emp = _readOnlyRepository.First<Empleado>(x => x.Id == Id);
            _writeOnlyRepository.Archive(emp);
            Success("Eliminado correctamente");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var empModel = Mapper.Map<EmpleadoModel>(_readOnlyRepository.First<Empleado>(x => x.Id == Id));
            var deptos = _readOnlyRepository.GetAll<Departamento>();
            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (var depto in deptos)
            {
                lst.Add(new SelectListItem { Value = depto.Id.ToString(), Text = depto.Nombre });
            }
            empModel.Departamentos = new SelectList(lst, "Value", "Text");
            empModel.FechaNacimiento = DateTime.Today;
            return View(empModel);
        }

        [HttpPost]
        public ActionResult Edit(EmpleadoModel model)
        {
            if (ModelState.IsValid)
            {
                _writeOnlyRepository.Update(Mapper.Map<Empleado>(model));
                Success("Empleado actualizado");
                return RedirectToAction("Index");
            }
            Error("there were some errors in your form.");
            return View(model);
        }
    }
}
