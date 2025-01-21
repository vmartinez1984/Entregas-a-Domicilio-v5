namespace EntregaADomicilio.Core.Repartidores.Dtos
{
    public class ClienteDto
    {
        public string NombreCompleto { get; set; }        
        public string Telefono { get; set; }
        public DireccionDto Direccion { get; set; }
    }

    public class DireccionDto
    {
        public string CalleYNumero { get; set; }

        public string Referencia { get; set; }

        public string CoordenadasGps { get; set; }

        public string Colonia { get; set; }

        public string Alcaldia { get; set; }

        public string Estado { get; set; }

        public string CodigoPostal { get; set; }
        
        public string Direccion { get {  return $"{CalleYNumero}, {Colonia}"; } }
    }
}
