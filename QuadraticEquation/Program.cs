
using System.Text;

void first_degree_solution(double a, double b)
{
    if (a == 0 && b == 0)
    {
        //0x + 0 = 0 -> vô số nghiệm
        Console.WriteLine("Phương trình vô số nghiệm");
    }
    else if (a == 0 && b != 0)
    {
        //0x + b = 0 (b!=0)
        Console.WriteLine("Phương trình vô nghiệm");
    }
    else
    {
        Console.WriteLine("X = {0}", (-b / a));
    }
}

void quadratic_equation_solution(double a , double b,double c)
{
    if( a == 0)
    {
        //phương trình bậc 1 : bx + c = 0
        first_degree_solution (b, c);
    }
    else
    {
        var delta = Math.Pow(b,2) - 4 * a * c; //tính delta
        if(delta < 0)
        {
            Console.WriteLine("Phương trình vô nghiệm");
        }else if(delta == 0)
        {
            Console.WriteLine("Phương trình có nghiệm kép x1 = x2 = {0}", -b / (2 * a));
        }
        else
        {
            Console.WriteLine("Phương trình có 2 nghiệm phân biệt:");
            var x1 = (-b + Math.Sqrt(delta)) / (2 * a); //tính nghiệm x1
            var x2 = (-b - Math.Sqrt(delta)) / (2 * a); //tính nghiệm x2
            Console.WriteLine("x1 = {0}", x1); //xuất ra nghiệm x1
            Console.WriteLine("x2 = {0}", x2); //xuất ra nghiệm x2
        }
    }
}
Console.OutputEncoding = Encoding.UTF8; // cho mình bấm tiếng Việt có dấu
Console.WriteLine("Giải phương trình bậc hai ax^2 + bx + c = 0");
Console.WriteLine("Nhập vào hệ số a: ");
double a = double.Parse(Console.ReadLine()); //đọc vào 1 số thực
Console.WriteLine("Nhập vào hệ số b: ");
double b = double.Parse(Console.ReadLine()); //đọc vào 1 số thực
Console.WriteLine("Nhập vào hệ số c: ");
double c = double.Parse(Console.ReadLine()); //đọc vào 1 số thực
Console.WriteLine("{0}x^2 + {1}x + {2} = 0", a, b,c); //xuất ra phương trình bậc hai
quadratic_equation_solution(a, b, c); //gọi hàm giải phương trình bậc nhất
Console.ReadLine(); //dừng