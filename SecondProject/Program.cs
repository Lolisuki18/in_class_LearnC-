//1 lớp có quy mô rất lớn có thể tách lớp đó thành nhiều tập tin khác nhau -> phải khai báo là file bat
using System.Text;

namespace SecondProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // cho mình bấm tiếng Việt có dấu
            Console.WriteLine("Minh hoạ lấy giá trị từ " +
                "outside arguments");
            //Console.WriteLine("Nhập vào các số nguyên cách nhau bởi dấu phẩy: ") ;
            //Console.WriteLine("Ví dụ: 1,2,3,4,5,6,7,8,9,10");
           
            if (args.Length > 0) //args là 1 mảng -> nó chạy theo kích cỡ mà bên ngoài truyền vào
            {
                int sum = 0;
                for (int i = 0; i < args.Length; i++)
                {
                    int item = int.Parse(args[i]); //args[i] là kiểu string -> phải chuyển về int
                    sum += item; //sum = sum + item
                    Console.WriteLine(item);
                }
                Console.WriteLine("=> SUM = {0} " + sum);
            }
            Console.ReadLine(); //dừng
        }
        
    }
}