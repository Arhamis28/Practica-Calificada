using System;

class Program
{
    // Método principal
    public static void Main(string[] args)
    {
        string productoMasVendido = "", productoMasCaro = "";
        double total = 0;

        Console.WriteLine("=== REGISTRO DE COMPRAS DE PRODUCTOS ===");

        // Llamar al método que registra los productos
        RegistrarProductos(ref total, ref productoMasVendido, ref productoMasCaro);

        // Calcular descuento
        double descuento = CalcularDescuento(total);

        // Mostrar resultados finales
        MostrarResultados(total, descuento, productoMasVendido, productoMasCaro);
    }

    // Método para registrar los productos y calcular totales
    public static void RegistrarProductos(ref double total, ref string productoMasVendido, ref string productoMasCaro)
    {
        string nombreProducto;
        int cantidad, mayorCantidad = 0;
        double precioUnitario, precioMasCaro = 0;
        string continuar = "s";

        while (continuar == "s" || continuar == "S")
        {
            Console.Write("\nIngrese el nombre del producto: ");
            nombreProducto = Console.ReadLine();

            Console.Write("Ingrese la cantidad: ");
            cantidad = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el precio unitario (S/): ");
            precioUnitario = double.Parse(Console.ReadLine());

            double subtotal = cantidad * precioUnitario;
            total += subtotal;

            // Determinar producto más vendido
            if (cantidad > mayorCantidad)
            {
                mayorCantidad = cantidad;
                productoMasVendido = nombreProducto;
            }

            // Determinar producto más caro
            if (precioUnitario > precioMasCaro)
            {
                precioMasCaro = precioUnitario;
                productoMasCaro = nombreProducto;
            }

            Console.Write("\n¿Desea ingresar otro producto? (s/n): ");
            continuar = Console.ReadLine();
        }
    }

    // Método para calcular descuento
    public static double CalcularDescuento(double total)
    {
        double descuento = 0;

        if (total >= 500)
        {
            descuento = total * 0.10;
        }
        else if (total >= 200)
        {
            descuento = total * 0.05;
        }

        return descuento;
    }

    // Método para mostrar los resultados finales
    public static void MostrarResultados(double total, double descuento, string productoMasVendido, string productoMasCaro)
    {
        const double tipoCambio = 3.50;
        double totalConDescuento = total - descuento;
        double totalDolares = totalConDescuento / tipoCambio;

        Console.WriteLine("\n=== RESULTADOS DE LA COMPRA ===");
        Console.WriteLine("Total antes del descuento: S/ " + total.ToString("0.00"));
        Console.WriteLine("Descuento aplicado: S/ " + descuento.ToString("0.00"));
        Console.WriteLine("Total después del descuento: S/ " + totalConDescuento.ToString("0.00"));
        Console.WriteLine("Total en dólares: $ " + totalDolares.ToString("0.00"));
        Console.WriteLine("Producto más vendido: " + productoMasVendido);
        Console.WriteLine("Producto más caro: " + productoMasCaro);

        Console.WriteLine("\nGracias por usar el sistema :)");
    }
}
