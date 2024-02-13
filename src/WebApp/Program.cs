using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.SQL;
using UseCases;
using UseCases.CategoriesUseCases;
using UseCases.AcadProgramsUseCases;

using UseCases.DataStorePluginInterfaces;
using UseCases.interfaces;
using Microsoft.AspNetCore.Identity;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EscolarisContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EscolarisMVC"));
});

builder.Services.AddDbContext<AccountContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentifyMVC"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AccountContext>();

// para que la App soporte Razor pages 
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Secretary", p => p.RequireClaim("Position", "Secretary"));
    options.AddPolicy("Register", p => p.RequireClaim("Position", "Register"));
});

//65. I have registered the repository interface  and its concrete implementation

builder.Services.AddTransient<ICategoryRepository, CategorySQLRepository>();
builder.Services.AddTransient<IAcadProgramRepository, AcadProgramSQLRepository>();
builder.Services.AddTransient<ITransactionRepository, TransactionSQLRepository>();

// Mapping Reposities and Use-Cases Intefaces

builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IViewSelectedCategoryUseCase, ViewSelectedCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();

builder.Services.AddTransient<IViewAcadProgramsUseCase, ViewAcadProgramsUseCase>();
builder.Services.AddTransient<IAddAcadProgramUseCase, AddAcadProgramUseCase>();
builder.Services.AddTransient<IEditAcadProgramUseCase, EditAcadProgramUseCase>();
builder.Services.AddTransient<IViewAcadProgramInCategoryUseCase, ViewAcadProgramInCategoryUseCase>();
builder.Services.AddTransient<IDeleteAcadProgramUseCase, DeleteAcadProgramUseCase>();
builder.Services.AddTransient<IViewSelectedAcadProgramUseCase, ViewSelectedAcadProgramUseCase>();
builder.Services.AddTransient<IEnrollProgramUseCase, EnrollProgramUseCase>();

builder.Services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
builder.Services.AddTransient<IGetTodayTransactionsUseCase, GetTodayTransactionsUseCase>();
builder.Services.AddTransient<ISearchTransactionsUseCase, SearchTransactionsUseCase>();

///////////

// Midleware Section

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

// add contidions of authentication and authorization
// Every web request that goes to the App it's going to 
// check the identify to know who is the user, and then it's to
// going to verify the user´s permission with the authorzation middlware.

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();