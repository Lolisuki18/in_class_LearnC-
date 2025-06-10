using DemoLINQToObjectModelClass;
using System.Text;

Console.OutputEncoding = Encoding.UTF8; 

ListProduct lp = new ListProduct();
lp.gen_products();

/*
 * Câu 1
 -Lọc ra các sản phẩm có giá từ a - b
 */
// Cách 1: Sử dụng LINQ query syntax
Console.WriteLine("Các sản phẩm có giá từ 1000 -> 2000");
var result = lp.FilterProductByPrice(1000, 2000);
result.ForEach(p => Console.WriteLine(p.ToString()));
Console.WriteLine("===========================================");
// Cách 2: Sử dụng LINQ với phương thức mở rộng method syntax
Console.WriteLine("Các sản phẩm có giá từ 1000 -> 2000");
var result2 = lp.FilterProductByPrice2(1000, 2000);
result.ForEach(p => Console.WriteLine(p.ToString()));

/*
 Câu 2 : Sắp xếp sản phẩm theo đơn giá tăng dần
 */
Console.WriteLine("===========================================");
var result3 = lp.SortProductByPriceAsc2();
Console.WriteLine("Các sản phẩm sắp xếp theo đơn giá tăng dần");
result3.ForEach(p => Console.WriteLine(p.ToString()));

/*
 Câu 3 : Sắp xếp sản phẩm theo đơn giá giảm dần
 */
Console.WriteLine("===========================================");
var result4 = lp.SortProductByPriceDes2();
Console.WriteLine("Các sản phẩm sắp xếp theo đơn giá giảm dần");
result4.ForEach(p => Console.WriteLine(p.ToString()));

/*
Câu 4 : Tính tổng giá trị các sản phẩm trong kho hàng
 */
var result5 = lp.SumOfValue();
Console.WriteLine("===========================================");
Console.WriteLine($"Tổng giá trị các sản phẩm trong kho hàng là: {result5}");

/*
 Câu 5 : Tìm chi tiết sản phẩm khi biết mã sản phẩm
 */
Product p = lp.ProductById(11);
Console.WriteLine("===========================================");
if(p != null)
{
    Console.WriteLine($"Chi tiết sản phẩm có mã 11 là: {p.ToString()}");
}
else
{
    Console.WriteLine("Không tìm thấy sản phẩm có mã 11");
}

/*
 Câu 6: Viết hàm lọc ra TOP N sản phẩm có trị giá lớn nhất
 */

Console.WriteLine("===========================================");
var result6= lp.TopNProduct(3);
Console.WriteLine("Danh sách các sản phẩm có trị giá lớn nhất là:");
foreach (var item in result6)
{
    Console.WriteLine(item);
}

