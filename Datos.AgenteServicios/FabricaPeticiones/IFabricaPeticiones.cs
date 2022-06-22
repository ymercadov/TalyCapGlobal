namespace Datos.AgenteServicios
{
    public interface IFabricaPeticiones
    {
        /// <summary>
        /// Realiza peticiones sobre Api's externas
        /// </summary>
        /// <param name="url">Endpoint o Url donde se esncuntra el recurso</param>
        /// <param name="Metodo">Tipo de peticion a realizar
        /// GET 
        /// POST
        /// DELETE
        /// PUT
        /// </param>
        /// <returns>alguna cadena</returns>
        string RealizarPeticion(string url, string Metodo);
    }
}