using OOP1;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

//Tạo đối tượng Category 1
Category c1 = new Category(); //từ khoá "new" giúp ta xin 1 ô nhớ trên thanh ram -> địa chỉ của c1 là địa chỉ của ô nhớ đó trên thanh Ram
//nếu ko dùng từ khoá new thì ô nhớ đó luôn luôn tồn tại
//->có 1 số trường hợp xin là ko được cho phép
c1.id = 1;
c1.name = "Nước mắm";
//xuất thông tin bằng cách gọi hàm
c1.printInfor();
//Giả sử ta đổi giá trị trong ô nhớ đó 
c1.name = "Thuốc trị hôi nách";

Console.WriteLine("Sau khi đổi giá trị:"); // nó chỉ đổi giá trị chứ ô nhớ vẫn là ô nhứo của c1 trên thanh ram
c1.printInfor();

//Tính đóng gói có nghĩa là ở ngoài ko đc phép truy xuất trực tiếp vào thuộc tính của tôi 


//Sử dụng lớp Employee
Console.WriteLine("------------Employee------------");
Employee e1 = new Employee(); //tạo đối tượng e1 từ lớp Employee
e1.id = 1;//gọi setter property của id
e1.idCard = "001"; //gọi setter property của idCard
e1.name = "Tèo";//gọi setter property của name
e1.email ="teo@gmail.com";//gọi setter property của email
e1.phone = "0987654321";//gọi setter property của phone

//xuất thông tin 
e1.printInfor();//gọi hàm xuất thông tin của Employee

Employee e2 = new Employee() //tạo đối tượng e2 từ lớp Employee
{
    id = 2,
    idCard = "001",
    name ="Tý",
    email = "ty@gmail.com",
    phone = "0987654321"
};
Console.WriteLine("Xuất thông tin Employee 2:");
e2.printInfor();//gọi hàm xuất thông tin của Employee

Employee e3 = new Employee();
Console.WriteLine("Xuất thông tin Employee 3:");
e3.printInfor();//gọi hàm xuất thông tin của Employee

//tạo đối tượng Employee 4 
Console.WriteLine("Xuất thông tin Employee 4:");
Employee e4 = new Employee(4, "004", "Tủn", "tun@gmail.com", "010101001010");
e4.printInfor();
Console.WriteLine("Xuất thông tin Employee 4: cách 2");
Console.WriteLine(e4);//tự động gọi hàm toString() của lớp Employee

Console.WriteLine("===============Customer 1================");
Customer cus1 = new Customer()
{
    //tạo đối tượng cus1 từ lớp Customer
    id = 1,
    name = "Nguyễn Thị Lấp Lánh",
    email = "lấp_lá",
    phone = "0987654321",
    address = "Hà Nội"
};
cus1.PrintInfor();//gọi hàm xuất thông tin của Customer
cus1.address = "Số 2 - Hồ Tây - Hồ Hoàn Kiếm - Hồ Gươm -Hà Nội";
Console.WriteLine("Customer sau khi đổi");
cus1.PrintInfor();//gọi hàm xuất thông tin của Customer
