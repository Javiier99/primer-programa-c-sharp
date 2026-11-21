using System;
using System.Collections.Generic;
using System.Text;



// Dado que no tenemos conectado nada a la base de datos, se guardarán aquí los datos de inicio sesión



namespace ValidadorUsuario
{
    public class validar_usuario
    {
        // Lo guardamos como constantes ya que es algo que no se cambiará
        const string nombreUsuarioBD = "usuario"; 
        const string contraseñaUsuarioBD = "1234";
        public bool validar(string nombreUsuario, string contraseñaUsuario) // Creamos una función para validar si el usuario y contraseña colocado son correctos
        {
            bool usuarioValido = false;
            if (nombreUsuario == nombreUsuarioBD && contraseñaUsuario == contraseñaUsuarioBD) // En caso de ser correcto es valido en caso contrario no
            {
                Console.WriteLine("Datos correctos, puedes pasar");
                usuarioValido = true;
            }
            else
            {
                Console.WriteLine("Lo siento, usuario o contraseña incorrectos");
            }
            
            return usuarioValido; // Retornaremos la variable usuarioValido independientemente del resultado
             
        }
    }
}
