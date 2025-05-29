
using OOP3_ExtensionMethod;
using System.Text;



Console.OutputEncoding = Encoding.UTF8;


int n1 = 5;
int n2 = 10;
Console.WriteLine($"tong tu 1 toi {n1} = {n1.TongTu1toiN()}");
Console.WriteLine($"tong tu 1 toi {n2} = {n2.TongTu1toiN()}");
Console.WriteLine($"tong tu 1 toi 8 = {+8.TongTu1toiN()}");
Console.WriteLine("8+7=" + 8.Tong(7));


int []M = new int[8];
M.TaoMang();
Console.WriteLine("bang sau khi tao ngau nhien");
M.XuatMang();
M.SapXepMangTangDan();
Console.WriteLine("bang sau khi xap xep tang dan");
M.XuatMang();
int[] M2 = M.SapXepMangGiamDan();
Console.WriteLine("bang sau khi xap xep giam dan");
M2.XuatMang();


