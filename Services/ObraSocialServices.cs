using api.Config;
using api.Dtos.ObraSocial;
using api.Models;
using api.Utils.Respuestas;
using System.Net;

namespace api.Services
{
    public class ObraSocialServices
    {
        private readonly AppDbContext _db;

        public ObraSocialServices(AppDbContext db) 
        {
            _db = db;
        
        }

        public List<ObraSocial> ObtenerTodasLasObrasSociales()
        {
            var lista = _db.ObrasSociales.Select((p) => new ObraSocial()
            {
                Id = p.Id,
                Nombre = p.Nombre,
            }).ToList();
            return lista;
        }

        public ObraSocial ObtenerUnoPorId(int id)
        {
            var obraSocial = _db.ObrasSociales.FirstOrDefault((p) => p.Id == id);
            if (obraSocial == null)
            {
                throw new RespuestaError(
                    $"La obra social con id = {id} no se encontro",
                    HttpStatusCode.NotFound
                );
            }
            return obraSocial;
        }

        public ObraSocial CrearObraSocial(CrearObraSocialDTO dto)
        {
            var obraSocial = new ObraSocial()
            {
                Nombre = dto.Nombre
            };
            _db.ObrasSociales.Add(obraSocial);
            _db.SaveChanges();
            return obraSocial;

        }

        public ObraSocial ActualizarUnoPorId(int id, ActualizarObraSocialDTO dto)
        {
            ObraSocial obraSocial = ObtenerUnoPorId(id);

            if (dto.Nombre != null)
            {
                obraSocial.Nombre = dto.Nombre;
            }
           if (dto.IsActive != null)
            {
                obraSocial.IsActive = (bool)dto.IsActive;
            }

            _db.ObrasSociales.Update(obraSocial);
            _db.SaveChanges();

            return obraSocial;
        }

        public void EliminarObraSocial(int id)
        {
            ObraSocial obraSocial = ObtenerUnoPorId(id);
            _db.ObrasSociales.Remove(obraSocial);
            _db.SaveChanges();
        }


    }
}
