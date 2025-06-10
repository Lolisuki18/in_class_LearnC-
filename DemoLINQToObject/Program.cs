using System.Text;

Console.OutputEncoding = Encoding.UTF8;
int[] arr = {100,50,120,130,80,70,123,17,237};
/*
 *Câu 1: Dùng LINQ to Object để lọc ra các số chẳn:
 */
//Cách method SynTax
var result = arr.Where(x => x % 2 == 0);
//Cách Query SynTax
var result2 = from x in arr
              where x % 2 == 0
              select x;

Console.WriteLine("Danh sách các số chẵn");
foreach (var item in result2)
{
    Console.WriteLine(item);
}

/*Câu 2 : Sắp xếp theo danh sách tăng dần
 */
//method syntax
var result3 = arr.OrderBy(x => x);
//query
var result4 = from x in arr
              orderby x
              select x;

Console.WriteLine("Danh sách các số sau khi sắp xếp tăng dần");
foreach (var item in result4)
{
    Console.WriteLine(item);
}
/*
 Câu 3 : sắp xếp danh sách giảm dần
 */

//Cách method
var result5 = arr.OrderByDescending(x => x);
//cách query
var result6 = from x in arr
              orderby x descending
              select x;

Console.WriteLine("Danh sách các số sau khi sắp xếp giảm dần");
foreach (var item in result6)
{
    Console.WriteLine(item);
}
//Câu 4 : Đếm số lượng các số lẻ

int dem = arr.Where(x => x%2 != 0).Count();
Console.WriteLine("Số lượng các số lẻ là : " + dem);