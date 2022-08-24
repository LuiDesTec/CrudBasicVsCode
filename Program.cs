using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/products", (Product product)=>{
    ProductRepository.AddProduct(product);
    return Results.Created("/products/" + product.Code, product.Code);
});


app.MapGet("/ products/{code}",([FromRoute] string code) => {
    var product = ProductRepository.GetByProduct(code);
      if(product != null)
      return Results.Ok(product);
    return Results.NotFound();
} );


app.MapPut("/products", (Product product)=>{
    var productSave = ProductRepository.GetByProduct(product.Code);
    productSave.Name = product.Name;
    return Results.Ok();
});

app.MapDelete("/products/{code}",([FromRoute] string code) =>{
     var productSave = ProductRepository.GetByProduct(code);
    ProductRepository.Remove(productSave);
    return Results.Ok();
});

app.Run();
public static class ProductRepository{
    public static List<Product> Products {get; set;} =new List<Product>();

    public static void AddProduct(Product product){
        if(Products == null){
           
            Products.Add(product);
            
        }
    }    
    public static Product GetByProduct(string code){
        return Products.First(p => p.Code == code);

    }

    public static void Remove(Product product){
        Products.Remove(product);
    }

}
public class Product{
    public string Code { get; set; }
    public string Name { get; set; }
}
