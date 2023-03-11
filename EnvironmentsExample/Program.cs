var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/config", async (context) =>
    {
       await context.Response.WriteAsync(app.Configuration["MyKey"]+"\n");

        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey2")+"\n");

        await context.Response.WriteAsync(app.Configuration.GetValue<int>("EmpID", 101)+"\n");
    });
});
app.MapControllers();

app.Run();
