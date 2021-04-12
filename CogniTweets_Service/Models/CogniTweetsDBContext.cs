using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CogniTweets_Service.Models
{
    public class CogniTweetsDBContext:DbContext
    {
        public CogniTweetsDBContext()
        {

        }

        public CogniTweetsDBContext(DbContextOptions<CogniTweetsDBContext> options) : base(options)
        {
           
        }

        public DbSet<CogniTweetsUser> Users { get; set; }
       
        public DbSet<Tweet> Tweets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Define connection string
            optionsBuilder.UseSqlServer(@"Server=Lab-63753539985;Database=CogniTweetsDB;Trusted_Connection=True;User ID=sa;Password=password-1");
        }
    }
}
