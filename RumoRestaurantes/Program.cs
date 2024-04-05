using Microsoft.EntityFrameworkCore;
using RumoRestaurantes.Context;

internal class Program
{
    private static void Main(string[] args)
    {
       // Mostrando a função 
        Console.WriteLine(PrintDescendingOrderRecursively(10));

        var builder = WebApplication.CreateBuilder(args);

        // CONEXÃO EM APPSETINGS.DEVELOPMENT.JSON
        builder.Services.AddDbContext<PedidoContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoRestaurante")));

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
           
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllerRoute(
            name: "pedidos",
            pattern: "pedidos",
            defaults: new { controller = "FuncionarioController", action = "Pedidos" });
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.Run();
    }

    // FUNÇÃO RECURSIVA
    static string PrintDescendingOrderRecursively(int n)
    {
        if (n == 0)
        {
            return "0";
        }
        else
        {
            return n.ToString() + PrintDescendingOrderRecursively(n - 1);
        }
    }

}