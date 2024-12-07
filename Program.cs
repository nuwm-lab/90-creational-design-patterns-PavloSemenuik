using System;

namespace BuildingBlocksFactory
{
    // Базовий інтерфейс для блоків
    /// <summary>
    /// Інтерфейс для всіх типів будівельних блоків.
    /// </summary>
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
            if (radius <= 0)
                throw new ArgumentException("Радіус має бути більшим за нуль.");
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
            if (sideLength <= 0)
                throw new ArgumentException("Сторона має бути більшою за нуль.");
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
            if (baseLength <= 0 || height <= 0)
                throw new ArgumentException("Основа та висота мають бути більшими за нуль.");
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
            try
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
                        double radius = GetPositiveDouble("Введіть радіус: ");
                        factory = new RoundBlockFactory(radius);
                        break;
                    case "2":
                        double side = GetPositiveDouble("Введіть довжину сторони: ");
                        factory = new SquareBlockFactory(side);
                        break;
                    case "3":
                        double baseLength = GetPositiveDouble("Введіть довжину основи: ");
                        double height = GetPositiveDouble("Введіть висоту: ");
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
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        /// <summary>
        /// Запитує у користувача позитивне число з повідомленням.
        /// </summary>
        /// <param name="message">Повідомлення для користувача.</param>
        /// <returns>Позитивне число.</returns>
        private static double GetPositiveDouble(string message)
        {
            double value;
            do
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (double.TryParse(input, out value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine("Будь ласка, введіть коректне число більше за нуль.");
            } while (true);
        }
    }
}
