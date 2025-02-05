using BloodDonation.Models; // Import the Models namespace to access the DonationDBContext
using Microsoft.EntityFrameworkCore; // Import Entity Framework Core for database operations

var builder = WebApplication.CreateBuilder(args); // Create a new web application instance

// ✅ Configure SQLite Database and Dependency Injection (DI)
// - This sets up the database connection using SQLite
// - Uses the connection string from `appsettings.json`
builder.Services.AddDbContext<DonationDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DevConnection"))); // Get the connection string from appsettings.json

// ✅ Register controllers in the Dependency Injection (DI) container
// - This allows controllers to be used in the API
builder.Services.AddControllers();

var app = builder.Build(); // Build the application (prepare it for execution)

// ✅ Enable HTTPS redirection
// - Forces HTTP requests to be redirected to HTTPS for security
app.UseHttpsRedirection();

// ✅ Map Controllers
// - This enables API endpoint routing, so requests are correctly handled
app.MapControllers();

app.Run(); // ✅ Start the application and begin listening for requests