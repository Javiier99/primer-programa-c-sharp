using System;
using System.Collections.Generic;
using System.Text;



// Dado que no tenemos conectado nada a la base de datos, se guardarán aquí los datos de inicio sesión



namespace ValidadorUsuario
{
    public class validar_usuario
    {
        const string nombreUsuarioBD = "usuario";
        const string contraseñaUsuarioBD = "1234";
        public bool validar(string nombreUsuario, string contraseñaUsuario)
        {
            bool usuarioValido = false;
            if (nombreUsuario == nombreUsuarioBD && contraseñaUsuario == contraseñaUsuarioBD)
            {
                Console.WriteLine("Datos correctos, puedes pasar");
                usuarioValido = true;
            }
            else
            {
                Console.WriteLine("Lo siento, usuario o contraseña incorrectos");
            }
            
            return usuarioValido;
             
        }
    }
}
