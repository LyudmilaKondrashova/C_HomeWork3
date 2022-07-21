// Задача 19. Напишите программу, которая принимает на вход
// пятизначное число и проверяет, является ли оно палиндромом
void Zadacha19()
{
    Console.WriteLine("Введите пятизначное число");
    int number = Convert.ToInt32(Console.ReadLine());
    number = Math.Abs(number);

    if (number >=10000 && number <=99999)
    {
        int ones = number % 10;
        int tens = number % 100 / 10;
        int thous = number / 1000 % 10;
        int tenthous = number / 10000;

        if (ones == tenthous && tens == thous)
            Console.WriteLine("Число является палиндромом");
        else
            Console.WriteLine("Число не является палиндромом");
    }
    else
        Console.WriteLine("Введено не пятизначное число");
}

// Задача 21. Напишите программу, которая принимает на вход
// координаты двух точек и находит расстояние между ними в 3D пространстве.
void Zadacha21()
{
    Console.WriteLine("Введите координату Х точки 1");
    int x1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите координату У точки 1");
    int y1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите координату Z точки 1");
    int z1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите координату Х точки 2");
    int x2 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите координату У точки 2");
    int y2 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите координату Z точки 2");
    int z2 = Convert.ToInt32(Console.ReadLine());

    double dist = Math.Round(Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) + Math.Pow(z1 - z2, 2)), 2);
    Console.WriteLine("Расстояние между точками равно " + dist);
}

// Задача 23. Напишите программу, которая принимает на вход число (N)
// и выдаёт таблицу кубов чисел от 1 до N
void Zadacha23()
{
    Console.WriteLine("Введите число N");
    int N = Convert.ToInt32(Console.ReadLine());

    if (N >= 1)
    {
        Console.WriteLine("Кубы чисел от 1 до " + N);
        for (int i = 1; i <= N; i++)
            Console.Write(Math.Pow(i, 3) + " ");
        Console.WriteLine();
    }
    else
        Console.WriteLine("Введено число меньше 1!");
}


Zadacha19();
Zadacha21();
Zadacha23();