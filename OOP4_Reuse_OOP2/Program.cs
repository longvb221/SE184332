using OOP2;
using OOP4_Reuse_OOP2;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

FulltimeEmployee fe = new FulltimeEmployee();
fe.Id = 1;
fe.Name = "hehehe";
fe.IdCard = "3636";
fe.Birthday = new DateTime(2004, 12, 12);
Console.WriteLine("==>AGE = "+ fe.Tuoi());
if (fe.KiemTraSinhNhat() == true)
{
    Console.WriteLine("la sinh nhat");
}
else(fe.KiemTraSinhNhat() == false)
{
    Console.WriteLine("no");
}

