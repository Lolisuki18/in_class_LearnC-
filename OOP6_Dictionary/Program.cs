using OOP6_Dictionary;
using System.Text;

Console.OutputEncoding =Encoding.UTF8;

Category c1 = new Category
{
    id = 1,
    name = "Nước ngọt",
    //products = new Dictionary<int, Product>()
};

Product p1 = new Product
{
    id = 1,
    name = "Pepsi",
    quantity = 10,
    price = 30000
};
c1.AddProduct(p1); 

Product p2 = new Product
{
    id = 2,
    name = "Coca Cola",
    quantity = 7,
    price = 25000
};
c1.AddProduct(p2);

Product p3 = new Product
{
    id = 3,
    name = "Sting",
    quantity = 12,
    price = 30000
};
c1.AddProduct(p3);

Product p4 = new Product
{
    id = 4,
    name = "Red bull",
    quantity = 15,
    price = 45000
};

c1.AddProduct(p4);

Product p5 = new Product
{
    id = 5,
    name = "Xá xị",
    quantity = 7,
    price = 20000
};

c1.AddProduct(p5);

Console.WriteLine("---Thông tin danh mục-----");
Console.WriteLine(c1);
Console.WriteLine("----------Danh sách các sản phẩm----------");
c1.PrintAllProducts();

double min_price = 27000;
double max_price = 30000;

Dictionary<int,Product>products_by_price = c1.FileterProductsByPrice(min_price, max_price);

Console.WriteLine($"Danh sách sản phẩm có giá trị từ {min_price} tới {max_price}");

foreach(KeyValuePair<int,Product> kvp in products_by_price)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

Dictionary<int, Product> sorter_products = c1.SortProductByPrice();
Console.WriteLine("-----Danh sách sản phẩm sau khi sắp xếp giá tăng dần:---------");
foreach (KeyValuePair<int, Product> kvp in sorter_products)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

Dictionary<int, Product> sorter_complex_products = c1.SortComplex();
Console.WriteLine("-----Sắp xếp sản phẩm theo đơn giá tăng dần Nếu đơn giá trùng nhau thì sắp xếp theo số lượng giảm dần---------");
foreach (KeyValuePair<int, Product> kvp in sorter_complex_products)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

p5.name = "Fanta";
p5.price = 80;
p5.quantity = 17;

bool ret = c1.UpdateProduct(p5);
Console.WriteLine("----Sản phẩm sau khi được chỉnh sửa là ----");
c1.PrintAllProducts();

int id = 5;
bool ret1 = c1.RemoveProduct(id);
if(ret1 == false)
    Console.WriteLine($"Không tìm thấy sản phẩm có mã {id}");
else
{
    Console.WriteLine($"Đã xoá thành công sản phẩm có mã {id}");
    Console.WriteLine("---Sản phẩm sau khi xoá-----:");
    c1.PrintAllProducts();
}
int minRage = 10000;

int maxRage = 25000;
Console.WriteLine("Viết hàm xoá nhiều sản phẩm có đơn giá từ a đến b");
Dictionary<int, Product> Remove_by_range_list = c1.RemoveProductByRange(minRage, maxRage);
Console.WriteLine("Hàm sau khi xoá là : ");
c1.PrintAllProducts();


LinkedList<Category> categories = new LinkedList<Category>(); // tạo 1 danh sách liên kết các Category
categories.AddLast(c1); // thêm c1 vào danh sách liên kết
Category c2 = new Category
{
    id = 2,
    name = "Bia",
    //products = new Dictionary<int, Product>()
};
c2.AddProduct(new Product { id = 6, name = "Tiger", quantity = 20, price = 50000 });
c2.AddProduct(new Product { id = 7, name = "Heineken", quantity = 15, price = 60000 });
c2.AddProduct(new Product { id = 8, name = "333", quantity = 10, price = 40000 });

categories.AddFirst(c2); // thêm c2 vào danh sách liên kết
Console.WriteLine("---- Danh sách toàn bộ sản phẩm theo danh mục hiện có -----");
foreach (Category category in categories)
{
    Console.WriteLine("-------------------------");
    Console.WriteLine($"Danh mục: {category.name}");
    category.PrintAllProducts();
    Console.WriteLine("-------------------------");
}