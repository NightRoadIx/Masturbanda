// Iniciar un arrego a 5 espacios
double[] lecturas = new double[5];

// arreglo.Length devuelve el tamaño del arreglo
for (int i = 0; i < lecturas.Length; i++)
{
    Console.Write($"Lectura {i + 1}: ");
    while (!double.TryParse(Console.ReadLine(), out lecturas[i]))
        Console.WriteLine("Dato inválido, intente de nuevo.");
}

// Obtener el promedio y la máxima lectura
double suma = 0;
foreach (double l in lecturas)
    suma += l;
double promedio = suma / lecturas.Length;

double max = lecturas[0];
foreach (double l in lecturas)
    if (l > max) 
        max = l;

Console.WriteLine($"Promedio: {promedio:F2} °C");
Console.WriteLine($"Máxima:   {max:F2} °C");

// Una alerta si la máxima lectura es mayor a 90
if (max > 90)
    Console.WriteLine("ALERTA: sobrecalentamiento");