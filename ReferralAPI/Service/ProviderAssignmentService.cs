using Microsoft.EntityFrameworkCore;
using ReferralAPI.Data;

namespace ReferralAPI.Service
{
    public class ProviderAssignmentService : IProviderAssignmentService
    {
        private readonly ReferralAPIContext _db;

        public ProviderAssignmentService(ReferralAPIContext db)
        {
            _db = db;
        }

        public async Task<int> GetProviderWithFewestReferrals(int specialtyId)
        {
            var providers = _db.Provider.Where(p => p.SpecialtyId == specialtyId);

            // Count the number of referrals for each provider
            var referralCounts = await providers.Select(p => new
            {
                Provider = p,
                ReferralCount = _db.Referral.Count(r => r.ProviderId == p.ProviderId)
            }).ToListAsync();

            // Find the provider with the fewest referrals
            var providerWithFewestReferrals = referralCounts.OrderBy(rc => rc.ReferralCount).First().Provider;

            return providerWithFewestReferrals.ProviderId;
        }
    }

}
