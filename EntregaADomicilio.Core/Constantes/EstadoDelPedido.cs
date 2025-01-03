namespace EntregaADomicilio.Core.Constantes
{
    public class EstadoDelPedido
    {
        /// <summary>
        /// Estado inicial
        /// </summary>
        public static string Registrado = "Registrado";

        /// <summary>
        /// La cocina esta preprando el pedido
        /// </summary>
        public static string EnPreparacion = "En preparacion";

        /// <summary>
        /// Preparado listo para la entrega
        /// </summary>
        public static string Preparado = "Preparado";

        /// <summary>
        /// Recogido por el repartidor
        /// </summary>
        public static string Recogido = "Recogido";

        /// <summary>
        /// Recogido por el repartido y va en camino a ser entregado
        /// </summary>
        public static string EnCamino = "En camino";

        /// <summary>
        /// Entregado al cliente
        /// </summary>
        public static string Entregado = "Entregado";
    }
}
