if (!long.TryParse(Console.ReadLine(), out long total) || total < 0)
{
    Console.WriteLine("Ошибка: введите целое неотрицательное число секунд.");
    return;
}

long hours = total / 3600;
long remainder = total % 3600;
long minutes = remainder / 60;
long seconds = remainder % 60;
Console.WriteLine($"{hours} ч {minutes} мин {seconds} с");