using OOP3;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

int n1 = 5;
int n2 = 10;
Console.WriteLine($"Tổng từ 1 tới {n1} = {n1.TongTu1ToN()}");
Console.WriteLine($"Tổng từ 1 tới {n2} = {n2.TongTu1ToN()}");
Console.WriteLine("Tổng từ 1 tới 8 = " +8.TongTu1ToN());

Console.WriteLine("Tổng 8 + 7 =" +8.Cong(7));

int[]M = new int[8];
M.TaoMang();
Console.WriteLine("Mảng M sau khi tạo ngẫu nhiên là:");
M.XuatMang();

M.SapXepMangTangDan();
Console.WriteLine("Mảng M sau khi sắp xếp tăng dần là:");
M.XuatMang();

int[] M2 = M.SapXepMangGiamDan();
Console.WriteLine("Mảng M sau khi sắp xếp giảm dần là:");
M2.XuatMang();