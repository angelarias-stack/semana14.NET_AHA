namespace lab2tarea_Ariass.Models;

    public class Persona
    {
        public int Id { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class Empresa
    {
        public int Id { get; set; }
        public string Ruc { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }

    public class Auto
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string SedeTransito { get; set; } = string.Empty;
    }
