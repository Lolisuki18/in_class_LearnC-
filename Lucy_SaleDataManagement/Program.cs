using Lucy_SaleDataManagement;
using System.Text;

Console.OutputEncoding =Encoding.UTF8;

//khai báo chuỗi kết nối tới CSDL
string connectionString = @"server=ADMIN-PC\NINHLE;database=Lucy_SalesData;uid=sa;pwd=12345";
Lucy_SaleDataDataContext context = new Lucy_SaleDataDataContext(connectionString);
//Câu 1 : Lọc ra toàn bộ khách hàng
var dskh = context.Customers.ToList();
Console.WriteLine("------Danh sách Khách hàng-------");
foreach (var kh in dskh)
{
    Console.WriteLine($"Mã khách hàng: {kh.CustomerID}, Tên khách hàng: {kh.CompanyName}");
}

Console.WriteLine("------------------------------------------");
//Câu 2: Tìm chi tiết khách hàng khi biết mã khách hàng
int mkh = 10; 
Customer cust = context.Customers.FirstOrDefault(c => c.CustomerID == mkh);
if (cust == null)
{
    Console.WriteLine($"Không tìm thấy khách hàng có mã {mkh}");
}
else
{
    Console.WriteLine($"Thông tin khách hàng có mã {mkh}:");
    Console.WriteLine($"Mã khách hàng: {cust.CustomerID}, Tên khách hàng: {cust.CompanyName}");
}

//Caua 3: Từ kết quả của câu 2 , lấy ra các danh sách các hoá đơn của khách hàng 
//các cột dữ liệu gồm : Mã hoá đơn + Ngày hoá đơn
Console.WriteLine("------------------------------------------");

if(cust != null) {

//var dshd = context.Orders.Where(o => o.CustomerID == mkh).Select(o => new
//{
        //o.OrderID,
        //o.OrderDate
      //}); 
      var dshd = cust.Orders.Select(o => new
      {
          o.OrderID,
          o.OrderDate
      }).ToList(); //Lấy danh sách hoá đơn của khách hàng   
    var dshd2 = from od in cust.Orders
                 select new
                 {
                     od.OrderID,
                     od.OrderDate
                 };
    foreach (var o in dshd)
{
    Console.WriteLine($"Mã hoá đơn: {o.OrderID}, Ngày hoá đơn: {o.OrderDate}");
}
}
//Câu 4 :  từ kết quả của câu 3, bổ sung thêm trị giá của hoá đơn hơn chô mỗi hoá đơn 
Console.WriteLine("------------------------------------------");

if (cust != null) {
   var dshd10 = from od in cust.Orders
                join odt in context.Order_Details on od.OrderID equals odt.OrderID
                select new{
                    od.OrderID,
                    od.OrderDate,
                    Total = odt.UnitPrice * odt.Quantity *(1-(decimal)odt.Discount) //Tính trị giá của hoá đơn
                };
    foreach (var o in dshd10)
    {
        Console.WriteLine($"Mã hoá đơn: {o.OrderID}, Ngày hoá đơn: {o.OrderDate.ToString("dd/MM/yyyy")}, Trị giá: {o.Total}");

    }
}
Console.WriteLine("------------------------------------------");

if (cust != null) {
    var dshd11 = cust.Orders.SelectMany(od => od.Order_Details.Select(odt => new
    {
        od.OrderID,
        od.OrderDate,
        Total = odt.UnitPrice * odt.Quantity * (1 - (decimal)odt.Discount) //Tính trị giá của hoá đơn
    })).ToList();
    foreach (var o in dshd11)
    {
        Console.WriteLine($"Mã hoá đơn: {o.OrderID}, Ngày hoá đơn: {o.OrderDate.ToString("dd/MM/yyyy")}, Trị giá: {o.Total}");
    }
}