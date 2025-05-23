using System.Text;

Console.OutputEncoding = Encoding.UTF8;
void ham1(int n)
{
    n = 8;
    Console.WriteLine($"n trong hàm = {n}");
}

int n = 5;
Console.WriteLine($"n trước khi vào hàm = {n}");
ham1(n);
//N ko bị đổi -> ko bị đổi như vậy gọi là call by value
//n là biến kiểu giá trị -> khi truyền vào hàm thì nó sẽ copy giá trị của n vào trong hàm
Console.WriteLine($"n sau khi vào hàm = {n}");

Console.WriteLine("-----------------------------");
//out là bắt buộc phải có giá trị thì mới thoát

//call by refenren - > tham chiếu 
void ham2(ref int n)
{
    n = 8;
    Console.WriteLine($"n trong hàm = {n}");
}
Console.WriteLine($"n trước khi vào hàm = {n}");
//Console.WriteLine("-----------------------------");
ham2(ref n); //ref là tham chiếu -> truyền vào địa chỉ của biến n
Console.WriteLine($"n sau khi vào hàm = {n}");

//int m;
//ham2(ref m); //m chưa có giá trị -> phải có giá trị thì mới thoát

int m = 100;
ham2(ref m); //m đã có giá trị -> truyền vào địa chỉ của biến m

//->ref yêu cầu cái biến truyền vào phải có giá trị

Console.WriteLine("-----------------------------");

void ham3(out int n)
{
    n = 9;
}
//yêu cầu của out là n phải có giá trị  
// -> ko cần khởi tạo giá trị ban đầu trước -> vào bên trong bắt buộc phải khởi tạo giá trị cho biến đó 
//còn ref thì bắt buộc phải khởi tạo giá trị trước rồi mới truyền vào

n = 113;
ham3(out n); //out là tham chiếu -> truyền vào địa chỉ của biến n
