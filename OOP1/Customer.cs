using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class Customer
    {
        //Cách viết POCO (Plain Old CLR Object) là viết các thuộc tính của lớp mà ko cần phải viết hàm khởi tạo, getter, setter
        //POCO là các lớp đơn giản, không có logic phức tạp, chỉ chứa các thuộc tính và phương thức đơn giản
        
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }   
        public string phone { get; set; }
        public string address { get; set; } //địa chỉ

        public void PrintInfor()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;//đổi màu nền
            Console.ForegroundColor = ConsoleColor.Blue;//đổi màu chữ
            //in thông tin
            Console.WriteLine($"Customer ID ={id}");
            Console.WriteLine($"Customer Name ={name}");
            Console.WriteLine($"Customer Email ={email}");
            Console.WriteLine($"Customer Phone ={phone}");
            Console.WriteLine($"Customer Addres = {address}");

            Console.BackgroundColor = ConsoleColor.Black;//đổi lại màu nền
            Console.ForegroundColor = ConsoleColor.White;//đổi lại màu chữ
        }
    }
}
