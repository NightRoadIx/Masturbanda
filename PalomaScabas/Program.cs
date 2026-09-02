/// <summary>
/// Programa que simula la lectura de temperaturas de tres componentes de un vehículo
/// (Motor, Transmisión y Frenos). Para cada componente se lee una cantidad fija de lecturas,
/// se calcula el promedio y el valor máximo y se compara este máximo con un umbral
/// predefinido para emitir una alerta si se supera.
/// </summary>
/// <remarks>
/// Este programa es un ejemplo didáctico de programación estructurada con métodos estáticos.
/// No utiliza clases ni objetos, pero puede servir como base para un diseño orientado a objetos.
/// </remarks>

// ==================== PROCESO PRINCIPAL ====================

// Lectura de datos del Motor (5 lecturas, umbral 90 °C)
double[] motor = LeerLecturas(5, "Motor");
MostrarReporte("Motor", motor, 90);

// Lectura de datos de la Transmisión (3 lecturas, umbral 110 °C)
double[] transmision = LeerLecturas(3, "Transmisión");
MostrarReporte("Transmisión", transmision, 110);

// Lectura de datos de los Frenos (4 lecturas, umbral 250 °C)
double[] frenos = LeerLecturas(4, "Frenos");
MostrarReporte("Frenos", frenos, 250);

// ==================== MÉTODOS AUXILIARES ====================

/// <summary>
/// Solicita al usuario una cantidad específica de lecturas (valores numéricos) para un componente dado.
/// </summary>
/// <param name="cantidad">Número de lecturas que se desean ingresar.</param>
/// <param name="nombre">Nombre del componente (se usa para mostrar en pantalla).</param>
/// <returns>Un arreglo de tipo <c>double</c> con las lecturas ingresadas.</returns>
/// <remarks>
/// Valida que cada entrada sea un número válido (double); en caso contrario,
/// vuelve a pedir el dato hasta que sea correcto.
/// </remarks>
static double[] LeerLecturas(int cantidad, string nombre)
{
    double[] valores = new double[cantidad];
    Console.WriteLine($"--- {nombre} ---");

    for (int i = 0; i < cantidad; i++)
    {
        Console.Write($"Lectura {i + 1}: ");
        // TryParse devuelve false si la conversión falla, lo que permite repetir la solicitud
        while (!double.TryParse(Console.ReadLine(), out valores[i]))
            Console.WriteLine("Dato inválido, intente de nuevo.");
    }
    return valores;
}

/// <summary>
/// Calcula el promedio aritmético de un arreglo de números.
/// </summary>
/// <param name="lecturas">Arreglo de valores <c>double</c>.</param>
/// <returns>El promedio como <c>double</c>.</returns>
static double Promedio(double[] lecturas)
{
    double suma = 0;
    foreach (double l in lecturas)
        suma += l;
    return suma / lecturas.Length;
}

/// <summary>
/// Encuentra el valor máximo dentro de un arreglo de números.
/// </summary>
/// <param name="valores">Arreglo de valores <c>double</c>.</param>
/// <returns>El valor máximo como <c>double</c>.</returns>
/// Se lanza si el arreglo está vacío (no se controla explícitamente).
/// </exception>
static double Maxima(double[] valores)
{
    double max = valores[0];
    foreach (double v in valores)
        if (v > max) max = v;
    return max;
}

/// <summary>
/// Muestra un reporte en consola para un componente: su promedio y su temperatura máxima,
/// y si esta última supera el umbral especificado, muestra una alerta.
/// </summary>
/// <param name="nombre">Nombre del componente.</param>
/// <param name="valores">Arreglo con las lecturas del componente.</param>
/// <param name="umbral">Valor límite (en °C) a partir del cual se dispara la alerta.</param>
static void MostrarReporte(string nombre, double[] valores, double umbral)
{
    Console.WriteLine($"{nombre}: promedio {Promedio(valores):F2} °C, " +
                      $"máxima {Maxima(valores):F2} °C");

    if (Maxima(valores) > umbral)
        Console.WriteLine($"ALERTA en {nombre}: umbral de {umbral} °C excedido");
}