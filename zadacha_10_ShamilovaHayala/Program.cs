namespace zadacha_10_ShamilovaHayala
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> valuesOfRowOnChessboard = new Dictionary<char, int>()
            {
                {'a', 1}, {'b', 2}, {'c', 3}, {'d', 4}, {'e', 5}, {'f', 6},{'g', 7}, {'h', 8},
            };
            int y1 = 0, y2 = 0;
            char x1 = ' ', x2 = ' ';

            string shape = GetNameShape();
            var valuesCoordinates = GetValuesOfCoordinates(shape, y1, y2);
            x1 = valuesOfRowOnChessboard.FirstOrDefault(x => x.Value == valuesCoordinates.Item1).Key;
            x2 = valuesOfRowOnChessboard.FirstOrDefault(x => x.Value == valuesCoordinates.Item3).Key;
            y1 = valuesCoordinates.Item2;
            y2 = valuesCoordinates.Item4;

            Console.WriteLine($"Координаты {shape} - {x1}{y1}, координаты второго поля - {x2}{y2}");
        }

        // Метод, который получает название фигуры, проверяет её наличие в List и возвращает правильно введённое пользователем название фигуры.   
        static string GetNameShape()
        {
            string shape;
            List<string> nameOfFigures = new List<string> { "ладья", "слон", "король", "ферзь" };
            do
            {
                Console.WriteLine("Введите название фигуры: ");
                shape = Console.ReadLine();
            }
            while (!nameOfFigures.Contains(shape));
            return shape;
        }
        // Метод, который вызывет другой метод и возвращает значения соответствующих координат. 
        static (int, int, int, int) GetValuesOfCoordinates(string shape, int y1, int y2)
        {
            int x1, x2;
            Random random = new Random();
            do
            {
                x1 = random.Next(1, 9);
                y1 = random.Next(1, 9);
                x2 = random.Next(1, 9);
                y2 = random.Next(1, 9);
            }
            while ((CheckFieldsPosition(shape, x1, y1, x2, y2)) == true);
            return (x1, y1, x2, y2);
        }
        // Метод, который проверяет на соответствие формулам координат x1y1 и x2y2 в зависимости от названия фигуры.
        static bool CheckFieldsPosition(string shape, int x1, int y1, int x2, int y2)
        {
            bool result = true;
            switch (shape)
            {
                case "ладья":
                    if (!((x1 == x2) || (y1 == y2)))
                        result = false;
                    break;
                case "слон":
                    if (!(Math.Abs(x1 - x2) == Math.Abs(y1 - y2)))
                        result = false;
                    break;
                case "король":
                    if ((Math.Abs(x1 - x2) <= 1 && Math.Abs(y1 - y2) <= 1))
                        result = false;
                    break;
                case "ферзь":
                    if (!(Math.Abs(x1 - x2) == Math.Abs(y1 - y2) || ((x1 == x2) || (y1 == y2))))
                        result = false;
                    break;
            }
            return result;
        }
    }
}