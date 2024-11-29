using System;
using System.Collections.Generic;

class Program
{
    // Вынесем смволы для разделения слов для более правильной и понятной структуры
    // Также если нужно чтобы слова учитывались без знаков например точек и зпятых как это происходит сйчас
    // можно добавить в массив эти символы => { ' ', '.', ',' }
    private static readonly char[] Delimiters = { ' '};
    
    static void Main(string[] args)
    {
        string text = "Это пример текста. Текст должен быть проанализирован. Это важно.";
        Dictionary<string, int> wordCounts = WordFrequency(text);

        foreach (var item in wordCounts)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }
    }

    static Dictionary<string, int> WordFrequency(string text)
    {
        // Разбиваем строку на слова и избавляемся от пустых слов
        return text.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries)
            // Приводим слова к нижнему регистру и убираем метод Trim так как он избыточен мы и так убрали пробелы ранее,
            // но в задании сказано что нужно учитывать регистр,
            // какая то ошибка ведь изначально в коде все приводилось к нижнему регистру,
            // поэтому если его нужно учитывать то можно убрать это
            .Select(word => word.ToLower())
            .GroupBy(word => word)  // Группируем слова, ны выходе получаем пары - ключ это слово, а значение это массив слов повторяющихся в тексте
            .ToDictionary(group => group.Key, group => group.Count()); // Формируем итоговый словарь.
        // все эти методы (Select, GroupBy, ToDictionary) являются частью LINQ и гораздо упрощают работу данный функции 
    }
}