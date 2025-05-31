using OOP6_Distionary;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Category c1 = new Category();
c1.Id = 1;
c1.Name = "Nuoc ngot";


Product p1 = new Product();
p1.Id = 1;
p1.Name = "pesi";
p1.Quantity = 13;
p1.Price = 32;
c1.AddProduct(p1);

Product p2 = new Product();
p2.Id = 2;
p2.Name = "bohuc";
p2.Quantity = 14;
p2.Price = 31;
c1.AddProduct(p2);


Product p3 = new Product();
p3.Id = 3;
p3.Name = "coca";
p3.Quantity = 15;
p3.Price = 37;
c1.AddProduct(p3);

Product p4 = new Product();
p4.Id = 4;
p4.Name = "sting";
p4.Quantity = 17;
p4.Price = 37;
c1.AddProduct(p4);

Product p5 = new Product();
p5.Id = 5;
p5.Name = "nuti";
p5.Quantity = 18;
p5.Price = 30;
c1.AddProduct(p5);


Console.WriteLine("-----Thong tin danh muc------");
Console.WriteLine(c1);
Console.WriteLine("-----Danh sach san pham-----");
c1.PrintAllProduct();


double min_price = 1;
double max_price = 50;
Dictionary<int, Product>product_by_price = c1.FilterProductsByPrice(min_price, max_price);
Console.WriteLine($"Danh sach san pham co gia tu{min_price} toi {max_price}");
foreach(KeyValuePair<int, Product> kvp in product_by_price)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

Dictionary<int, Product> Sorted_producs = c1.SortProductByPrice();
Console.WriteLine("-------------danh sach san pham sau khi sap xep gia tang dan-----------");
foreach (KeyValuePair<int, Product> kvp in Sorted_producs)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

Dictionary<int, Product> Sorted_complex_producs = c1.SortProductByPrice();
Console.WriteLine("-------------danh sach san pham sau khi sap xep Sorted_complex_producs-----------");
foreach (KeyValuePair<int, Product> kvp in Sorted_complex_producs)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

p5.Name = "Fanta";
p5.Price = 80;
p5.Quantity = 17;
bool ret = c1.UpdateProduct(p5);
Console.WriteLine("---san pham sau khi sua---");
c1.PrintAllProduct();



int id = 5;
ret = c1.RemoveProduct(id);
if(ret== false)
{
    Console.WriteLine($"khong tim thay ma {id} de xoa");
}
else
{
    Console.WriteLine($"da xoa thanh cong san pham co ma {id}");
}
    Console.WriteLine("------san pham sau khi xoa");
c1.PrintAllProduct();


double min = 1;
double max = 35;
int count = c1.RemoveProductsByPriceRange(min, max);

Console.WriteLine($"\nĐã xóa {count} sản phẩm có giá từ {min} đến {max}");
Console.WriteLine("--- Danh sách sản phẩm sau khi xóa theo khoảng giá ---");
c1.PrintAllProduct();


LinkedList<Category> categories = new LinkedList<Category>();
categories.AddLast(c1);
Category c2 = new Category();
c2.Id = 2;
c2.Name = "Bia cac loai";
c2.AddProduct(new Product() { Id = 6, Name = "Tiger", Quantity = 10, Price = 30 });
c2.AddProduct(new Product() { Id = 4, Name = "333", Quantity = 30, Price = 50 });
c2.AddProduct(new Product() { Id = 3, Name = "Ken", Quantity = 20, Price = 80 });


categories.AddLast(c2);
Console.WriteLine("----------Danh sach toan bo san pham theo muc-------");
foreach (Category c in categories)
{
    Console.WriteLine(c);
    Console.WriteLine("--------------");
    c.PrintAllProduct();
    Console.WriteLine("---------------");
}

