// Задача 1. Рассчитать значение y при заданном x по формуле
void Zadacha1()
{
    Console.WriteLine("Введите число X");
    double x = Convert.ToInt32(Console.ReadLine());
    double y;
    x = x * Math.PI / 180; // Переводим в радианы

    if (x > 0)
        y = Math.Round(Math.Pow(Math.Sin(x), 2), 3);
    else
        y = Math.Round(1 - 2 * Math.Sin(x*x), 3);
    
    Console.WriteLine("Значение функции Y равно " + y);
}

// Задача 2. Дано трёхзначное число N. Определить кратна ли трём
// сумма всех его цифр.
void Zadacha2()
{
    Console.WriteLine("Введите трехзначное число N");
    int N = Convert.ToInt32(Console.ReadLine());
    int sum;
    
    if (Math.Abs(N) < 100 || Math.Abs(N) > 1000)
        Console.WriteLine("Введено не трехзначное число!");
    else
    {
        sum = N % 10 + N % 100 /10 + N / 100;
        if (sum % 3 == 0)
            Console.WriteLine("Сумма цифр числа " + N + " кратна трем");
        else
            Console.WriteLine("Сумма цифр числа " + N + " не кратна трем");
    }
}

// Задача 3. Дано трёхзначное число N. Определить, есть ли среди его цифр
// 4 или 7.
void Zadacha3()
{
    Console.WriteLine("Введите трехзначное число N");
    int N = Convert.ToInt32(Console.ReadLine());
    int ones, tens, hundreds;
    N = Math.Abs(N);

    if (N < 100 || N > 1000)
        Console.WriteLine("Введено не трехзначное число!");
    else
    {
        ones = N % 10;
        tens = N % 100 /10;
        hundreds = N / 100;
        if ((ones == 4 || tens == 4 || hundreds == 4) && 
            (ones != 7 && tens != 7 && hundreds != 7))
            Console.WriteLine("Среди цифр числа есть число 4");
        else if ((ones == 7 || tens == 7 || hundreds == 7) && 
            (ones != 4 && tens != 4 && hundreds != 4))
            Console.WriteLine("Среди цифр числа есть число 7");
        else if ((ones == 7 || tens == 7 || hundreds == 7) && 
            (ones == 4 || tens == 4 || hundreds == 4))
            Console.WriteLine("Среди цифр числа есть число 4 и 7");
        else
            Console.WriteLine("Среди цифр числа нет чисел 4 и 7");
    }
}

//Задача 4. Дан массив длиной 10 элементов. Заполнить его последовательно
// числами от 1 до 10.
void Zadacha4()
{
    int[] array = new int[10];
    
    Console.WriteLine("Массив:");
    for (int i = 0; i < 10; i++)
    {
        array[i] = i + 1;
        Console.Write(array[i] + "  ");
    }
    Console.WriteLine();
}

// ЗАДАЧИ ПОВЫШЕННОЙ СЛОЖНОСТИ

