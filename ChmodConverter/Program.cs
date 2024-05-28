namespace ChmodConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Need one and only arg");
            }

            string input = args[0];
            try
            {
                if (int.TryParse(input, out int numericMode))
                {
                    string symbolValue = ChmodConverter.NumericToSymbolic(numericMode);
                    Console.WriteLine(symbolValue);
                }
                else
                {
                    int numericValue = ChmodConverter.SymbolicToNumeric(input);
                    Console.WriteLine(numericValue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
