using OOP2;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

FulltimeEmployee obama = new FulltimeEmployee();
obama.id = 1;
obama.idCard = "123456789";
obama.name = "Barack Obama";
obama.birthday = new DateTime(1961, 8, 4);
Console.WriteLine("Thông tin của Obama");
Console.WriteLine("ID = " + obama.id);
Console.WriteLine("ID Card = " + obama.idCard);
Console.WriteLine("Name = " + obama.name);
Console.WriteLine("Birthday = " + obama.birthday.ToString("dd/MM/yyyy"));

Console.WriteLine("Lương của Obama => " + obama.calSalary());


ParttimeEmployee trump = new ParttimeEmployee()
{
    id = 2,
    idCard = "987654321",
    name = "Donald Trump",
    birthday = new DateTime(1945, 1, 15),
    workingHours = 2// Số giờ làm việc
};
Console.WriteLine("Thông tin của Trump");
Console.WriteLine("ID = " + trump.id);
Console.WriteLine("ID Card = " + trump.idCard);
Console.WriteLine("Name = " + trump.name);
Console.WriteLine("Birthday = " + trump.birthday.ToString("dd/MM/yyyy"));
Console.WriteLine("Lương của Trump => " + trump.calSalary());


Console.WriteLine("---Thông tin cách 2 của nhân sự---");
Console.WriteLine(obama.ToString());
Console.WriteLine(trump.ToString());    