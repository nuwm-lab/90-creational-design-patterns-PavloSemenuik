using System;

namespace BuildingBlocksFactory
{
    // Базовий інтерфейс для блоків
    interface IBuildingBlock
    {
        void Display();
    }

    // Інтерфейс для круглих блоків
    interface IRoundBlock : IBuildingBlock
    {
        double Radius { get; }
    }

    // Інтерфейс для квадратних блоків
    interface ISquareBlock : IBuildingBlock
    {
        double SideLength { get; }
    }

    // Інтерфейс для трикутних блоків
    interface ITriangleBlock : IBuildingBlock
    {
        double Base { get; }
        double Height { get; }
    }

    // Реалізація круглих блоків
    class RoundBlock : IRoundBlock
    {
        public double Radius { get; }

        public RoundBlock(double radius)
        {
            Radius = radius;
        }

        public void Display()
        {
            Console.WriteLine($"Круглий блок: Радіус = {Radius}");
        }
    }

    // Реалізація квадратних блоків
    class SquareBlock : ISquareBlock
    {
        public double SideLength { get; }

        public SquareBlock(double sideLength)
        {
            SideLength = sideLength;
        }

        public void Display()
        {
            Console.WriteLine($"Квадратний блок: Сторона = {SideLength}");
        }
    }

    // Реалізація трикутних блоків
    class TriangleBlock : ITriangleBlock
    {
        public double Base { get; }
        public double Height { get; }

        public TriangleBlock(double baseLength, double height)
        {
            Base = baseLength;
            Height = height;
        }

        public void Display()
        {
            Console.WriteLine($"Трикутний блок: Основа = {Base}, Висота = {Height}");
        }
    }

    // Абстрактна фабрика
    interface IBuildingBlockFactory
    {
        IBuildingBlock CreateBlock();
    }

    // Параметризована фабрика для круглих блоків
    class RoundBlockFactory : IBuildingBlockFactory
    {
        private readonly double _radius;

        public RoundBlockFactory(double radius)
        {
            _radius = radius;
        }

        public IBuildingBlock CreateBlock()
        {
            return new RoundBlock(_radius);
        }
    }

    // Параметризована фабрика для квадратних блоків
    class SquareBlockFactory : IBuildingBlockFactory
    {
        private readonly double _sideLength;

        public SquareBlockFactory(double sideLength)
        {
            _sideLength = sideLength;
        }

        public IBuildingBlock CreateBlock()
        {
            return new SquareBlock(_sideLength);
        }
    }

    // Параметризована фабрика для трикутних блоків
    class TriangleBlockFactory : IBuildingBlockFactory
    {
        private readonly double _baseLength;
        private readonly double _height;

        public TriangleBlockFactory(double baseLength, double height)
        {
            _baseLength = baseLength;
            _height = height;
        }

        public IBuildingBlock CreateBlock()
        {
            return new TriangleBlock(_baseLength, _height);
        }
    }

    // Клієнтський код
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Оберіть тип будівельного блоку:");
            Console.WriteLine("1 - Круглий блок");
            Console.WriteLine("2 - Квадратний блок");
            Console.WriteLine("3 - Трикутний блок");
            Console.Write("Ваш вибір: ");
            string userChoice = Console.ReadLine();

            IBuildingBlockFactory factory;

            switch (userChoice)
            {
                case "1":
                    Console.Write("Введіть радіус: ");
                    double radius = Convert.ToDouble(Console.ReadLine());
                    factory = new RoundBlockFactory(radius);
                    break;
                case "2":
                    Console.Write("Введіть довжину сторони: ");
                    double side = Convert.ToDouble(Console.ReadLine());
                    factory = new SquareBlockFactory(side);
                    break;
                case "3":
                    Console.Write("Введіть довжину основи: ");
                    double baseLength = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введіть висоту: ");
                    double height = Convert.ToDouble(Console.ReadLine());
                    factory = new TriangleBlockFactory(baseLength, height);
                    break;
                default:
                    Console.WriteLine("Неправильний вибір!");
                    return;
            }

            // Створення блоку і його відображення
            IBuildingBlock block = factory.CreateBlock();
            block.Display();
        }
    }
}
