using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6_Distionary
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Product> Products { get; set; }

        public Category()
        {

            Products = new Dictionary<int, Product>();
        }
        public override string ToString()
        {
            return $"{Id}\t{Name}";
        }
        /*
         khi quản lí mọi đối tượng ta đều phải đáp ứng
          * đầy đủ tính năng CRUD
  
         */


        public void AddProduct(Product p)
        {
            //kiểm tra nếu id của product chưa tồn tại
            if (p == null)
            {
                return;//dữ liệu đầu vào null

            }
            if (Products.ContainsKey(p.Id))
            {
                return; //Id đã tồn tại thì ko thêm
            }

            //thêm mới product vào dictionary
            Products.Add(p.Id, p);
        }
        //xuất toàn bộ sản phẩm :
        public void PrintAllProduct()
        {
            foreach (KeyValuePair<int, Product> kvp in Products)
            {
                Product p = kvp.Value;
                Console.WriteLine(p);
            }
        }
        //loc cac san pham co gia tu min-->max
        public Dictionary<int, Product>
            FilterProductsByPrice(double min, double max)
        {
            return Products
                .Where(item => item.Value.Price >= min && item
                .Value.Price <= max).ToDictionary<int, Product>();
        }

        //sap xep san pham theo don gia tang dan
        public Dictionary<int, Product> SortProductByPrice()
        {
            return Products.OrderBy(item => item.Value.Price)
                           .ToDictionary<int, Product>();
        }
        //sap xep theo so luong dieu kien gia san pham
        public Dictionary<int, Product> SortComplex()
        {
            return Products
                .OrderByDescending(item => item.Value.Quantity)
                .OrderBy(item => item.Value.Price)
                .ToDictionary<int, Product>();
        }
        //update 


        public bool UpdateProduct(Product p)
        {
            if (p == null) { return false; } //nhap null sao ma sua
            if (Products.ContainsKey(p.Id)) { return false; } //khong thay sao ma sua

            //cap nhath gia tri tai o nho chua p.Id
            Products[p.Id] = p;
            return true;
        }
        //xoa
        public bool RemoveProduct(int id)
        {
            if (Products.ContainsKey(id) == false) { return false; } //ko tim thay id de xoa
            Products.Remove(id);
            return true;
        }
        //viet ham xoa cac san pham co don gia tu A toi B

        public int RemoveProductsByPriceRange(double min, double max)
        {
            var idsToRemove = Products
                .Where(p => p.Value.Price >= min && p.Value.Price <= max)
                .Select(p => p.Key)
                .ToList();

            foreach (var id in idsToRemove)
            {
                Products.Remove(id);
            }

            return idsToRemove.Count;
        }

    }
}