using System.Text;

Console.OutputEncoding =Encoding.UTF8; // cho mình bấm tiếng Việt có dấu
Console.WriteLine("Xin chào các bạn!");//xuất ra màn hình
Console.WriteLine("Tôi là SE1848");

Console.ForegroundColor = ConsoleColor.Red; // đổi màu chữ

Console.WriteLine("Tôi hứa sẽ học nghiêm túc");
Console.ForegroundColor = ConsoleColor.Yellow; // đổi màu chữ
Console.BackgroundColor = ConsoleColor.Green; //đổi màu nền từ trên xuống dưới

Console.WriteLine("Tôi hứa là tôi sẽ làm được");
Console.ResetColor(); //đặt lại màu chữ và màu nền về mặc định      

Console.ReadLine();