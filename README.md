# Referral Management
The ReferralManagement project is a software solution aimed at managing referrals within an organization or system. The project is designed with a focus on robustness and scalability, and it's primarily built using C#, HTML, CSS, and JavaScript.

## Project Structure
The project is divided into two main components:

### ReferralAPI (MinimalAPI)
This is a minimalAPI that acts as the backend of the project, providing an interface for managing and processing referral information. It includes functionalities related to referral generation, tracking, and assignment.
### ReferralManagement (Razor Pages)
This is a razor pages project that is responsible for referral management tasks. 






## Building the Solution
To compile all projects run:
```
dotnet build ReferralManagement.sln
```
This requires the [.NET 7 SDK](https://dotnet.microsoft.com/download).

## Applying Database Migrations
The API uses Entity Framework Core with migrations stored in `ReferralAPI/Migrations`.
Run the following commands inside the `ReferralAPI` directory:
```
cd ReferralAPI
# ensure the EF Core tools are available
dotnet tool restore
dotnet ef database update
cd ..
```
This creates the SQLite database defined in `appsettings.json`.

## Running the Applications
Start the API and Razor Pages apps in separate terminals.

**Run the API**
```
dotnet run --project ReferralAPI/ReferralAPI.csproj
```
By default it listens on `https://localhost:7227`.

**Run the Razor Pages app**
```
dotnet run --project ReferralManagement/ReferralManagement.csproj
```
This application expects the API to be running and will open on `https://localhost:7203`.
