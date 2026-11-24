int count = 0;
int sum = 0;
int fives = 0;

while (true)
{
    int grade = Grades.Read();
    if (grade == Grades.Stop)
        break;

    if (!Grades.IsValid(grade))
        continue;

    count++;
    sum += grade;
    if (grade == Grades.Max)
        fives++;
}

Grades.PrintStats(count, sum, fives);

static class Grades
{
    public const int Min = 2;
    public const int Max = 5;
    public const int Stop = 0;

    public static int Read()
    {
        string? input = Console.ReadLine();
        if (input is null)
            return Stop;

        return int.TryParse(input, out int grade) ? grade : -1;
    }

    public static bool IsValid(int g)
    {
        return g >= Min && g <= Max;
    }

    public static void PrintStats(int count, int sum, int fives)
    {
        if (count == 0)
        {
            Console.WriteLine("Оценок нет");
            return;
        }

        Console.WriteLine($"Количество оценок: {count}");
        Console.WriteLine($"Средний балл: {(double)sum / count:F2}");
        Console.WriteLine($"Количество пятёрок: {fives}");
    }
}