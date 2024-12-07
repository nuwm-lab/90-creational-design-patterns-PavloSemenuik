using System;

namespace BuildingBlocksFactory
{
    // Абстрактний продукт
    abstract class BuildingBlock
    {
        public abstract void Display();
    }

    // Конкретні продукти
    class RoundBlock : BuildingBlock
    {
        public override void Display()
        {
            Console.WriteLine("Це круглий будівельний блок.");
        }
    }

    class SquareBlock : BuildingBlock
    {
        public override void Display()
        {
            Console.WriteLine("Це квадратний будівельний блок.");
        }
    }

    class TriangleBlock : BuildingBlock
    {
        public override void Display()
        {
            Console.WriteLine("Це трикутний будівельний блок.");
        }
    }

    // Абстрактна фабрика
    interface IBuildingBlockFactory
    {
        BuildingBlock CreateBlock();
    }

    // Конкретні фабрики
    class RoundBlockFactory : IBuildingBlockFactory
    {
        public BuildingBlock CreateBlock()
        {
            return new RoundBlock();
        }
    }

    class SquareBlockFactory : IBuildingBlockFactory
    {
        public BuildingBlock CreateBlock()
        {
            return new SquareBlock();
        }
    }

    class TriangleBlockFactory : IBuildingBlockFactory
    {
        public BuildingBlock CreateBlock()
        {
            return new TriangleBlock();
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
                    factory = new RoundBlockFactory();
                    break;
                case "2":
                    factory = new SquareBlockFactory();
                    break;
                case "3":
                    factory = new TriangleBlockFactory();
                    break;
                default:
                    Console.WriteLine("Неправильний вибір!");
                    return;
            }

            // Створюємо блок через фабрику
            BuildingBlock block = factory.CreateBlock();
            block.Display();
        }
    }
}
