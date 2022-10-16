using Appeal.Shared.Data.Concrete;
using Appeal.Shared.Entities.Abstract;
using Appeal.Services.Extensions;
using Appeal.Services.AutoMapper.Profiles;

var builder = WebApplication.CreateBuilder(args);


var sqlConnnection=builder.Configuration.GetSection("SqlConnection").Get<SQLConnection>();

builder.Services.AddSingleton(sqlConnnection);
builder.Services.LoadMyServices();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AppealProfile), typeof(FileProfile), typeof(OrganizationProfile));
builder.Services.AddControllers();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapControllerRoute("default", "api/{controller}/{action}/{id?}");
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
