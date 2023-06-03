using ReferralManagement.Model;

namespace ReferralManagement.Services
{
    public interface IDynamicReferralService
    {
        Task<List<DynamicReferral>> GetDynamicReferrals();
        Task<DynamicReferral> GetDynamicReferralById(int id);
        Task UpdateDynamicReferral(DynamicReferral dynamic);
        Task AddDynamicReferral(DynamicReferral dynamic);
    }
}
