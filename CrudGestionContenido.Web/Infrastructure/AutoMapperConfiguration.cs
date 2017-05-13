using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CrudGestionContenido.Domain;
using CrudGestionContenido.Web.Controllers;
using CrudGestionContenido.Web.Models;
using Ninject.Modules;

namespace CrudGestionContenido.Web.Infrastructure
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<EmpleadoModel, Empleado>();
            Mapper.CreateMap<Empleado, EmpleadoModel>();
            Mapper.CreateMap<DepartamentoModel, Departamento>();
            Mapper.CreateMap<Departamento, DepartamentoModel>();
        }
    }
}