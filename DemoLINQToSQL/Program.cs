using DemoLINQToSQL;
using System.Text;

Console.OutputEncoding =Encoding.UTF8;

//Khai báo chuỗi kết nối tới CSDL
string connectionString = @"server=ADMIN-PC\NINHLE;database=MyStore;uid=sa;pwd=12345";
MyStoreDataContext context = new MyStoreDataContext(connectionString);

//1.Truy vấn toàn bộ danh mục
var dsdm = context.Categories.ToList();
Console.WriteLine("------Danh sách Danh mục-------");
foreach (var dm in dsdm)
{
    Console.WriteLine($"Mã danh mục: {dm.CategoryID}, Tên danh mục: {dm.CategoryName}");
}


//2.Lấy thông tin chi tiết danh mục khi biết mã  
int madm = 7;
Category cate = context.Categories.FirstOrDefault(c => c.CategoryID == madm);
if (cate == null)
{
    Console.WriteLine($"Không tìm thấy danh mục có mã {madm}");
}
else
{
    Console.WriteLine($"Thông tin danh mục có mã {madm}:");
    Console.WriteLine($"Mã danh mục: {cate.CategoryID}, Tên danh mục: {cate.CategoryName}");
}

//3. Dùng query syntax để truy vấn toàn bộ sản phẩms
var dssp = from p in context.Products
            select p;
Console.WriteLine("-----Danh sách sản phẩm-------");

foreach (var item in dssp)
{
    Console.WriteLine($"Mã sản phẩm: {item.ProductID}, Tên sản phẩm: {item.ProductName}, Giá: {item.UnitPrice}, Số lượng: {item.UnitsInStock}");

}

//4. Dùng query SynTax và Anonymous type để lọc ra  các sản phẩm nhưng chỉ lấy mã sản phẩm và đơn giá 
//đồng thời sắp xếp giảm dần
//
var dssp4 = from p in context.Products
            orderby p.UnitPrice descending
            select new
            {
                p.ProductID,
                p.UnitPrice
            }; // Sử dụng anonymous type  để chỉ lấy mã sản phẩm và đơn giá 
//còn muốn lấy hết thì chỉ cần bỏ new { } đi

Console.WriteLine("-----Danh sách sản phẩm (chỉ lấy mã và đơn giá) câu 4-------");
foreach (var item in dssp4)
{
    Console.WriteLine($"Mã sản phẩm: {item.ProductID}, Đơn giá: {item.UnitPrice}");
}

//Câu 5 sửa câu 4 theo extention method ( method syntax)
var dssp5 = context.Products.OrderByDescending(p => p.UnitPrice)
                            .Select(p => new
                            {
                                p.ProductID,
                                p.UnitPrice
                            }); // Sử dụng anonymous type  để chỉ lấy mã sản phẩm và đơn giá

Console.WriteLine("-----Danh sách sản phẩm (chỉ lấy mã và đơn giá) câu 5-------");
foreach (var item in dssp5)
{
    Console.WriteLine($"Mã sản phẩm: {item.ProductID}, Đơn giá: {item.UnitPrice}");
}

//6.Lọc ra top 3 sản phẩm có giá lớn nhất hệ thống, yêu cầu dùng methodSyntax
var dssp6 = context.Products.OrderByDescending(p => p.UnitPrice).Take(3).Select(p => new
{
    p.ProductID,
    p.ProductName,
    p.UnitPrice
});

Console.WriteLine("------Top 3 sản phẩm có giá trị lớn nhất hệ thông - Câu 6");
foreach (var item in dssp6)
{
    Console.WriteLine($"Mã sản phẩm: {item.ProductID}, Tên sản phẩm: {item.ProductName} , Giá sản phẩm là : {item.UnitPrice}");
}

//Câu 7 : Sửa tên danh mục khi biết mã 
int madm_edit = 8; //Mã danh mục cần sửa
Category cate_edit = context.Categories.FirstOrDefault(c => c.CategoryID == madm_edit);
if (cate_edit != null)
{
    cate_edit.CategoryName = "Hàng cấm"; //Sửa tên danh mục
    context.SubmitChanges(); //Lưu thay đổi vào CSDL
    Console.WriteLine($"Đã sửa tên danh mục có mã {madm_edit} thành {cate_edit.CategoryName}");
}
else
{
    Console.WriteLine($"Không tìm thấy danh mục có mã {madm_edit} để sửa.");
}
Console.WriteLine("-------------------------------------------------");

//Câu 8: Xoá danh mục khi biết mã
int madm_xoa = 5; //Mã danh mục cần xoá

Category cate_remove = context.Categories.FirstOrDefault(c => c.CategoryID == madm_xoa);

if(cate_remove != null)
{
    context.Categories.DeleteOnSubmit(cate_remove);
    context.SubmitChanges();
}

//Câu 9 : Xoá các danh mục nếu ko có bất kỳ sản phẩm nào 
//lưu ý : là xoá cùng 1 lúc nhiều danh mục mà các danh mục này ko có chứa bất kỳ 1 sản phẩm nào

//lấy danh sách id các danh mục có trong product
//var dsdmInProduct = from p in context.Products
//select p.CategoryID;

//var dsdmInCategory = from c in context.Categories
//select c.CategoryID;

//var dsdmNotIn = from dm in context.Categories
//where 
//if(dsdmInCategory != null && dsdmInProduct != null)
//{

//}

var dsdm_empty_product = context.Categories.Where(c => c.Products.Count() == 0).ToList();
context.Categories.DeleteAllOnSubmit(dsdm_empty_product);
context.SubmitChanges();

//Câu 10: thêm mới 1 danh mục
Category c_new = new Category();
c_new.CategoryName = "Hàng buôn";
context.Categories.InsertOnSubmit(c_new);
context.SubmitChanges();

//câu 11: thêm mới nhiều danh mục
List<Category> list = new List<Category>();
list.Add(new Category() { CategoryName = "Hàng Gia Dụng" });
list.Add(new Category() { CategoryName = "Hàng Điện Tử" });
list.Add(new Category() { CategoryName = "Hàng Phụ Kiện" });

context.Categories.InsertAllOnSubmit(list);
context.SubmitChanges();

