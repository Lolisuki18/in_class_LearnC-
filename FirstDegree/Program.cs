
using System.Text;

void first_degree_solution(double a , double b)
{
    if(a == 0 && b == 0)
    {
        //0x + 0 = 0 -> vô số nghiệm
        Console.WriteLine("Phương trình vô số nghiệm"); 
    }
    else if(a == 0 && b != 0)
    {
        //0x + b = 0 (b!=0)
        Console.WriteLine("Phương trình vô nghiệm");
    }
    else
    {
        Console.WriteLine("X = {0}" , (-b/a));
    }
}
Console.OutputEncoding = Encoding.UTF8; // cho mình bấm tiếng Việt có dấu
Console.WriteLine("Giải phương trình bậc nhất ax + b = 0");
Console.WriteLine("Nhập vào hệ số a: ");
double a = double.Parse(Console.ReadLine()); //đọc vào 1 số thực
Console.WriteLine("Nhập vào hệ số b: ");
double b = double.Parse(Console.ReadLine()); //đọc vào 1 số thực

Console.WriteLine("{0}x + {1} = 0" , a , b); //xuất ra phương trình bậc nhất
first_degree_solution(a, b); //gọi hàm giải phương trình bậc nhất