using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class Turno
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }
    public TimeOnly Hora { get; set; }

    [ForeignKey(nameof(Doctor))]
    public int DoctorId { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Doctor Doctor { get; set; } = null!;

    [ForeignKey(nameof(Paciente))]
    public int PacienteId { get; set; }

    //evita que al borrar un doctor o un paciente la base de datos
    //elimine automáticamente sus turnos. Sin ese atributo, EF Core configura
    //las relaciones obligatorias con borrado en cascada por convención. SQL
    //Server no acepta las dos cascadas porque
    //Doctor y Paciente están en la tabla Usuario, y por eso falla la migración.
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Paciente Paciente { get; set; } = null!;

    [ForeignKey(nameof(Consultorio))]
    public int ConsultorioId { get; set; }

    public Consultorio Consultorio { get; set; } = null!;
}