if (!long.TryParse(Console.ReadLine(), out long n) || n < 0)
{
    Console.WriteLine("Ошибка: введите целое неотрицательное число.");
    return;
}

int sum = 0;
int count = 0;

do
{
    sum += (int)(n % 10);
    count++;
    n /= 10;
}
while (n > 0);

Console.WriteLine($"Количество: {count}");
Console.WriteLine($"Сумма: {sum}");