

namespace SimpleEquationSolver
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("РЕШЕНИЕ СИСТЕМ УРАВНЕНИЙ МЕТОДОМ КРАМЕРА");
            Console.WriteLine("==========================================");

            Console.WriteLine("\nВыберите размер системы:");
            Console.WriteLine("1 - 2 уравнения (2x2)");
            Console.WriteLine("2 - 3 уравнения (3x3)");

            int choice;
            while (true)
            {
                Console.Write("Ваш выбор (1 или 2): ");
                if (int.TryParse(Console.ReadLine(), out choice) && (choice == 1 || choice == 2))
                    break;
                Console.WriteLine("Ошибка! Введите 1 или 2.");
            }

            if (choice == 1)
                Solve2x2System();
            else
                Solve3x3System();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void Solve2x2System()
        {
            Console.WriteLine("\n=== СИСТЕМА 2x2 ===");
            Console.WriteLine("Система имеет вид:");
            Console.WriteLine("a11*x1 + a12*x2 = b1");
            Console.WriteLine("a21*x1 + a22*x2 = b2");

            double a11 = ReadNumber("Введите a11: ");
            double a12 = ReadNumber("Введите a12: ");
            double b1 = ReadNumber("Введите b1: ");

            double a21 = ReadNumber("Введите a21: ");
            double a22 = ReadNumber("Введите a22: ");
            double b2 = ReadNumber("Введите b2: ");

            Console.WriteLine("\nВаша система:");
            Console.WriteLine($"{a11}*x1 + {a12}*x2 = {b1}");
            Console.WriteLine($"{a21}*x1 + {a22}*x2 = {b2}");

            double delta = a11 * a22 - a12 * a21;

            if (Math.Abs(delta) < 0.000001)
            {
                Console.WriteLine("\nОшибка! Определитель равен 0.");
                Console.WriteLine("Система не имеет единственного решения.");
                return;
            }

            double delta1 = b1 * a22 - a12 * b2;
            double delta2 = a11 * b2 - b1 * a21;

            double x1 = delta1 / delta;
            double x2 = delta2 / delta;

            Console.WriteLine("\nРЕЗУЛЬТАТ:");
            Console.WriteLine($"Δ = {delta:F4}");
            Console.WriteLine($"Δ1 = {delta1:F4}");
            Console.WriteLine($"Δ2 = {delta2:F4}");
            Console.WriteLine($"x1 = Δ1/Δ = {x1:F4}");
            Console.WriteLine($"x2 = Δ2/Δ = {x2:F4}");

            Console.WriteLine("\nПроверка:");
            double check1 = a11 * x1 + a12 * x2;
            double check2 = a21 * x1 + a22 * x2;
            Console.WriteLine($"1-е уравнение: {a11}*{x1:F4} + {a12}*{x2:F4} = {check1:F4} (должно быть {b1})");
            Console.WriteLine($"2-е уравнение: {a21}*{x1:F4} + {a22}*{x2:F4} = {check2:F4} (должно быть {b2})");
        }

        static void Solve3x3System()
        {
            Console.WriteLine("\n=== СИСТЕМА 3x3 ===");
            Console.WriteLine("Система имеет вид:");
            Console.WriteLine("a11*x1 + a12*x2 + a13*x3 = b1");
            Console.WriteLine("a21*x1 + a22*x2 + a23*x3 = b2");
            Console.WriteLine("a31*x1 + a32*x2 + a33*x3 = b3");

            Console.WriteLine("\nВведите коэффициенты:");
            double a11 = ReadNumber("a11: ");
            double a12 = ReadNumber("a12: ");
            double a13 = ReadNumber("a13: ");
            double b1 = ReadNumber("b1: ");

            double a21 = ReadNumber("a21: ");
            double a22 = ReadNumber("a22: ");
            double a23 = ReadNumber("a23: ");
            double b2 = ReadNumber("b2: ");

            double a31 = ReadNumber("a31: ");
            double a32 = ReadNumber("a32: ");
            double a33 = ReadNumber("a33: ");
            double b3 = ReadNumber("b3: ");

            Console.WriteLine("\nВаша система:");
            Console.WriteLine($"{a11}*x1 + {a12}*x2 + {a13}*x3 = {b1}");
            Console.WriteLine($"{a21}*x1 + {a22}*x2 + {a23}*x3 = {b2}");
            Console.WriteLine($"{a31}*x1 + {a32}*x2 + {a33}*x3 = {b3}");

            double delta = a11 * a22 * a33 + a12 * a23 * a31 + a13 * a21 * a32
                          - a13 * a22 * a31 - a12 * a21 * a33 - a11 * a23 * a32;

            if (Math.Abs(delta) < 0.000001)
            {
                Console.WriteLine("\nОшибка! Определитель равен 0.");
                Console.WriteLine("Система не имеет единственного решения.");
                return;
            }

            double delta1 = b1 * a22 * a33 + a12 * a23 * b3 + a13 * b2 * a32
                           - a13 * a22 * b3 - a12 * b2 * a33 - b1 * a23 * a32;

            double delta2 = a11 * b2 * a33 + b1 * a23 * a31 + a13 * a21 * b3
                           - a13 * b2 * a31 - b1 * a21 * a33 - a11 * a23 * b3;

            double delta3 = a11 * a22 * b3 + a12 * b2 * a31 + b1 * a21 * a32
                           - b1 * a22 * a31 - a12 * a21 * b3 - a11 * b2 * a32;

            double x1 = delta1 / delta;
            double x2 = delta2 / delta;
            double x3 = delta3 / delta;

            Console.WriteLine("\nРЕЗУЛЬТАТ:");
            Console.WriteLine($"Δ = {delta:F4}");
            Console.WriteLine($"Δ1 = {delta1:F4}");
            Console.WriteLine($"Δ2 = {delta2:F4}");
            Console.WriteLine($"Δ3 = {delta3:F4}");
            Console.WriteLine($"x1 = Δ1/Δ = {x1:F4}");
            Console.WriteLine($"x2 = Δ2/Δ = {x2:F4}");
            Console.WriteLine($"x3 = Δ3/Δ = {x3:F4}");

            Console.WriteLine("\nПроверка:");
            double check1 = a11 * x1 + a12 * x2 + a13 * x3;
            double check2 = a21 * x1 + a22 * x2 + a23 * x3;
            double check3 = a31 * x1 + a32 * x2 + a33 * x3;

            Console.WriteLine($"1-е уравнение: {check1:F4} (должно быть {b1})");
            Console.WriteLine($"2-е уравнение: {check2:F4} (должно быть {b2})");
            Console.WriteLine($"3-е уравнение: {check3:F4} (должно быть {b3})");
        }

        static double ReadNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                input = input.Replace('.', ',');

                if (double.TryParse(input, out double result))
                    return result;

                Console.WriteLine("Ошибка! Введите число.");
            }
        }
    }
}
