using lab2tarea_Ariass.Data;
using Microsoft.AspNetCore.Mvc;
using lab2tarea_Ariass.Models;
using lab2tarea_Ariass.DTOs;
using Microsoft.EntityFrameworkCore;

namespace lab2tarea_Ariass.Controllers;



[ApiController]
[Route("api/[controller]")]
public class AutoController : ControllerBase
{
    private readonly AppDbContext _context;

    public AutoController(AppDbContext context)
    {
        _context = context;
    }

    // 1. GET ALL -> Retorna List<AutoResponseDto>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _context.Autos
            .Select(a => new AutoResponseDto
            {
                Id = a.Id,
                Placa = a.Placa,
                Marca = a.Marca,
                SedeTransito = a.SedeTransito
            }).ToListAsync();

        return Ok(response);
    }

    // 2. GET BY ID -> Retorna AutoResponseDto
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var auto = await _context.Autos.FindAsync(id);
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
    public async Task<IActionResult> Create([FromBody] CreateAutoDto dto)
    {
        var nuevoAuto = new Auto
        {
            Placa = dto.Placa,
            Marca = dto.Marca,
            SedeTransito = dto.SedeTransito
        };

        _context.Autos.Add(nuevoAuto);
        await _context.SaveChangesAsync();

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
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAutoDto dto)
    {
        var auto = await _context.Autos.FindAsync(id);
        if (auto == null) return NotFound(new { message = "Auto no encontrado" });

        auto.Placa = dto.Placa;
        auto.Marca = dto.Marca;
        auto.SedeTransito = dto.SedeTransito;

        await _context.SaveChangesAsync();
        return Ok(new { message = "Auto actualizado correctamente con DTO" });
    }

    // 5. PATCH -> Recibe PatchSedeDto
    [HttpPatch("{id}/sede")]
    public async Task<IActionResult> PatchSede(int id, [FromBody] PatchSedeDto dto)
    {
        var auto = await _context.Autos.FindAsync(id);
        if (auto == null) return NotFound(new { message = "Auto no encontrado" });

        auto.SedeTransito = dto.SedeTransito;

        await _context.SaveChangesAsync();
        return Ok(new { message = "Sede actualizada mediante DTO" });
    }

    // 6. DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var auto = await _context.Autos.FindAsync(id);
        if (auto == null) return NotFound(new { message = "Auto no encontrado" });

        _context.Autos.Remove(auto);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Auto eliminado correctamente" });
    }
}