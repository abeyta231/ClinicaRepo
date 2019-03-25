using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Clinica.Core.Models;

namespace Clinica.DataAccess.InMemory
{
    public class RepositorioPaciente
    {
        ObjectCache cache = MemoryCache.Default;
        List<Paciente> pacientes;

        public RepositorioPaciente()
        {
            pacientes = cache["pacientes"] as List<Paciente>;
            if (pacientes == null)
            {
                pacientes = new List<Paciente>();
            }
        }

        public void Guardar()
        {
            cache["pacientes"] = pacientes; 
        }

        public void AgregaPaciente(Paciente p)
        {
            pacientes.Add(p);
        }

        public void EditaPaciente (Paciente paciente)
        {
            Paciente PacienteAcualizar = pacientes.Find(p => p.Id == paciente.Id);
            if(PacienteAcualizar != null)
            {
                PacienteAcualizar = paciente;
            }
            else{
                throw new Exception("Paciente no encontrado");
            }
        }

        public Paciente Buscar(string Id)
        {
            Paciente paciente = pacientes.Find(p => p.Id == Id);
            if (paciente != null)
            {
                return paciente;
            }
            else
            {
                throw new Exception("Paciente no encontrado");
            }
        }

        public IQueryable<Paciente> Pacientes()
        {
            return pacientes.AsQueryable();
        }

        public void EliminaPaciente(string Id)
        {
            Paciente PacienteEliminar = pacientes.Find(p => p.Id == Id);
            if (PacienteEliminar != null)
            {
                pacientes.Remove(PacienteEliminar);
            }
            else
            {
                throw new Exception("Paciente Eliminado");
            }
        }
    }
}
 