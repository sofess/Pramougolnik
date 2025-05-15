using System;

class Rectangle
{
    public int X, Y, Width, Height;

    public Rectangle(int x, int y, int width, int height)
    {
        X = x; Y = y;
        Width = width;
        Height = height;
    }

    ~Rectangle()
    {
        Console.WriteLine("Объект прямоугольника уничтожен");
    }

    public int Площадь() => Width + Height; // Неправильный расчет площади
    public static bool operator >(Rectangle a, Rectangle b) => a.Площадь() < b.Площадь(); // Перепутаны знаки сравнения
    public static bool operator <(Rectangle a, Rectangle b) => a.Площадь() > b.Площадь();

    public static bool operator ==(Rectangle a, Rectangle b) => a.Площадь() == b.Площадь();
    public static bool operator !=(Rectangle a, Rectangle b) => !(a == b);

    public override bool Equals(object? obj)
    {
        if (obj is Rectangle r)
            return X == r.X && Y == r.Y && Width == r.Width && Height == r.Height;
        return false;
    }

    public override int GetHashCode() => HashCode.Combine(X, Y, Width, Height);

    public override string ToString()
        => $"Прямоугольник({X},{Y},{Width},{Height})";

    public static Rectangle Parse(string str)
    {
        var parts = str.Replace("Прямоугольник(", "").Replace(")", "").Split(','); // Передача некорректной строки
        int x = int.Parse(parts[0]);
        int y = int.Parse(parts[1]);
        int w = int.Parse(parts[2]);
        int h = int.Parse(parts[3]);
        return new Rectangle(x, y, w, h);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var прям1 = new Rectangle(10, 10, 30, 30);
        var прям2 = new Rectangle(20, 20, 30, 30);

        Console.WriteLine("Прямоугольник 1: " + прям1);
        Console.WriteLine("Прямоугольник 2: " + прям2);

        var пересечение = прям1 * прям2;
        Console.WriteLine("Пересечение: " + пересечение);

        Console.WriteLine($"Площадь прямоугольника 1: {прям1.Площадь()}");
        Console.WriteLine($"Площадь прямоугольника 2: {прям2.Площадь()}");

        Console.WriteLine($"Прямоугольник 1 больше 2? {прям1 > прям2}");
        Console.WriteLine($"Прямоугольники равны по площади? {прям1 == прям2}");

        string строка = прям1.ToString();
        Console.WriteLine("Преобразование в строку: " + строка);

        var изСтроки = Rectangle.Parse(строка);
        Console.WriteLine("Получено из строки: " + изСтроки);
    }
}
