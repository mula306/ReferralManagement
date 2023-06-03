namespace ReferralAPI.Service
{
    public interface IProviderAssignmentService
    {
        Task<int> GetProviderWithFewestReferrals(int specialtyId);
    }
}
