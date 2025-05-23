/*
 Đề bài 
Nhập vào 1 số  >= 0 nếu nhập sai bắt nhập lại 
Nếu nhập đúng ==> tính giai thừa của nó

 */

using System.Text;
Console.OutputEncoding = Encoding.UTF8; // cho mình bấm tiếng Việt có dấu

int n = -1;
while (n < 0)
{
    Console.WriteLine("Nhập số nguyên dương n (n > 0) : ");
    string s = Console.ReadLine(); 
    if(int.TryParse(s,out n) == false)
        //nếu nó bằng fall thì nó ko truyển đồi về thành số được -> trả về cho chúng ta cái giá trị mà nó 
        //đã truyển đổi thành công
    {
        Console.WriteLine("Bạn phải nhập số!!!");
    }
    else
    {
        if(n < 0)
        {
            Console.WriteLine("Bạn phải nhập số dương (n >= 0)!!!");
        }
    }
}
int gt = 1;
for (int i = 1; i <= n; i++)
{
       gt *= i; //gt = gt * i
}
Console.WriteLine($"{n}! = {gt}");