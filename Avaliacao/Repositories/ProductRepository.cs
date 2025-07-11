using Avaliacao.Models;

namespace Avaliacao.Repositories;

public class ProductRepository
{
    public static List<Product> produtos = new List<Product>();
    public static int produtoID = 1;

    public static Product GetProduct(int productId)
    {
        var product = produtos.Find(p => p.Id == productId);
        return product;
    }

    public static void AddProduct(Product p)
    {
        p.Id = produtoID++;
        produtos.Add(p);
    }

    public static void RemoveProduct(int productId)
    {
        var product = GetProduct(productId);
        produtos.Remove(product);
    }

    public static void UpdateQuantity(int productId, int newQuantity)
    {
        int index = produtos.FindIndex(p=> p.Id == productId);
        produtos[index].Quantity = newQuantity;
    }

    public static void SellProduct(int productId, int amount)
    {
        int index = produtos.FindIndex(p => p.Id == productId);
        produtos[index].Quantity = produtos[index].Quantity - amount;
    }
}
