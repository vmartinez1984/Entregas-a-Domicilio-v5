namespace EntregaADomicilio.Core.Dtos.Administracion
{
    public class InicioDeSesionDtoIn
    {
        public string Correo { get; set; }

        public string Contrasenia { get; set; }
    }

    public class TokenDto
    {
        public string Token { get; set; }

        public string FechaDeVencimiento { get; set; }
    }
}
