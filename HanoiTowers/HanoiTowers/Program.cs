
        int numberOfDiscs;

        Console.Write("Enter the number of discs: ");
        while (!int.TryParse(Console.ReadLine(), out numberOfDiscs) || numberOfDiscs <= 0)
        {
            Console.WriteLine("Please enter a positive integer.");
            Console.Write("Enter the number of discs: ");
        }

        Console.WriteLine($"Steps to solve Tower of Hanoi with {numberOfDiscs} discs:");
        SolveHanoi(numberOfDiscs, 'A', 'C', 'B');

        Console.ReadLine(); // Keep the console window open


    static void SolveHanoi(int n, char source, char destination, char auxiliary)
    {
        if (n == 1)
        {
            Console.WriteLine($"Move disc 1 from {source} to {destination}");
        }
        else
        {
            SolveHanoi(n - 1, source, auxiliary, destination);
            Console.WriteLine($"Move disc {n} from {source} to {destination}");
            SolveHanoi(n - 1, auxiliary, destination, source);
        }
    }
