internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("--- Escribe un número: ---"); // Escribe esto en la consola

        bool continueProgram = true;

        do
        {
            string input = Console.ReadLine() ?? "a"; // Lee la entrada de la consola

            if (!double.TryParse(input, out _)) // Si la entrada no es un número, o si contiene un punto, entonces te pide intentarlo de nuevo
            {
                Console.WriteLine("--- No haz escrito un número. Inténtalo de nuevo ---");
                continue;
            }

            if (input.Contains('.'))
            {
                Console.WriteLine("--- Si quieres colocar un valor decimal, utiliza coma en lugar de punto. Inténtalo de nuevo ---");
                continue;
            }

            continueProgram = false;

            double number = double.Parse(input); // Convierte el valor de la entrada a un número

            Console.WriteLine($"El valor de la entrada es {number}"); // Cadenas literales verbatim
        } while (continueProgram);

        Console.WriteLine("--- Programa terminado ---");

        Console.WriteLine("\n-----------------------\n");

        static void Saludar() // Función
        {
            Console.WriteLine("Hola");
        }

        Saludar();

        Console.WriteLine("\n-----------------------\n");

        string[] arrayNombres = ["Juan", "Pedro", "Maria"]; // var arrayNombres = new[] { "Juan", "Pedro", "Maria" };
        Console.WriteLine($"Console.WriteLine del array: {arrayNombres}");

        for (int i = 0; i < arrayNombres.Length; i++)
        {
            Console.WriteLine($"Elemento {i} del array: {arrayNombres[i]}");
        }

        foreach (string nombre in arrayNombres)
        {
            Console.WriteLine($"Elemento i-ésimo con forEach: {nombre}");
        }

        Console.WriteLine("\n-----------------------\n");

        var ciudadesXPaises = new Dictionary<string, string>
        {
            ["Madrid"] = "España",
            ["Lima"] = "Perú",
            ["Nueva York"] = "Estados Unidos"
        };

        Console.WriteLine($"Console.WriteLine de un diccionario: {ciudadesXPaises}");

        foreach (KeyValuePair<string, string> item in ciudadesXPaises)
        {
            Console.WriteLine($"Ciudad: {item.Key} - País: {item.Value}");
        }

        Console.WriteLine("\n-----------------------\n");

        try
        {
            Console.WriteLine("--- Escribe un número: ---");
            string num = Console.ReadLine() ?? "0";
            decimal div = 10 / Convert.ToInt32(num);
            Console.WriteLine($"División: {div}");

        } catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\n-----------------------\n");

        List<string> listaNombres = ["Juan", "Pedro", "Maria"]; // var listaNombres = new List<string> { "Juan", "Pedro", "Maria" };


        Console.WriteLine($"Console.WriteLine de la lista: {listaNombres}");

        for (int i = 0; i < listaNombres.Count; i++)
        {
            Console.WriteLine($"Elemento {i} de la lista: {listaNombres[i]}");
        }

        foreach (string nombre in listaNombres)
        {
            Console.WriteLine($"Elemento i-ésimo con forEach: {nombre}");
        }
    }
}