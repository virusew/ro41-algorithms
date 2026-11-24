bool validA = long.TryParse(Console.ReadLine(), out long a);
bool validB = long.TryParse(Console.ReadLine(), out long b);

if (!validA || !validB || a < 0 || b < 0 || (a == 0 && b == 0))
{
    Console.WriteLine("Ошибка: введите два целых неотрицательных числа, хотя бы одно больше нуля.");
    return;
}

while (b != 0)
{
    long r = a % b;
    a = b;
    b = r;
}

Console.WriteLine($"НОД: {a}");