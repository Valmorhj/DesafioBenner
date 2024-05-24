class Program
{
    static void  Main(string[] args)
    {
        try
        {
            Network network = new Network(5);

            network.connect(0, 1);

            network.connect(1, 2);

            network.connect(2, 3);

            Console.WriteLine(network.query(0, 3)); // Saída: true

            Console.WriteLine(network.query(3, 4)); // Saída: false
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}
