using Microsoft.EntityFrameworkCore;
using ReferralAPI.Data;
using ReferralAPI.Model;
using ReferralAPI.Service;

namespace ReferralAPI.Tests;

public class ProviderAssignmentServiceTests
{
    private ReferralAPIContext CreateContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<ReferralAPIContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;
        return new ReferralAPIContext(options);
    }

    [Fact]
    public async Task GetProviderWithFewestReferrals_ReturnsProviderWithLowestCount()
    {
        using var context = CreateContext(nameof(GetProviderWithFewestReferrals_ReturnsProviderWithLowestCount));

        // Arrange
        context.Specialty.Add(new Specialty { SpecialtyId = 1, SpecialtyName = "Cardiology" });
        context.Provider.AddRange(
            new Provider { ProviderId = 1, FirstName = "A", LastName = "One", SpecialtyId = 1 },
            new Provider { ProviderId = 2, FirstName = "B", LastName = "Two", SpecialtyId = 1 },
            new Provider { ProviderId = 3, FirstName = "C", LastName = "Three", SpecialtyId = 1 }
        );
        context.Referral.AddRange(
            new Referral { ReferralId = 1, PatientId = 1, ProviderId = 1, ReferralDate = DateTime.UtcNow, ReferralReason = "", SpecailtyId = 1, Status = "" },
            new Referral { ReferralId = 2, PatientId = 1, ProviderId = 1, ReferralDate = DateTime.UtcNow, ReferralReason = "", SpecailtyId = 1, Status = "" },
            new Referral { ReferralId = 3, PatientId = 1, ProviderId = 2, ReferralDate = DateTime.UtcNow, ReferralReason = "", SpecailtyId = 1, Status = "" }
        );
        await context.SaveChangesAsync();

        var service = new ProviderAssignmentService(context);

        // Act
        var result = await service.GetProviderWithFewestReferrals(1);

        // Assert
        Assert.Equal(3, result); // Provider 3 has zero referrals which is the fewest
    }

    [Fact]
    public async Task GetProviderWithFewestReferrals_Throws_WhenNoProviders()
    {
        using var context = CreateContext(nameof(GetProviderWithFewestReferrals_Throws_WhenNoProviders));
        var service = new ProviderAssignmentService(context);

        await Assert.ThrowsAsync<InvalidOperationException>(() => service.GetProviderWithFewestReferrals(99));
    }
}
