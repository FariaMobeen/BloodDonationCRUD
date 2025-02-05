//psas what kind of db we'll use, sql, etc
// and connection detials for db 
//pass tables we want to see in the db
// need to inherit the table we set up (DCandidate)

using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Models
{
    public class DonationDBContext:DbContext{  //Inherits from Microsoft.EntityFrameworkCore.DbContext

        //ctor
        //DbContext is the bridge between your C# application and the database
        // 
        public DonationDBContext(DbContextOptions<DonationDBContext> options):base(options)
        {

        }
        
        //creating property of our table type 
        // ✅ Defines a table in the database named DCandidates based on the DCandidate model.
        // ✅ Each row in this table represents an instance of DCandidate.
        // ✅ Entity Framework will map the DCandidate class to a database table.
        public DbSet<DCandidate> DCandidates {get; set;}
    }
}