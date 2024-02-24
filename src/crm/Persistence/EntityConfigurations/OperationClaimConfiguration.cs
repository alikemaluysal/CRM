using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Customers.Constants;
using Application.Features.Departments.Constants;
using Application.Features.Documents.Constants;
using Application.Features.DocumentTypes.Constants;
using Application.Features.Employees.Constants;
using Application.Features.Genders.Constants;
using Application.Features.Notifications.Constants;
using Application.Features.Offers.Constants;
using Application.Features.Regions.Constants;
using Application.Features.Requests.Constants;
using Application.Features.Sales.Constants;
using Application.Features.Settings.Constants;
using Application.Features.StatusTypes.Constants;
using Application.Features.TaskEntities.Constants;
using Application.Features.TaskStatuses.Constants;
using Application.Features.Titles.Constants;
using Application.Features.UserAddresses.Constants;
using Application.Features.UserEmails.Constants;
using Application.Features.UserPhones.Constants;
using Application.Features.RequestStatuses.Constants;
using Application.Features.OfferStatuses.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Customers
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CustomersOperationClaims.Admin },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Read },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Write },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Create },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Update },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Departments
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DepartmentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DepartmentsOperationClaims.Read },
                new() { Id = ++lastId, Name = DepartmentsOperationClaims.Write },
                new() { Id = ++lastId, Name = DepartmentsOperationClaims.Create },
                new() { Id = ++lastId, Name = DepartmentsOperationClaims.Update },
                new() { Id = ++lastId, Name = DepartmentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Documents
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DocumentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DocumentsOperationClaims.Read },
                new() { Id = ++lastId, Name = DocumentsOperationClaims.Write },
                new() { Id = ++lastId, Name = DocumentsOperationClaims.Create },
                new() { Id = ++lastId, Name = DocumentsOperationClaims.Update },
                new() { Id = ++lastId, Name = DocumentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DocumentTypes
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DocumentTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = DocumentTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = DocumentTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = DocumentTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = DocumentTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = DocumentTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Employees
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Admin },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Read },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Write },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Create },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Update },
                new() { Id = ++lastId, Name = EmployeesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Genders
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = GendersOperationClaims.Admin },
                new() { Id = ++lastId, Name = GendersOperationClaims.Read },
                new() { Id = ++lastId, Name = GendersOperationClaims.Write },
                new() { Id = ++lastId, Name = GendersOperationClaims.Create },
                new() { Id = ++lastId, Name = GendersOperationClaims.Update },
                new() { Id = ++lastId, Name = GendersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Notifications
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Genders
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = GendersOperationClaims.Admin },
                new() { Id = ++lastId, Name = GendersOperationClaims.Read },
                new() { Id = ++lastId, Name = GendersOperationClaims.Write },
                new() { Id = ++lastId, Name = GendersOperationClaims.Create },
                new() { Id = ++lastId, Name = GendersOperationClaims.Update },
                new() { Id = ++lastId, Name = GendersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Notifications
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Offers
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OffersOperationClaims.Admin },
                new() { Id = ++lastId, Name = OffersOperationClaims.Read },
                new() { Id = ++lastId, Name = OffersOperationClaims.Write },
                new() { Id = ++lastId, Name = OffersOperationClaims.Create },
                new() { Id = ++lastId, Name = OffersOperationClaims.Update },
                new() { Id = ++lastId, Name = OffersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region OfferStatus
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OfferStatusOperationClaims.Admin },
                new() { Id = ++lastId, Name = OfferStatusOperationClaims.Read },
                new() { Id = ++lastId, Name = OfferStatusOperationClaims.Write },
                new() { Id = ++lastId, Name = OfferStatusOperationClaims.Create },
                new() { Id = ++lastId, Name = OfferStatusOperationClaims.Update },
                new() { Id = ++lastId, Name = OfferStatusOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Regions
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = RegionsOperationClaims.Admin },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Read },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Write },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Create },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Update },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Requests
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = RequestsOperationClaims.Admin },
                new() { Id = ++lastId, Name = RequestsOperationClaims.Read },
                new() { Id = ++lastId, Name = RequestsOperationClaims.Write },
                new() { Id = ++lastId, Name = RequestsOperationClaims.Create },
                new() { Id = ++lastId, Name = RequestsOperationClaims.Update },
                new() { Id = ++lastId, Name = RequestsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region RequestStatus
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = RequestStatusOperationClaims.Admin },
                new() { Id = ++lastId, Name = RequestStatusOperationClaims.Read },
                new() { Id = ++lastId, Name = RequestStatusOperationClaims.Write },
                new() { Id = ++lastId, Name = RequestStatusOperationClaims.Create },
                new() { Id = ++lastId, Name = RequestStatusOperationClaims.Update },
                new() { Id = ++lastId, Name = RequestStatusOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Sales
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SalesOperationClaims.Admin },
                new() { Id = ++lastId, Name = SalesOperationClaims.Read },
                new() { Id = ++lastId, Name = SalesOperationClaims.Write },
                new() { Id = ++lastId, Name = SalesOperationClaims.Create },
                new() { Id = ++lastId, Name = SalesOperationClaims.Update },
                new() { Id = ++lastId, Name = SalesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Settings
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SettingsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Read },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Write },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Create },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Update },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Settings
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SettingsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Read },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Write },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Create },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Update },
                new() { Id = ++lastId, Name = SettingsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region StatusTypes
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StatusTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = StatusTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = StatusTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = StatusTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = StatusTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = StatusTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region TaskEntities
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TaskEntitiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = TaskEntitiesOperationClaims.Read },
                new() { Id = ++lastId, Name = TaskEntitiesOperationClaims.Write },
                new() { Id = ++lastId, Name = TaskEntitiesOperationClaims.Create },
                new() { Id = ++lastId, Name = TaskEntitiesOperationClaims.Update },
                new() { Id = ++lastId, Name = TaskEntitiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region TaskStatus
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TaskStatusOperationClaims.Admin },
                new() { Id = ++lastId, Name = TaskStatusOperationClaims.Read },
                new() { Id = ++lastId, Name = TaskStatusOperationClaims.Write },
                new() { Id = ++lastId, Name = TaskStatusOperationClaims.Create },
                new() { Id = ++lastId, Name = TaskStatusOperationClaims.Update },
                new() { Id = ++lastId, Name = TaskStatusOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Titles
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TitlesOperationClaims.Admin },
                new() { Id = ++lastId, Name = TitlesOperationClaims.Read },
                new() { Id = ++lastId, Name = TitlesOperationClaims.Write },
                new() { Id = ++lastId, Name = TitlesOperationClaims.Create },
                new() { Id = ++lastId, Name = TitlesOperationClaims.Update },
                new() { Id = ++lastId, Name = TitlesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region UserAddresses
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserAddressesOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserAddressesOperationClaims.Read },
                new() { Id = ++lastId, Name = UserAddressesOperationClaims.Write },
                new() { Id = ++lastId, Name = UserAddressesOperationClaims.Create },
                new() { Id = ++lastId, Name = UserAddressesOperationClaims.Update },
                new() { Id = ++lastId, Name = UserAddressesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region UserEmails
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserEmailsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserEmailsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserEmailsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserEmailsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserEmailsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserEmailsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region UserPhones
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserPhonesOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserPhonesOperationClaims.Read },
                new() { Id = ++lastId, Name = UserPhonesOperationClaims.Write },
                new() { Id = ++lastId, Name = UserPhonesOperationClaims.Create },
                new() { Id = ++lastId, Name = UserPhonesOperationClaims.Update },
                new() { Id = ++lastId, Name = UserPhonesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region UserPhones
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserPhonesOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserPhonesOperationClaims.Read },
                new() { Id = ++lastId, Name = UserPhonesOperationClaims.Write },
                new() { Id = ++lastId, Name = UserPhonesOperationClaims.Create },
                new() { Id = ++lastId, Name = UserPhonesOperationClaims.Update },
                new() { Id = ++lastId, Name = UserPhonesOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
