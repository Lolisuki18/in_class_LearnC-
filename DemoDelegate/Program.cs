using System.Text;

class Program
{
    public delegate int MyDelegate(int x, int y);
   
    static int Cong(int a, int b)
    {
        return a + b;
    }

    static int Tru(int a, int b)
    {
        return a - b;
    }

    public delegate int[] YourDelegate(int n);

    static int[] DanhSachSoChan(int n)
    {
        List<int> list = new List<int>();
        for (int i = 2; i <= n; i = i + 2)
        {
            list.Add(i);
        }
        return list.ToArray();
    }

    static int[] DanhSachSoNguyenTo(int n)
    {
        List<int> list = new List<int>();
        for (int i = 2; i <= n; i++)
        {
            int count = 0;
            for(int j=1; j<= i; j++)
            {
                if(i%j == 0)
                {
                    count++;
                }
                
            }
            if (count == 2)
            {
                list.Add(i);
            }
        }
        return list.ToArray();
    }
    //Delegate là gọi hàm 1 cách gián tiếp thông qua 1 biến
    //Chỉ cần giống format kiểu dữ liệu truyền vào , và kiểu dữ liệu truyền ra 

    public static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        MyDelegate m = new MyDelegate(Cong);
        Console.WriteLine("5 + 8 = " + m(5, 8));
        m = new MyDelegate(Tru);
        Console.WriteLine("5 - 8 = " + m(5, 8));
        YourDelegate y = new YourDelegate(DanhSachSoChan);
        int[] arr = y(10);
        Console.WriteLine("Các số chẳn là ");
        foreach (var item in arr)
        {
            Console.Write(item + "\t");
        }
        Console.WriteLine();
        y = new YourDelegate(DanhSachSoNguyenTo);
        int[] arr1 = y(10);
        Console.WriteLine("Các số Nguyên tố là ");
        foreach (var item in arr1)
        {
            Console.Write(item + "\t");
        }
    }
}