/*
 * Sử dụng Generic List để quản lý nhân sự với đầy đủ tính năng  CRUD (Create, Read, Update, Delete) và tìm kiếm theo tên nhân viên.
 * C- Create: Tạo mới dữ liệu
 * R- Read/Retrieve: Xem, lọc , tìm kiếm, sắp xếp, thống kê dữ liệu,....
 * U -> Update: Cập nhật dữ liệu -> Sửa dữ liệu
 * D -> Delete : Xoá dữ liệu 
 * 
 */

//Câu 1 : Tạo 5 nhân viên trong đó 3 nhân viên chính thức và 2 thời vụ 
//Lưu vào Generic List

using OOP2;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
Console.OutputEncoding = Encoding.UTF8;
List<Employee> employees = new List<Employee>();
FulltimeEmployee fe1 = new FulltimeEmployee()
{
    id = 1,
    idCard = "123",
    name ="Name 1",
    birthday = new DateTime(1990, 1, 1),
};
employees.Add(fe1);

FulltimeEmployee fe2 = new FulltimeEmployee()
{
    id = 2,
    idCard = "456",
    name = "Name 2",
    birthday = new DateTime(1990, 12, 1),
};
employees.Add(fe2);


FulltimeEmployee fe3 = new FulltimeEmployee()
{
    id = 3,
    idCard = "789",
    name = "Name 3",
    birthday = new DateTime(1999, 12, 11),
};
employees.Add(fe3);

ParttimeEmployee pe1 = new ParttimeEmployee()
{
    id = 4,
    idCard = "7829",
    name = "Name 4",
    birthday = new DateTime(1995, 1, 1),
    workingHours = 20
};
employees.Add(pe1);

ParttimeEmployee pe2 = new ParttimeEmployee()
{
    id = 5,
    idCard = "78229",
    name = "Name 5",
    birthday = new DateTime(1995, 2, 1),
    workingHours = 10
};
employees.Add(pe2);

//Câu 2 : Xuất toàn bộ nhân sự :
Console.WriteLine("câu 2 : R -> xuất toàn bộ dữ liệu");
//cách 1 : 
employees.ForEach(e => Console.WriteLine(e));// sử dụng lambda expression để xuất toàn bộ nhân viên

//Câu 3: R-> Lọc ra các nhân sự là chính thức 
//Cách 1 : 
List<FulltimeEmployee> fe_list = employees.OfType<FulltimeEmployee>().ToList();
Console.WriteLine("câu 3 : R -> xuất toàn bộ dữ liệu của nhân sự chính thức");
foreach (FulltimeEmployee fe in fe_list)
{
    Console.WriteLine(fe);
}

//Câu 4 : Tính tổng tiền lương phải trả cho nhân viên chính thức 
//Tính tổng tiền lương phải trả cho nhân viên thời vụ
//Tổng lương phải trả cho toàn bộ nhân viên
Console.WriteLine("câu 4 : R -> Tính tổng tiền lương phải trả cho nhân viên chính thức");
double fe_sum_salary = fe_list.Sum(e => e.calSalary());
Console.WriteLine("Tổng lương phải trả cho nhân viên chính thức là: " + fe_sum_salary);

//Câu 5: Tổng lương nhân viên thời vụ 
Console.WriteLine("câu 5 : R -> Tính tổng tiền lương phải trả cho nhân viên thời vụ");
double pe_sum_salary = employees.OfType<ParttimeEmployee>().Sum(e => e.calSalary());
Console.WriteLine("Tổng lương phải trả cho nhân viên thời vụ là: " + pe_sum_salary);

//Bài tập về nhà
//Bổ sung thêm các tính năng xoá và sửa dữ liệu 

//Câu 6: Xoá nhân viên theo id
//Xoá nhân viên full time theo id
Console.WriteLine("câu 6 : D -> Xoá nhân viên full time theo id");
Console.Write("Nhập id nhân viên full time cần xoá: ");
int fe_id = int.Parse(Console.ReadLine() ?? "0");
FulltimeEmployee? fe_to_remove = fe_list.OfType<FulltimeEmployee>().FirstOrDefault(e => e.id == fe_id);
if (fe_to_remove != null)
{
    fe_list.Remove(fe_to_remove);
    Console.WriteLine("Đã xoá nhân viên full time có id: " + fe_id);
}
else
{
    Console.WriteLine("Không tìm thấy nhân viên full time có id: " + fe_id);
}
Console.WriteLine("Danh sách nhân viên full time sau khi xoá:");
foreach (FulltimeEmployee fe in fe_list)
{
    Console.WriteLine(fe);
}
//xoá nhân viên part time theo id 
Console.WriteLine("câu 6 : D -> Xoá nhân viên part time theo id");
Console.Write("Nhập id nhân viên part time cần xoá: ");
int pe_id = int.Parse(Console.ReadLine() ?? "0");
ParttimeEmployee pe_to_remove;
List<ParttimeEmployee> pe_list = employees.OfType<ParttimeEmployee>().ToList();
foreach (ParttimeEmployee pe in pe_list)
{
    if (pe.id == pe_id)
    {
        pe_to_remove = pe;
        pe_list.Remove(pe_to_remove);
        Console.WriteLine("Đã xoá nhân viên part time có id: " + pe_id);
        break;
    }
}
Console.WriteLine("Danh sách nhân viên part time sau khi xoá:");
foreach (ParttimeEmployee pe in pe_list)
{
    Console.WriteLine(pe);
}
//Bài 7 Sửa dữ liệu nhân viên theo id
Console.WriteLine("câu 7 : U -> Sửa dữ liệu nhân viên theo id");
Console.Write("Nhập id nhân viên cần sửa: ");
Console.WriteLine("Nhập id nhân viên cần sửa: ");
int id_to_update = int.Parse(Console.ReadLine() ?? "0");

foreach (Employee emp in employees)
{
    if (emp.id == id_to_update)
    {
        Console.Write("Nhập id mới: ");
        emp.id = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhập idCard mới: ");
        emp.idCard = Console.ReadLine() ?? emp.idCard;
        Console.Write("Nhập tên mới: ");
        emp.name = Console.ReadLine() ?? emp.name;
        Console.Write("Nhập ngày sinh mới (dd/MM/yyyy): ");
        string birthdayInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(birthdayInput))
        {
            emp.birthday = DateTime.ParseExact(birthdayInput, "dd/MM/yyyy", null);
        }

        Console.WriteLine("Đã sửa dữ liệu nhân viên có id: " + emp.id);
        break;
    }
}
foreach (Employee pe in employees)
{
    Console.WriteLine(pe);
}

