namespace MiluTienda.Utilities
{
    public class EstadoDir
    {
        // Diccionario para almacenar los estados con su Id y Descripción
        public static readonly Dictionary<int, string> EstadoPedido = new Dictionary<int, string>
        {
            { 1, "Pendiente" },       
            { 2, "Confirmado" },      
            { 3, "Cobrado" },         
            { 4, "Enviado" },         
            { 5, "Devuelto" },        
            { 6, "Anulado" }          
        };

        // Función para obtener la descripción del estado a partir del id
        public static string GetEstadoDescripcion(int estadoId)
        {
            // Verificar si el id de estado existe en el diccionario
            if (EstadoPedido.TryGetValue(estadoId, out var descripcion))
            {
                return descripcion;  // Devuelve la descripción si el id es válido
            }
            return null; 
        }
    }
}
