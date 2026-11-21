# Programa de gestión financiera en C#

Aplicación de consola en C# (.NET 10) que, tras iniciar sesión, permite:

- **Calcular el IVA** de una cesta de productos.
- **Calcular la amortización de un préstamo** con el método francés y mostrar su tabla de amortización mes a mes.

Es mi primer programa en C#, realizado como tarea de programación para Ucademy.

## Requisitos

- [SDK de .NET 10](https://dotnet.microsoft.com/download) o superior.
- Opcional: Visual Studio 2022/2026, Visual Studio Code o Rider.

## Instalación y ejecución

```bash
git clone https://github.com/Javiier99/primer-programa-c-sharp.git
cd primer-programa-c-sharp
dotnet run
```

`dotnet run` restaura, compila y ejecuta el proyecto. Las carpetas `bin/` y `obj/` se generan automáticamente al compilar, por eso no están en el repositorio.

También puedes abrir `tarea-programacion-ucademy.slnx` con Visual Studio y pulsar **F5**.

## Uso

### 1. Inicio de sesión

Al arrancar, el programa pide usuario y contraseña. Las credenciales están definidas en el código (no hay base de datos):

| Usuario   | Contraseña |
|-----------|------------|
| `usuario` | `1234`     |

El usuario no distingue entre mayúsculas y minúsculas. Si los datos son incorrectos, se vuelven a pedir.

### 2. Menú principal

```
¿Que quieres hacer?
---
Pon '1' si quieres meter productos y calcular el IVA
Pon '2' si quieres calcular la amortización de un prestamo
Pon '3' si quieres cerrar el programa
```

### Opción 1: Cálculo del IVA

1. Introduce el nombre, el precio y la cantidad de cada producto.
2. Repite con tantos productos como quieras (responde `si` o `no`).
3. El programa muestra la cesta, el total sin impuestos y el total con un **IVA del 21 %**.

Validaciones:
- No se pueden añadir dos productos con el mismo nombre (sin distinguir mayúsculas).
- El precio y la cantidad deben ser mayores que 0.
- Se rechazan valores que no sean numéricos.

### Opción 2: Amortización de un préstamo (método francés)

1. Introduce el capital del préstamo.
2. Introduce el interés anual en porcentaje, sin el símbolo `%` (por ejemplo, `3.03` para un 3,03 %).
3. Introduce el plazo en meses.

El programa calcula la cuota mensual fija con la fórmula del método francés:

```
Cuota = C · [ i · (1 + i)^n ] / [ (1 + i)^n − 1 ]
```

donde `C` es el capital, `i` el interés mensual (interés anual / 100 / 12) y `n` el número de meses.

A continuación muestra la tabla de amortización con, para cada mes, la cuota, los intereses pagados y el capital pendiente.

Validaciones:
- El capital debe ser mayor que 0.
- El interés debe ser mayor que 0 y menor que 30 % (a partir de ahí se considera abusivo).
- El plazo debe estar entre 1 y 359 meses (menos de 30 años).

> Los números decimales se escriben con **punto** (`1500.50`), ya que el programa usa la cultura invariante.

## Estructura del proyecto

```
primer-programa-c-sharp/
├── Program.cs                        # Punto de entrada: login y menú principal
├── validar-usuario.cs                # Validación de usuario y contraseña
├── calcular-impuesto.cs              # Cesta de productos y cálculo del IVA
├── calculo-amortizacion.cs           # Préstamo con método francés y tabla de amortización
├── tarea-programacion-ucademy.csproj # Configuración del proyecto (.NET 10)
├── tarea-programacion-ucademy.slnx   # Solución de Visual Studio
└── .gitignore                        # Excluye bin/, obj/ y .vs/
```

## Conceptos de C# practicados

- Clases, métodos y `namespace`.
- Bucles `while`, `for` y `foreach`.
- `switch` para el menú.
- Manejo de excepciones con `try` / `catch` (`FormatException`).
- `Dictionary` con tuplas para guardar los productos.
- `Math.Pow` para potencias y formato numérico con `:F2`.
- `CultureInfo` para controlar el formato de los decimales.

## Posibles mejoras

- Guardar los usuarios en una base de datos o archivo, con contraseñas cifradas.
- Permitir elegir el tipo de IVA (21 %, 10 %, 4 %).
- Exportar la tabla de amortización a un archivo CSV.
- Añadir pruebas unitarias.

## Autor

**Javier** – [@Javiier99](https://github.com/Javiier99)
