using DemoAliasClone;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Customer c1 = new Customer
{
    id = 1,
    name = "Trần Thị Tèo"
};

Customer c2 = new Customer
{
    id = 2,
    name = "Nguyễn Văn Tẹt"
};

c1 = c2;
//là c1 đang trỏ đến vùng nhớ mà c2 đang quản lý -> chứ ko phải là c1 = c2
//=> Lúc này xảy ra 2 tình huống :
//(1) ô nhớ alpha mà c1 quản lý lúc nãy bị trống , ko còn đối tượng nào tham gia quản lý nữa 
// => lúc này thì hệ điều hành sẽ thu hồi ô nhớ alpha mà c1 quản lý lúc nãy
//->Gọi là cơ chế gôm rác tự động -> Automatic Garbage Collection
//->Ta ko thể lấy được giá trị tại ô nhớ này nữa 
//(2) lúc này ô nhớ Beta sẽ có 2 đối tượng tham gia quản lý là c1 và c2
//-Đối tượng ban đầu là c2
//-Bây giờ có thêm đối tượng c1 quản lý
//Trường hợp 1 ô nhớ từ từ 2 đối tượng trở lên tham gia quản lý nó được gọi là Alias:
//  -> bất kỳ đối tượng nào đổi giá trị tại ô nhớ Beta
//  -> thì đối tượng còn lại cũng sẽ bị ảnh hưởng theo

c1.name = "Hồ Đồ";
//thì lúc này c2 cũng bị đổi tên thành "Hồ Đồ"
//vì c1 và c2 đều đang quản lý ô nhớ Beta
Console.WriteLine("Tên của c2 = " +c2.name);

Customer c3 = new Customer();
Customer c4 = c3;

c3 = c1;

//Lúc này ko có thu hồi ô nhớ của c3 đang quản lý ở dòng 37
//bởi vì có c4 đang quản lý ô nhớ này

Product p1 = new Product
{
    id = 1,
    name = "Bánh mì ram ram",
    quantity = 10,
    price = 20
};

Product p2 = new Product
{
    id = 2,
    name = "Quái vật vật lý",
    quantity = 15,
    price = 22
};

p1 = p2; //lúc này p1 đang trỏ đến vùng nhớ mà p2 đang quản lý

//alias xảy ra với p1 và p2
//=> nếu ta thay đổi giá trị của p1 thì p2 cũng sẽ bị ảnh hưởng theo
//nếu ko có gì quản lý giá trị của p1 nữa thì nó sẽ bị thu hồi vì ko còn j quản lý ô nhớ của p1 cũ nữa

Console.WriteLine("-------Thông tin của p1-------");
Console.WriteLine(p1.ToString());
Console.WriteLine("-------Thông tin của p2-------");
Console.WriteLine(p2.ToString());

p2.name = "Quái vật C#";
p2.quantity = 50;
p2.price = 10;

Console.WriteLine("-------Thông tin của p1 sau khi  p2 đổi giá trị thay đổi-------");
Console.WriteLine(p1.ToString());

Product p3 = new Product
{
    id = 3,
    name = "Quái vật C++",
    quantity = 15,
    price = 50
};
Product p4 = new Product
{
    id = 4,
    name = "Quái vật Java",
    quantity = 100,
    price = 2000
};

Product p5 = p3;
p3 = p4; //p3 đang trỏ đến vùng nhớ mà p4 đang quản lý

//Hệ điều hành có thu hổi ô nhớ đã cấp phát cho p3 quản lý trước đó hay không ? vì sao ? 

//Trả lời: Không, vì p5 vẫn đang quản lý ô nhớ mà p3 đã quản lý trước đó
//Nếu bổ sung 

p5 = p3;
// thì có thu hồi ô nhớ đã cấp phát cho p3 hay không ? vì sao ?
//Trả lời: Có, vì lúc này p5 đang trỏ đến vùng nhớ mà p3 đang quản lý
//=> lúc này p3 sẽ bị thu hồi ô nhớ mà nó đang quản lý trước đó
//vì ko còn đối tượng nào quản lý ô nhớ này nữa

Product p6 =p4.Clone();
//Lúc này hệ điều hành sẽ sao  chép toàn bộ dự liệu trong ô nhớ mà p4 đang quản lý qua  1 ô nhớ mới 
// và giao cho p6 quản lý ô nhớ mới này
//p4 và p6 quản lý 2 ô nhớ khác nhau hoàn toàn , nhưng có giá trị giống nhau
//=> p6 ko liên can tới p4 và ngược lại 
Console.WriteLine("-------Thông tin của p4-------");
Console.WriteLine(p4.ToString());
Console.WriteLine("-------Thông tin của p6-------");
Console.WriteLine(p6.ToString());

p4.name = "Quái vật ReactJS";
//p6 sẽ ko thay đổi vì nó nằm trong 1 ô nhớ khác
Console.WriteLine("-------Thông tin của p4-------");
Console.WriteLine(p4.ToString());
Console.WriteLine("-------Thông tin của p6-------");
Console.WriteLine(p6.ToString());