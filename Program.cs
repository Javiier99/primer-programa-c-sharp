
using System;
using System.Collections.Generic;
using ValidadorUsuario;
using calculoImpuestos;
// Enlace para el archivo donde se encuentra la tarea: https://drive.google.com/drive/folders/1P1jG2SzkiCPs1aCVluQhC3Ql6_NEIZcl


// Aquí se encuentra el programa principal para toda la ejecución del proyecto.







class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a tu programa de gestión financiera.");
        Console.WriteLine("Debes de iniciar sesión.");

        bool usuarioCorrecto = false;
        while(usuarioCorrecto == false)
        {
            Console.WriteLine("Ingresa tu usuario");
            string nombreUsuario = Console.ReadLine().ToLower();

            Console.WriteLine("Ingresa tu contraseña");
            string contraseñaUsuario = Console.ReadLine().ToLower();

            validar_usuario miValidadorUsuario = new validar_usuario();
            usuarioCorrecto = miValidadorUsuario.validar(nombreUsuario, contraseñaUsuario);
            
        }

        if(usuarioCorrecto == true)
        {
            bool cerrarPrograma = false;
            while(cerrarPrograma == false)
            {
                Console.WriteLine("¿Que quieres hacer?");
                Console.WriteLine("Pon '1' si quieres meter productos y calcular el IVA");
                Console.WriteLine("Pon '2' si quieres calcular la amortización de un prestamo");
                Console.WriteLine("Pon '3' si quieres cerrar el programa");
                try
                {
                    var eleccionUsuario = int.Parse(Console.ReadLine());
                    
                    switch (eleccionUsuario)
                    {
                        case 1:
                            calcular_impuesto miCalculadoraImpuesto = new calcular_impuesto();
                            miCalculadoraImpuesto.calculoImpuestos();
                            
                            break;

                        case 2:
                            Console.WriteLine("Has seleccionado 2");
                            break;

                        case 3:
                            Console.WriteLine("Fin del programa, ¡Hasta pronto!");
                            cerrarPrograma = true;
                            break;


                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Los valores deben de ser 1, 2 o 3");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ha ocurrido un error inesperado {ex.Message}");
                } 
                


            }



        }


        Console.ReadLine();

    }
}


