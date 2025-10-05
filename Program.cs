using System;

class zadanie1
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("введите 1 число, операцию, 2 число (или 'exit' для выхода)");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
                break;

            try
            {
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 3)
                {
                    Console.WriteLine("error");
                    continue;
                }

                double operand1 = Convert.ToDouble(parts[0]);
                string operation = parts[1];
                double operand2 = Convert.ToDouble(parts[2]);

                double result;

                switch (operation)
                {
                    case "+":
                        result = Add(operand1, operand2);
                        break;
                    case "-":
                        result = Subtract(operand1, operand2);
                        break;
                    case "*":
                        result = Multiply(operand1, operand2);
                        break;
                    case "/":
                        result = Divide(operand1, operand2);
                        break;
                    case "^":
                        result = Power(operand1, operand2);
                        break;
                    default:
                        Console.WriteLine("неизвестная операция.");
                        continue;
                }

                Console.WriteLine($"результат: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("error");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("error");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        Console.WriteLine("программа завершена.");
    }

    static double Add(double a, double b)
    {
        return a + b;
    }

    static double Subtract(double a, double b)
    {
        return a - b;
    }

    static double Multiply(double a, double b)
    {
        return a * b;
    }

    static double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException();
        return a / b;
    }

    static double Power(double a, double b)
    {
        return Math.Pow(a, b);
    }
}

class zadanie3
{
    static void Main()
    {
        Console.Write("введите делимое: ");
        double dividend = ReadDouble();

        double divisor;
        while (true)
        {
            Console.Write("введите делитель: ");
            divisor = ReadDouble();

            if (divisor == 0)
            {
                Console.WriteLine("на ноль делить нельзя. повторите ввод делителя:");
            }
            else
            {
                break;
            }
        }

        double result = dividend / divisor;
        Console.WriteLine($"результат деления: {result}");
    }
    static double ReadDouble()
    {
        while (true)
        {
            string input = Console.ReadLine();
            try
            {
                return Convert.ToDouble(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число:");
            }
        }
    }
}

class zadanie4
{
    static void Main()
    {
        int num;
        Console.WriteLine("введите целое число:");

        while (true)
        {
            string input = Console.ReadLine();

            try
            {
                num = Convert.ToInt32(input);
                Console.WriteLine($"вы ввели число: {num}");
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("error");
            }
            catch (OverflowException)
            {
                Console.WriteLine("error");
            }
        }
    }
}

class zadanie5
{
    static void Main()
    {
        Console.WriteLine("Калькулятор");
        Console.Write("Введите первое число: ");
        string input1 = Console.ReadLine();

        // Ошибка 1: Присваивание неверной переменной
        double num1 = Convert.ToDouble(input1); // Нормально, но предположим, что ошибка в другом месте

        Console.Write("Введите оператор (+, -, *, /): ");
        string op = Console.ReadLine();

        Console.Write("Введите второе число: ");
        string input2 = Console.ReadLine();

        //нет проверки на формат
        int num2 = Convert.ToInt32(input2); //ввод некорректен, произойдёт исключение

        double result;

        //нет проверки деления на ноль
        if (op == "+")
        {
            result = num1 + num2;
        }
        else if (op == "-")
        {
            result = num1 - num2;
        }
        else if (op == "*")
        {
            result = num1 * num2;
        }
        else if (op == "/")
        {
            //нет проверки
            result = num1 / num2;
        }
        else
        {
            Console.WriteLine("error");
            return;
        }

        Console.WriteLine($"hезультат: {result}");
    }
}

class zadanie5Fix
{
    static void Main()
    {
        Console.WriteLine("калькулятор");

        double num1;
        //добавлена обработка ошибок при вводе числа
        while (true)
        {
            Console.Write("введите первое число: ");
            string input1 = Console.ReadLine();
            try
            {
                num1 = Convert.ToDouble(input1);
                break; //выход из цикла, если ввод корректен
            }
            catch (FormatException)
            {
                Console.WriteLine("error");
            }
        }

        Console.Write("Введите оператор (+, -, *, /): ");
        string op = Console.ReadLine();

        int num2;
        //обработка ошибок при вводе второго числа
        while (true)
        {
            Console.Write("введите второе число: ");
            string input2 = Console.ReadLine();
            try
            {
                num2 = Convert.ToInt32(input2);
                break; //число корректно
            }
            catch (FormatException)
            {
                Console.WriteLine("error");
            }
        }

        double result;

        //проверка деления на ноль
        if (op == "/")
        {
            if (num2 == 0)
            {
                Console.WriteLine("error");
                return;
            }
            result = num1 / num2;
        }
        else if (op == "+")
        {
            result = num1 + num2;
        }
        else if (op == "-")
        {
            result = num1 - num2;
        }
        else if (op == "*")
        {
            result = num1 * num2;
        }
        else
        {
            Console.WriteLine("error");
            return;
        }

        Console.WriteLine($"результат: {result}");
    }
}
