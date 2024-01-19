using System;

// Интерфейс стратегии
public interface ISortStrategy
{
    void Sort(int[] array);
}

// Конкретная стратегия - сортировка по возрастанию
public class AscendingSortStrategy : ISortStrategy
{
    public void Sort(int[] array)
    {
        Array.Sort(array);
        Console.WriteLine("Sorted in ascending order");
    }
}

// Конкретная стратегия - сортировка по убыванию
public class DescendingSortStrategy : ISortStrategy
{
    public void Sort(int[] array)
    {
        Array.Sort(array);
        Array.Reverse(array);
        Console.WriteLine("Sorted in descending order");
    }
}

// Контекст, использующий стратегию
public class SortContext
{
    private ISortStrategy sortStrategy;

    public void SetSortStrategy(ISortStrategy strategy)
    {
        sortStrategy = strategy;
    }

    public void ExecuteSort(int[] array)
    {
        Console.WriteLine("Sorting started...");
        sortStrategy.Sort(array);
        Console.WriteLine("Sorting completed.");
    }
}

// Клиентский код
class Program
{
    static void Main()
    {
        int[] numbers = { 5, 2, 8, 1, 7 };

        SortContext context = new SortContext();

        // Используем стратегию сортировки по возрастанию
        context.SetSortStrategy(new AscendingSortStrategy());
        context.ExecuteSort(numbers);

        Console.WriteLine("Result: " + string.Join(", ", numbers));

        // Используем стратегию сортировки по убыванию
        context.SetSortStrategy(new DescendingSortStrategy());
        context.ExecuteSort(numbers);

        Console.WriteLine("Result: " + string.Join(", ", numbers));
    }
}
