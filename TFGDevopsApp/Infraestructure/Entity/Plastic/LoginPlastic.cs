using System.IO;
using System.Reflection;

namespace TFGDevopsApp.Infraestructure.Entity.Plastic
{
    public class LoginPlastic
    {

        public static string login(string usuario, string pass)
        {
            //Boolean log = false;

            string filePath = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}login.txt";
            string content = "";
            try
            {
                // Lee todo el contenido del archivo
                string contenido = File.ReadAllText(filePath);

                content = contenido;
            }
            catch (IOException e)
            {
                // Manejar excepciones de IO, como cuando el archivo no existe
                Console.WriteLine($"Error al leer el archivo: {e.Message}");
            }
            return content;
        }
    }
}
