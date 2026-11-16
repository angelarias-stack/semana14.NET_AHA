namespace lab2tarea_Ariass.DTOs;

public class AutoResponseDto
{
    public int Id { get; set; }
    public string Placa { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string SedeTransito { get; set; } = string.Empty;
}

// DTO para recibir datos al CREAR (no pedimos Id)
public class CreateAutoDto
{
    public string Placa { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string SedeTransito { get; set; } = string.Empty;
}

// DTO para recibir datos al ACTUALIZAR (PUT)
public class UpdateAutoDto
{
    public string Placa { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string SedeTransito { get; set; } = string.Empty;
}

// DTO para actualización PARCIAL (PATCH)
public class PatchSedeDto
{
    public string SedeTransito { get; set; } = string.Empty;
}