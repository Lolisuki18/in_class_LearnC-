using OOP2;
using OOP4_Reuser_OOP2;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

FulltimeEmployee fe = new FulltimeEmployee();
fe.id = 1;
fe.name = "Nguyễn Văn A";  
fe.birthday = new DateTime(1990, 5, 1);
fe.idCard = "123456789";
Console.WriteLine(fe);
Console.WriteLine("Tuổi của nhân viên  là:" +   fe.Tuoi());
//hãy bổ sung thêm 1 extension method trả về là có phải tháng này là tháng sinh nhật của nhân viên đó hay không ?
// Hãy sử dụng extension method để làm việc này
//fe.LaThangSinhNhat() trả về true nếu tháng này là tháng sinh nhật của nhân viên đó, ngược lại trả về false
if (fe.LaThangSinhNhat())
{
    Console.WriteLine("Tháng này là tháng sinh nhật của nhân viên " + fe.name);
}
else
{
    Console.WriteLine("Tháng này là không phải tháng sinh nhật của nhân viên " + fe.name);
}
