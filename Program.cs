
using System;
using System.Collections.Generic;
using ValidadorUsuario;
using calculoImpuestos;
using calculo_amortizacion;
using System.Globalization;

// Aquí se encuentra el programa principal para toda la ejecución del proyecto.


class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Ponemos esto para indicar al programa que todo su funcionamiento sea neutro 
        Console.WriteLine("Bienvenido a tu programa de gestión financiera.");
        Console.WriteLine("Debes de iniciar sesión.");

        bool usuarioCorrecto = false;
        while(usuarioCorrecto == false) // Mientras que el usuario sea falso, seguirá el bucle y nunca saldrá
        {
            Console.WriteLine("Ingresa tu usuario");
            string nombreUsuario = Console.ReadLine().ToLower();
            Console.WriteLine("---");
            Console.WriteLine("Ingresa tu contraseña");
            string contraseñaUsuario = Console.ReadLine().ToLower();

            validar_usuario miValidadorUsuario = new validar_usuario(); // Instanciaremos una clase de validar usuario para poder extraer la función en este caso de validar
            usuarioCorrecto = miValidadorUsuario.validar(nombreUsuario, contraseñaUsuario);
            
        }

        if(usuarioCorrecto == true)
        {
            bool cerrarPrograma = false;
            while(cerrarPrograma == false) // Seguirá en bucle hasta que el usuario decida cerrar el programa
            {
                Console.WriteLine("¿Que quieres hacer?");
                Console.WriteLine("---");
                Console.WriteLine("Pon '1' si quieres meter productos y calcular el IVA");
                Console.WriteLine("Pon '2' si quieres calcular la amortización de un prestamo");
                Console.WriteLine("Pon '3' si quieres cerrar el programa");
                try
                {
                    var eleccionUsuario = int.Parse(Console.ReadLine());
                    
                    switch (eleccionUsuario)
                    {
                        case 1:
                            Calcular_impuesto miCalculadoraImpuesto = new Calcular_impuesto();
                            miCalculadoraImpuesto.calculoImpuestos();
                            Console.WriteLine("Programma de calculo de impuestos cerrado");
                            Console.WriteLine("---");
                            break;

                        case 2:
                            CalculoAmortizacion calculoAmortizacion = new CalculoAmortizacion();
                            calculoAmortizacion.calculoAmortizacionUsuario();
                            Console.WriteLine("Programa de calculo de amortización cerrado");
                            Console.WriteLine("---");
                            break;

                        case 3:
                            Console.WriteLine("Fin del programa, ¡Hasta pronto!");
                            cerrarPrograma = true;
                            break;


                    }

                }
                catch (Exception ex) // En caso de que haya cualquier error se ejecuta
                {
                    Console.WriteLine($"Ha ocurrido un error inesperado, vuelve a colocar un número del 1 al 3");
                } 
                


            }



        }




    }
}


