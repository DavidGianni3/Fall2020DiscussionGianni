using System;
using System.Collections.Generic;
using System.Text;
using F2020DiscussionAppGianni.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace F2020DiscussionAppGianni.Data
{
    //add classes as properties in Application DbContext 
    //Before adding migrations 
    public class ApplicationDbContext : IdentityDbContext
    {   
        public DbSet<Pet> Pet { get; set; }

        public DbSet<VoucherRequest> VoucherRequest { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Client> Client { get; set; }

        public DbSet<Volunteer> Volunteer { get; set; }

        public DbSet<Fund> Fund { get; set; }

        public DbSet<FundCriteria> FundCriteria { get; set; }

        public DbSet<FundForVoucher> FundForVoucher { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
