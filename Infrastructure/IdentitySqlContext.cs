using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class IdentitySqlContext : IdentityDbContext
    {
        public IdentitySqlContext(DbContextOptions<IdentitySqlContext> options) : base(options)
        {

        } 
    }
}
