using System.Text;

Console.OutputEncoding = System.Text.Encoding.UTF8; // cho mình bấm tiếng Việt có dấu
String ho = "Nguyễn";
String tenlot = "Thị";
String ten = "Tủn";

string full_name = ho +" " + tenlot + " " + ten; //cách 1 // cứ 1 "+" là thêm 1 ô nhớ  -> dùng cái này tốn ô nhớ
Console.WriteLine(full_name);

StringBuilder sb = new StringBuilder(); //cách 2
sb.Append(ho); //thêm vào cuối chuỗi
sb.Append(" ");
sb.Append(tenlot);
sb.Append(" ");
sb.Append(ten);
Console.WriteLine(sb.ToString()); //chuyển về string để in
