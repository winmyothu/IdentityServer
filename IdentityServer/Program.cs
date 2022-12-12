using IdentityServer;
using IdentityServerHost.Quickstart.UI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
        .AddDeveloperSigningCredential()        //This is for dev only scenarios when you don’t have a certificate to use.
        .AddInMemoryApiScopes(Config.ApiScopes)
        .AddInMemoryClients(Config.Clients)
        .AddTestUsers(TestUsers.Users);

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

var app = builder.Build();
app.UseStaticFiles();

app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});


app.Run();
