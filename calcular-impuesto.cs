using System;
using System.Collections.Generic;
using System.Text;


// Tema impuestos, no dice absolutamente nada de que tipo de impuesto, solo menciona IVA, por lo tanto deduzco que la idea es meter una serie de productos y calcular el
// IVA, por lo que lo haré de esa manera



namespace calculoImpuestos
{
    public class calcular_impuesto
    {
        public void calculoImpuestos()
        {
            // Primero listas vacias, [nombre, precio, cantidad], se irán añadiendo productos a las listas y luego el calculo usaremos el for

            // Creamos un diccionario para almacenar los productos, sus precios y cantidades, no lo hacemos dentro del while porque si no los datos se pierden

            Dictionary<string, (float precio, int cantidad)> listaProductos = new Dictionary<string, (float precio, int cantidad)>(StringComparer.OrdinalIgnoreCase);

            // Debemos de asegurarnos de varias cosas:
            // 1: que el usuario pueda meter los productos y su precio que desea
            // 2: Que el usuario no pueda meter un precio negativo u otro caracter que no sea un número
            // 3: Que el usuario no pueda meter 2 productos iguales
            // 4: Que el usuario pueda meter una cantidad, dicha cantidad no puede ser 0, ni negativa.
    
            bool introducirProductos = true;
            int contadorProducto = 0;
            while(introducirProductos == true)
            {
                
                Console.WriteLine($"Introduce el nombre de un nuevo producto");
                string nombreProducto = Console.ReadLine();
                
                if(!listaProductos.TryGetValue(nombreProducto, out var datosExistentesProductos))
                {
                    contadorProducto++;
                    float precioProducto = 0.00f;
                    bool precioValido = false;
                    while (precioValido == false)
                    {
                        try
                        {
                            Console.WriteLine($"Introduce el precio del producto {contadorProducto}");
                            precioProducto = float.Parse(Console.ReadLine());
                            if (precioProducto < 0.00)
                            {
                                Console.WriteLine("El precio del producto no puede ser negaticvo.");
                            }
                            else if (precioProducto == 0.00)
                            {
                                Console.WriteLine("El precio del producto no puede ser exactamente 0");
                            }
                            else
                            {
                                precioValido = true;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Introduce un precio valido");
                        }
                       
                    }




                    int cantidadProducto = 0;
                    bool cantidadValido = false;
                    while (cantidadValido == false)
                    {
                        try
                        {
                            Console.WriteLine($"Introduce una cantidad a comprar del producto {nombreProducto}");
                            cantidadProducto = int.Parse(Console.ReadLine());
                            if (cantidadProducto < 0.00)
                            {
                                Console.WriteLine("La cantidad del producto no puede ser negativa.");
                            }
                            else if (cantidadProducto == 0.00)
                            {
                                Console.WriteLine("La cantidad del producto no puede ser exactamente 0");
                            }
                            else
                            {
                                cantidadValido = true;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Introduce una cantidad valida");
                        }

                    }


                    if(cantidadValido == true && precioValido == true)
                    {
                        listaProductos.Add(nombreProducto, (precioProducto, cantidadProducto));
                        Console.WriteLine($"El Producto {nombreProducto} añadido correctamente con precio {precioProducto} y cantidad {cantidadProducto}");
                    }


                    Console.WriteLine("¿Quieres agregar otro producto?");
                    bool haRespondidoCorrectamente = false;
                    while(haRespondidoCorrectamente == false)
                    {
                        Console.WriteLine("Pon Si o No");
                        string respuesteUsuario = Console.ReadLine().ToLower();
                        if (respuesteUsuario == "si")
                        {
                            haRespondidoCorrectamente = true;
                            
                        } 
                        else if(respuesteUsuario == "no")
                        {
                            haRespondidoCorrectamente = true;
                            introducirProductos = false;
                        }
                        else
                        {
                            Console.WriteLine("Respuesta incorrecta, por favor contecte con si o no");
                        }
                    
                    }
                }
                else
                {
                    Console.WriteLine("El producto ya existe, por favor ingrese un producto diferente");
                }

            }


            // Aquí ya empezamos a  colocar todos los productos y además calculamos el IVA, recorriendo el diccionario.



            Console.WriteLine(listaProductos["Ejemplo1"]);
            Console.WriteLine("Has seleccionado 1");
            Console.WriteLine("Calculo impuesto");
        }
    }
}
