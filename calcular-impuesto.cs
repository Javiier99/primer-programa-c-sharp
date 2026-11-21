using System;
using System.Collections.Generic;
using System.Text;



// Tema impuestos, no dice absolutamente nada de que tipo de impuesto, solo menciona IVA, por lo tanto deduzco que la idea es meter una serie de productos y calcular el
// IVA, por lo que lo haré de esa manera



namespace calculoImpuestos
{
    public class Calcular_impuesto
    {
        public void calculoImpuestos()
        {
            // Primero listas vacias, [nombre, precio, cantidad], se irán añadiendo productos a las listas y luego el calculo usaremos el for

            // Creamos un diccionario para almacenar los productos, sus precios y cantidades, no lo hacemos dentro del while porque si no los datos se pierden

            Dictionary<string, (double precio, int cantidad)> listaProductos = new Dictionary<string, (double precio, int cantidad)>(StringComparer.OrdinalIgnoreCase);

            // Debemos de asegurarnos de varias cosas:
            // 1: que el usuario pueda meter los productos y su precio que desea
            // 2: Que el usuario no pueda meter un precio negativo u otro caracter que no sea un número
            // 3: Que el usuario no pueda meter 2 productos iguales
            // 4: Que el usuario pueda meter una cantidad, dicha cantidad no puede ser 0, ni negativa.
    
            bool introducirProductos = true;
            int contadorProducto = 0;
            // Mientras el usuario quiera meter productos, el programa seguirá activo
            while (introducirProductos == true)
            {
                
                Console.WriteLine($"Introduce el nombre de un nuevo producto");
                string nombreProducto = Console.ReadLine();
             

                if (!listaProductos.TryGetValue(nombreProducto, out var datosExistentesProductos)) // Si el producto no existe, lo añadimos al diccionario
                {
                    contadorProducto++; // Necesitamos un contador para que el usuario sepa cuantos productos ha añadido, y así poder ponerlo en el mensaje de introducción del producto
                    double precioProducto = 0.00;
                    bool precioValido = false;
                    while (precioValido == false)
                    {
                        try
                        {
                            
                            Console.WriteLine($"Introduce el precio del producto {contadorProducto}");
                            precioProducto = double.Parse(Console.ReadLine());
                            Console.WriteLine("---");
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


                    int cantidadProducto = 0; // Necesitamos la variable para poder calcular la cantidad de producto que el usuario quiera añadir
                    bool cantidadValido = false;
                    while (cantidadValido == false)
                    {
                        try
                        {
                            
                            Console.WriteLine($"Introduce una cantidad a comprar del producto {nombreProducto}");
                            cantidadProducto = int.Parse(Console.ReadLine());
                            Console.WriteLine("---");
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


                    if(cantidadValido == true && precioValido == true) // Verificamos si el precio y la cantidad son validos, si lo son añadimos el producto al diccionario y mostramos el mensaje de confirmación
                    {
                        listaProductos.Add(nombreProducto, (precioProducto, cantidadProducto));
                        Console.WriteLine("---");
                        Console.WriteLine($"El Producto {nombreProducto} añadido correctamente con precio {precioProducto}€ y cantidad {cantidadProducto} und");
                        
                    }
                    // Comprobamos si el usuario desea añadir otro producto
                    Console.WriteLine("---");
                    Console.WriteLine("¿Quieres agregar otro producto?"); 
                    Console.WriteLine("---");
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
                            introducirProductos = false; // Salimos del bucle y cerramos el programa
                        }
                        else
                        {
                            Console.WriteLine("Respuesta incorrecta, por favor contecte con si o no");
                        }
                    
                    }
                }
                else
                {
                    Console.WriteLine("---");
                    Console.WriteLine("El producto ya existe, por favor ingrese un producto diferente");
                    Console.WriteLine("---");
                }

            }


            // Aquí ya empezamos a  colocar todos los productos y además calculamos el IVA, recorriendo el diccionario.

            Console.WriteLine("Empezamos a calcular el total y los impuestos");
            Console.WriteLine("---");
            // Lo haremos mendiante un bucle for, sumaremos el total para posteriormente aplicar el IVA después

            const double IVA = 0.21; // Guardamos el IVA en una variable constante ya que no se va a modificar

            double costoTotalCesta = 0.00;
            double costoTotalCestaIVA = 0.00;

            Console.WriteLine("La cesta ha sido:");
            Console.WriteLine("---");

            foreach (var producto in listaProductos) // Usamos foreach para recorrer todo el diccionario de productos e ir mostrando el nomre, precio y la cantidad
            {
                string nombreProducto = producto.Key;
                double precioProducto = producto.Value.precio;
                int cantidadProducto = producto.Value.cantidad;
                Console.WriteLine("---");
                Console.WriteLine($"Nombre producto: {nombreProducto}, su precio {precioProducto}, la cantidad a comprar: {cantidadProducto}");

                costoTotalCesta = (precioProducto * cantidadProducto) + costoTotalCesta; // Calculamos el costo total de la cista de la compra

            }
            Console.WriteLine("---");
            Console.WriteLine($"El total ha sido de: {costoTotalCesta} eur");
            costoTotalCestaIVA = (costoTotalCesta * IVA) + costoTotalCesta;  // Calculamos el total aplicado el IVA y sumado al total para tener el total a pagar con IVA incluido
            Console.WriteLine("---");
            Console.WriteLine($"Aplicandose un impuesto de {IVA * 100}% nos queda un total a pagar de: {costoTotalCestaIVA} eur");
            Console.WriteLine("---");

        }
    }
}
