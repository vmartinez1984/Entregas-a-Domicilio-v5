namespace EntregaADomicilio.Core.Entidades
{
    public class Persona : EntidadBase
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public string Telefono { get; set; }        
        public List<Direccion> Direcciones { get; set; } = new List<Direccion>();
    }

    public class Direccion
    {
        public int Id { get; set; }

        public string EncodedKey { get; set; }

        public string CalleYNumero { get; set; }

        public string Referencia { get; set; }

        public string CoordenadasGps { get; set; }

        public string Colonia { get; set; }

        public string Alcaldia { get; set; }

        public string Estado { get; set; }

        public string CodigoPostal { get; set; }

        public bool EsLaPrincipal { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
    }
}
