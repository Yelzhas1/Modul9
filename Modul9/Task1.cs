using System;

// Создание собственного исключения
public class MyException : Exception
{
    public MyException(string message) : base(message) { }
}

class Task1
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Блок try начал свою работу.");
            throw new MyException("Это моё собственное исключение.");
            throw new ArgumentNullException("Аргумент не может быть null.");
            throw new IndexOutOfRangeException("Индекс вне диапазона массива.");
            throw new DivideByZeroException("Деление на ноль.");
            throw new InvalidOperationException("Недопустимая операция.");
        }
        catch (MyException ex)
        {
            Console.WriteLine("Произошло исключение!: " + ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Произошло исключение!: " + ex.Message);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Произошло исключение!: " + ex.Message);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Произошло исключение!: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Произошло исключение!: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Блок finally сработал!");
        }
    }
}
