using System.Net;

namespace api.Utils.Respuestas;

public class RespuestaExito
{
    public HttpStatusCode CodigoEstado { get; }
    public Respuesta Res { get; set; }

    public RespuestaExito(string mensaje, HttpStatusCode codigo)
    {
        Res = new Respuesta(mensaje);
        CodigoEstado = codigo;
    }

    public RespuestaExito(string mensaje, HttpStatusCode codigo, object datos)
    {
        Res = new Respuesta(mensaje, datos);
        CodigoEstado = codigo;
    }
}