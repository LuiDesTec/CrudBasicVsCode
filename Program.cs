var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

app.MapGet("/ produto",(Product product) => new {Name = "ínicio"} 
    
);



app.Run();


public static class ProductRepository{
    public static List<Product> Products {get; set;}

    public static void AddProduct(Product product){
        if(Products == null){
            Products = new List<Product>();
            Products.Add(product);
            
        }
    }    
    public static Product GetByProduct(string code){
        return Products.First(p => p.Code == code);

    }

   

}


public class Product{
    public string Code { get; set; }
    public string Nome { get; set; }
}
