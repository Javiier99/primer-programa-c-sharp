using System;
using System.Collections.Generic;
using System.Text;

namespace calculo_amortizacion
{
    public class CalculoAmortizacion
    {
        public void calculoAmortizacionUsuario()
        {
            bool programaPrestamoActivado = true;
            while (programaPrestamoActivado == true)
            {
                Console.WriteLine("Bienvenido al programa de calculo de amortización de un prestamo del tipo francés");
                Console.WriteLine("---");
                // Se realizará el calculo de amortización de un prestamo, para ello usaremos el método francés
                // Necesitaría:
                // Capital inicial del prestamo, no puede ser negativo ni cero
                // Tipo de interés periodico (Será fijo), no puede ser negativo
                // Numero de periodos del cual el minimo de periodo es de 1 mes, porque 0 periodos, no da para pagar un prestamo


                // Escoger el capital
                double capitalCogido = 0.00;
                try
                {

                    bool capitalCogidoCorrectamente = false;


                    while (capitalCogidoCorrectamente == false)
                    {
                        Console.WriteLine("¿Cual es el capital que deseas pedir?");
                        capitalCogido = double.Parse(Console.ReadLine());

                        if (capitalCogido > 0)
                        {
                            capitalCogidoCorrectamente = true;
                        }
                        else
                        {
                            Console.WriteLine("---");
                            Console.WriteLine("El capital no puede ser menor o igual a 0");
                            Console.WriteLine("---");
                        }
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("---");
                    Console.WriteLine("Ha ocurrido un error, por favor vuelve a introducir la cantidad");
                    Console.WriteLine("---");
                }


                // Escoger el tipo de interés
                double interesCogido = 0.00;
                try
                {
                    bool interesCogidoCorrectamente = false;

                    while (interesCogidoCorrectamente == false)
                    {
                        Console.WriteLine("Introduce el interés anual (por ejemplo, escribe 3.03 para un 3.03% sin el %)");
                        interesCogido = double.Parse(Console.ReadLine());

                        if (interesCogido > 0 && interesCogido < 30) // Más de 30% en españa se considera abusivo
                        {
                            interesCogidoCorrectamente = true;
                        }
                        else if (interesCogido > 1)
                        {
                            Console.WriteLine("---");
                            Console.WriteLine("Por favor escoge el interés de la siguiente manera: escribe 3.03 para un 3.03%");
                            Console.WriteLine("---");
                        }
                        else if (interesCogido > 30)
                        {
                            Console.WriteLine("---");
                            Console.WriteLine("Ese interés se considera abusivo, escoge otro interés");
                            Console.WriteLine("---");
                        }
                        else
                        {
                            Console.WriteLine("---");
                            Console.WriteLine("El capital no puede ser menor o igual a 0");
                            Console.WriteLine("---");
                        }
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("---");
                    Console.WriteLine("Ha ocurrido un error, por favor vuelve a introducir la cantidad");
                    Console.WriteLine("---");
                }

                // Periodos del prestamo
                int periodosCogido = 0;
                try
                {

                    bool periodosCogidoCorrectamente = false;


                    while (periodosCogidoCorrectamente == false)
                    {
                        Console.WriteLine("Introduce el periodo en meses del prestamo");
                        periodosCogido = int.Parse(Console.ReadLine());

                        if (periodosCogido > 0 && periodosCogido < 360) // El prestamo no puede superar los 30 años o los 360 meses
                        {
                            periodosCogidoCorrectamente = true;
                        }
                        else if (periodosCogido == 0)
                        {
                            Console.WriteLine("---");
                            Console.WriteLine("El periodo no puede ser 0");
                            Console.WriteLine("---");
                        }
                        else if (periodosCogido >= 360)
                        {
                            Console.WriteLine("---");
                            Console.WriteLine("El periodo no puede ser superior a 30 años o a 360 meses");
                            Console.WriteLine("---");
                        }
                        else
                        {
                            Console.WriteLine("---");
                            Console.WriteLine("El periodo no puede ser negaivo");
                            Console.WriteLine("---");
                        }
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("---");
                    Console.WriteLine("Ha ocurrido un error, por favor vuelve a introducir la cantidad");
                    Console.WriteLine("---");
                }


                // Calculo de la amortización mediante el método francés
                Console.WriteLine("---");
                Console.WriteLine("Calcularemos la cuota a pagar mensualmente");
                Console.WriteLine("---");
                // Formula del método frances: Capital * ((interes*(1+interes)^numero periodo)/(((1+interes)^numero periodo) -1))


                double interesDecimalesAnual = (interesCogido / 100) / 12;

                // Tenemos que usar Math.Pow() para poder sacar la potencia
                double calculoNumeradorDenominador = 1 + interesDecimalesAnual;
                double potenciaNumeradorDenominador = Math.Pow(calculoNumeradorDenominador, periodosCogido);

                double cuotaPagarMensual = capitalCogido * ((interesDecimalesAnual * potenciaNumeradorDenominador) / (potenciaNumeradorDenominador - 1));


                // Toca hacer la tabla del prestamo

                Console.WriteLine("---");
                Console.WriteLine($"------ La cuota Mensual sale: {cuotaPagarMensual:F2} eur ------");
                Console.WriteLine("---");
                Console.WriteLine("---");
                Console.WriteLine("Tabla del prestamo:");
                Console.WriteLine("---");
                var capitalActual = capitalCogido;

                Console.WriteLine("| Mes | | Cuota | | Interés en eur | | Capital Pendiente |");
                for (var i = 0; i < periodosCogido; i++)
                {

                    double interesesMes = capitalActual * interesDecimalesAnual;
                    double amortizacionCapital = cuotaPagarMensual - interesesMes;

                    capitalActual = capitalActual - amortizacionCapital;

                    // Mostramos todos los resultados de la tabla, en caso de los numeros usaremos :F2 para mostrar solo 2 decimales
                    Console.WriteLine($"| {i + 1} | | {cuotaPagarMensual:F2} | | {interesesMes:F2} | | {capitalActual:F2} |");


                }

                Console.WriteLine("---");
                Console.WriteLine("---");

                bool contestadoBienOtroPrestamo = false;


                while (contestadoBienOtroPrestamo == false)
                {
                    Console.WriteLine("Quieres calcular otro prestamo? Contesta con Si o No");
                    string calcularOtroPrestamo = Console.ReadLine().ToLower();
                    if (calcularOtroPrestamo == "si")
                    {
                        contestadoBienOtroPrestamo = true;

                    }
                    else if (calcularOtroPrestamo == "no")
                    {
                        programaPrestamoActivado = false;
                        contestadoBienOtroPrestamo = true;
                    }
                    else
                    {
                        Console.WriteLine("---");
                        Console.WriteLine("Por favor escoge entre si o no");
                        Console.WriteLine("---");
                    }






                }
            }



        }
    }
}
