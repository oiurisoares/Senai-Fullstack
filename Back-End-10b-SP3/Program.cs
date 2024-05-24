namespace Back_End_10b_SP3;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.UseStaticFiles();
        app.MapGet("/index", (HttpContext contexto) =>
        {
            contexto.Response.Redirect("index.html", false);
        });

        Banco dba = new Banco();
        app.MapGet("/ClientList", (HttpContext contexto) =>
        {
            contexto.Response.WriteAsync(dba.GetListaString());
        });

        app.Run();
    }
}
