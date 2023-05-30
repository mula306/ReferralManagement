using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReferralAPI.Model;

namespace ReferralAPI.Data
{
    public class ReferralAPIContext : DbContext
    {
        public ReferralAPIContext (DbContextOptions<ReferralAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ReferralAPI.Model.Patient> Patient { get; set; } = default!;

        public DbSet<ReferralAPI.Model.Referral> Referral { get; set; } = default!;

        public DbSet<ReferralAPI.Model.DynamicReferral> DynamicReferral { get; set; } = default!;

        public DbSet<ReferralAPI.Model.Provider> Provider { get; set; } = default!;

        public DbSet<ReferralAPI.Model.Specialty> Specialty { get; set; } = default!;
    }
}
