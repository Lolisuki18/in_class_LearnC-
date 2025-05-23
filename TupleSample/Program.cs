
(int ,double) sumAndAverage(params int[] values)
{
    int sum = 0;
   double avg = 0;
    foreach(int value in values)
    {
        sum += value;
    }
    avg = 1.0 * sum / values.Length;

    return (sum, avg);
}

int[] values = new int[10];
void create_array(int[] values)
{
    Random rd = new Random();
    for(int i = 0; i < values.Length; i++)
    {
        values[i] = rd.Next(100);
    }
}

void print_array(int[] values)
{
    foreach(int value in values)
    {
        Console.Write($"{value}\t");
    }
    Console.WriteLine();
}
create_array(values);
print_array(values);
Console.WriteLine("\n Thông tin sum + avg");
(int sum, double avg) = sumAndAverage(values);
Console.WriteLine($"Sum = {sum}");
Console.WriteLine($"Avg = {avg}");