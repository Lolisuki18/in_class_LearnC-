void swap(ref int x , ref int y)
{
    int temp = x;
    x = y;
    y = temp;
}

void sort_array(int []arr)
{
    for(int i = 0;i <= arr.Length - 1; i++)
    {
        for(int j = i + 1; j < arr.Length; j++)
        {
            if(arr[i] > arr[j])
            {
                swap(ref arr[i], ref arr[j]);
            }
        }
    }
}

//sort_array(int[] arr) - do_while
void sort_array_Do_while(int[] arr)
{
   int  i = 0;
   
    do
    {
        int j = i + 1;
        do
        {
            if (arr[i] < arr[j])
            {
                swap(ref arr[i], ref arr[j]);
            }
            j += 1;
            Console.WriteLine("\n while 2");

        } while (j < arr.Length);
        i += 1;
        Console.WriteLine("\n while 1");
    } while (i < arr.Length - 1);
}
//sort_array_while(int[] arr) - while
void sort_array_while(int[] arr)
{
    int i = 0;
    while ( i < arr.Length - 1)
    {
        int j = i + 1;
        while (j < arr.Length)
        {
            if (arr[i] < arr[j])
            {
                swap(ref arr[i], ref arr[j]);
            }
            j += 1;
        }
        i += 1;
    }   
}

int[] values = new int[5];
void create_array(int[] values)
{
    Random rd = new Random();
    for (int i = 0; i < values.Length; i++)
    {
        values[i] = rd.Next(100);
    }
}

void print_array(int[] values)
{
    foreach (int value in values)
    {
        Console.Write($"{value}\t");
    }
    Console.WriteLine();
}
create_array(values);
print_array(values);
//sort_array(values);
//sort_array_Do_while(values);
sort_array_while(values);
Console.WriteLine("\n AFTER SORTING");
print_array(values);

//sort bằng while và sort bằng do_while

