namespace ReferralManagement.Model
{
    //public class DynamicReferralResponse
    //{
    //    public List<DynamicReferral> DynamicReferrals { get; set; }
    //}
    public class DynamicReferral
    {
        public int DynamicReferralId { get; set; }
        public string ReferralName { get; set; }
        public string ReferralJson { get; set; } // Why the patient was referred
    }
}