// Задача 1. На ввод подаётся номер четверти. Создаются 3 случайные точки
// в этой четверти. Определите самый оптимальный маршрут для торгового
// менеджера, который выезжает из центра координат.
void ZadachaPov1()
{
    Console.WriteLine("Введите номер четверти");
    int square = Convert.ToInt32(Console.ReadLine()); // четверть
    int[,] ArrayPoint = new int[3,2];                 // массив точек
    Random rand = new Random();
    double dist12, dist23, dist13, dist01, dist02, dist03; // расстояния между точками
    double MinDist;                      // минимальный путь
    double DistTemp;                     // вспомогательная переменная
    string route;                        // маршрут 

    if (square >= 1 && square <= 4)
    {    
        //Создаем 3 случайные точки
        for (int i = 0; i <= 2; i++)
        {
            if (square == 1)
            {
                ArrayPoint[i,0] = rand.Next(1, 101);
                ArrayPoint[i,1] = rand.Next(1, 101);
                Console.WriteLine("Точка " + (i + 1) + ": " + ArrayPoint[i,0] + " " + ArrayPoint[i,1]);
            }
            else if (square == 2)
            {
                ArrayPoint[i,0] = rand.Next(-101, -1);
                ArrayPoint[i,1] = rand.Next(1, 101);
                Console.WriteLine("Точка " + (i + 1) + ": " + ArrayPoint[i,0] + " " + ArrayPoint[i,1]);
            }
            else if (square == 3)
            {
                ArrayPoint[i,0] = rand.Next(-101, -1);
                ArrayPoint[i,1] = rand.Next(-101 , -1);
                Console.WriteLine("Точка " + (i + 1) + ": " + ArrayPoint[i,0] + " " + ArrayPoint[i,1]);
            }
            else if (square == 4)
            {
                ArrayPoint[i,0] = rand.Next(1, 101);
                ArrayPoint[i,1] = rand.Next(-101, -1);
                Console.WriteLine("Точка " + (i + 1) + ": " + ArrayPoint[i,0] + " " + ArrayPoint[i,1]);
            }
        }
        
        // расстояние между (0,0) и точкой 1
        dist01 = Distance(0, 0, ArrayPoint[0, 0], ArrayPoint[0, 1]);
        // расстояние между (0,0) и точкой 2
        dist02 = Distance(0, 0, ArrayPoint[1, 0], ArrayPoint[1, 1]);
        // расстояние между (0,0) и точкой 2
        dist03 = Distance(0, 0, ArrayPoint[2, 0], ArrayPoint[2, 1]);
        // расстояние между точкой 1 и точкой 2
        dist12 = Distance(ArrayPoint[0, 0], ArrayPoint[0, 1], ArrayPoint[1, 0], ArrayPoint[1, 1]);
        // расстояние между точкой 2 и точкой 3
        dist23 = Distance(ArrayPoint[1, 0], ArrayPoint[1, 1], ArrayPoint[2, 0], ArrayPoint[2, 1]);
        // расстояние между точкой 1 и точкой 3
        dist13 = Distance(ArrayPoint[0, 0], ArrayPoint[0, 1], ArrayPoint[2, 0], ArrayPoint[2, 1]);

        // Считаем, что менеджер выехал из точки (0,0), объехал все три точки
        // и вернулся в точку (0,0)
        MinDist = dist01 + dist12 + dist23 + dist03;
        route = "точка 1, точка 2, точка 3";
        DistTemp = dist01 + dist13 + dist23 + dist02;
        if (DistTemp < MinDist)
        {
            MinDist = DistTemp;
            route = "точка 1, точка 3, точка 2";
        }
        DistTemp = dist02 + dist23 + dist13 + dist01;
        if (DistTemp < MinDist)
        {
            MinDist = DistTemp;
            route = "точка 2, точка 3, точка 1";
        }
        DistTemp = dist02 + dist12 + dist13 + dist03;
        if (DistTemp < MinDist)
        {
            MinDist = DistTemp;
            route = "точка 2, точка 1, точка 3";
        }
        DistTemp = dist03 + dist13 + dist12 + dist02;
        if (DistTemp < MinDist)
        {
            MinDist = DistTemp;
            route = "точка 3, точка 1, точка 2";
        }
        DistTemp = dist03 + dist23 + dist12 + dist01;
        if (DistTemp < MinDist)
        {
            MinDist = DistTemp;
            route = "точка 3, точка 2, точка 1";
        }
        Console.WriteLine("Оптимальный маршрут - " + route);
        Console.WriteLine("Длина маршрута равна " + MinDist);
    }
    else Console.WriteLine("Такого номера четверти не существует!");
}

// Вспомогательный метод - поиск расстояния между двумя точками по их 
// координатам

double Distance(int x1, int y1, int x2, int y2)
{
    double dist = Math.Round(Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)), 2);
    
    return dist;
}



Zadacha1();
Zadacha2();
Zadacha3();
Zadacha4();
ZadachaPov1();