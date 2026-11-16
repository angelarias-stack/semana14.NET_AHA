using Microsoft.AspNetCore.Mvc;
using lab2tarea_Ariass.Models;
using lab2tarea_Ariass.DTOs;

namespace lab2tarea_Ariass.Controllers;



[ApiController]
[Route("api/[controller]")]
public class AutoController : ControllerBase
{
    // La lista interna sigue trabajando con el Modelo de la BD
    private static List<Auto> autos = new()
    {
        new Auto { Id = 1, Placa = "ABC-123", Marca = "Toyota", SedeTransito = "Lima" },
        new Auto { Id = 2, Placa = "XYZ-789", Marca = "Hyundai", SedeTransito = "Arequipa" }
    };

    // 1. GET ALL -> Retorna List<AutoResponseDto>
    [HttpGet]
    public IActionResult GetAll()
    {
        var response = autos.Select(a => new AutoResponseDto
        {
            Id = a.Id,
            Placa = a.Placa,
            Marca = a.Marca,
            SedeTransito = a.SedeTransito
        }).ToList();

        return Ok(response);
    }

    // 2. GET BY ID -> Retorna AutoResponseDto
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var auto = autos.FirstOrDefault(a => a.Id == id);
        if (auto == null) return NotFound(new { message = "Auto no encontrado" });

        var response = new AutoResponseDto
        {
            Id = auto.Id,
            Placa = auto.Placa,
            Marca = auto.Marca,
            SedeTransito = auto.SedeTransito
        };

        return Ok(response);
    }

    // 3. POST -> Recibe CreateAutoDto
    [HttpPost]
    public IActionResult Create([FromBody] CreateAutoDto dto)
    {
        int nuevoId = autos.Count > 0 ? autos.Max(a => a.Id) + 1 : 1;

        var nuevoAuto = new Auto
        {
            Id = nuevoId,
            Placa = dto.Placa,
            Marca = dto.Marca,
            SedeTransito = dto.SedeTransito
        };

        autos.Add(nuevoAuto);

        var response = new AutoResponseDto
        {
            Id = nuevoAuto.Id,
            Placa = nuevoAuto.Placa,
            Marca = nuevoAuto.Marca,
            SedeTransito = nuevoAuto.SedeTransito
        };

        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    // 4. PUT -> Recibe UpdateAutoDto
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateAutoDto dto)
    {
        var auto = autos.FirstOrDefault(a => a.Id == id);
        if (auto == null) return NotFound(new { message = "Auto no encontrado" });

        auto.Placa = dto.Placa;
        auto.Marca = dto.Marca;
        auto.SedeTransito = dto.SedeTransito;

        return Ok(new { message = "Auto actualizado correctamente con DTO" });
    }

    // 5. PATCH -> Recibe PatchSedeDto
    [HttpPatch("{id}/sede")]
    public IActionResult PatchSede(int id, [FromBody] PatchSedeDto dto)
    {
        var auto = autos.FirstOrDefault(a => a.Id == id);
        if (auto == null) return NotFound(new { message = "Auto no encontrado" });

        auto.SedeTransito = dto.SedeTransito;

        return Ok(new { message = "Sede actualizada mediante DTO" });
    }

    // 6. DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var auto = autos.FirstOrDefault(a => a.Id == id);
        if (auto == null) return NotFound(new { message = "Auto no encontrado" });

        autos.Remove(auto);
        return Ok(new { message = "Auto eliminado correctamente" });
    }
}