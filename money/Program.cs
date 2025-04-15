using money;
using System;

public class Program
{
    public static void Main()
    {
        try
        {
            Money m1 = new Money(10, 50); 
            Money m2 = new Money(5, 75); 

            while (true)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Сложение (+)");
                Console.WriteLine("2. Вычитание (-)");
                Console.WriteLine("3. Деление на число (/)");
                Console.WriteLine("4. Умножение на число (*)");
                Console.WriteLine("5. Инкремент (++)");
                Console.WriteLine("6. Декремент (--)");
                Console.WriteLine("7. Сравнение (==)");
                Console.WriteLine("8. Сравнение (!=)");
                Console.WriteLine("9. Сравнение (<)");
                Console.WriteLine("10. Сравнение (>)");
                Console.WriteLine("0. Выход");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"{m1} + {m2} = {m1 + m2}");
                        break;
                    case 2:
                        Console.WriteLine($"{m1} - {m2} = {m1 - m2}");
                        break;
                    case 3:
                        Console.WriteLine("Введите делитель:");
                        int divisor = int.Parse(Console.ReadLine());
                        Console.WriteLine($"{m1} / {divisor} = {m1 / divisor}");
                        break;
                    case 4:
                        Console.WriteLine("Введите множитель:");
                        int multiplier = int.Parse(Console.ReadLine());
                        Console.WriteLine($"{m1} * {multiplier} = {m1 * multiplier}");
                        break;
                    case 5:
                        Console.WriteLine($"{m1}++ = {m1++}");
                        break;
                    case 6:
                        Console.WriteLine($"{m1}-- = {m1--}");
                        break;
                    case 7:
                        Console.WriteLine($"{m1} == {m2} : {m1 == m2}");
                        break;
                    case 8:
                        Console.WriteLine($"{m1} != {m2} : {m1 != m2}");
                        break;
                    case 9:
                        Console.WriteLine($"{m1} < {m2} : {m1 < m2}");
                        break;
                    case 10:
                        Console.WriteLine($"{m1} > {m2} : {m1 > m2}");
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }
        catch (BankruptException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}