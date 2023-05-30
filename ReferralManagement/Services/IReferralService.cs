using ReferralManagement.Model;

namespace ReferralManagement.Services
{
    public interface IReferralService
    {
        Task<List<Referral>> GetReferrals();
        Task<Referral> GetReferralById(int id);
        Task AddReferral(Referral referral);
        Task UpdateReferral(Referral referral);
    }
}
