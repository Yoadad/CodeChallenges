
using AA_BB_AB;

void Main()
{
    var solution = new Solution();
    int AA = 0, AB = 0, BB = 0;
    Console.WriteLine(solution.solution(AA, AB, BB));
    AA = 5;
    AB = 0;
    BB = 2;
    Console.WriteLine(solution.solution(AA, AB, BB));
}

Main();