﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinica.Core.Models;
using Clinica.DataAccess.InMemory;
using Rotativa;

namespace Clinica.WebUI.Controllers
{
    public class PacienteAdministradorController : Controller
    {
        RepositorioPaciente context;

        public PacienteAdministradorController()
        {
            context = new RepositorioPaciente();
        }
        // GET: PacienteAdministrador
        public ActionResult Index()
        {
            List<Paciente> pacientes = context.Pacientes().ToList();
            return View(pacientes);
        }

        public ActionResult Agrega()
        {
            Paciente paciente = new Paciente();
            return View(paciente);
        }
        
        [HttpPost]
        public ActionResult Agrega(Paciente paciente )
        {
            if (!ModelState.IsValid)
            {
                return View(paciente);
            }
            else
            {
                context.AgregaPaciente(paciente);
                context.Guardar();
              
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edita(string Id)
        {
            Paciente paciente = context.Buscar(Id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(paciente);
            }
        }
        [HttpPost]
        public ActionResult Edita(Paciente paciente, string id)
            {
            Paciente pacienteEditar = context.Buscar(id);
            if (pacienteEditar== null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(paciente);
                }

                pacienteEditar.Nombre = paciente.Nombre;
                pacienteEditar.FechaDeNacimiento = paciente.FechaDeNacimiento;
                pacienteEditar.Peso = paciente.Peso;
                pacienteEditar.Sexo = paciente.Sexo;
                pacienteEditar.CorreoElectronico = paciente.CorreoElectronico;
                pacienteEditar.EstudioSolicitado = paciente.EstudioSolicitado;

                context.Guardar();
                return RedirectToAction("Index");
            }

            }

        public ActionResult Elimina(string Id)
        {
            Paciente paciente = context.Buscar(Id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(paciente);
            }
        }

      

        public ActionResult GeneratePDF(string Id)
        {
            Paciente paciente = context.Buscar(Id);
            return new ViewAsPdf("GeneratePDF", paciente);
        }




        [HttpPost]
        [ActionName("Elimina")]
        public ActionResult ConfirmaElimina(string Id)
        {
            Paciente pacienteEliminar = context.Buscar(Id);
            if (pacienteEliminar == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.EliminaPaciente(Id);
                context.Guardar();
                return RedirectToAction("Index");

            }

        }
       
         

        
    }
}