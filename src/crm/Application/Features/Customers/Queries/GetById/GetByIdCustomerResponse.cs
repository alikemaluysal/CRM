using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Customers.Queries.GetById;

public class GetByIdCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? IdentityNumber { get; set; }
    public Guid? GenderId { get; set; }
    public Guid? TitleId { get; set; }
    public string? CompanyName { get; set; }
    public Guid? StatusTypeId { get; set; }
    public CustomerTypeEnum CustomerType { get; set; }
    public Guid? RegionId { get; set; }
    public DateTime BirthDate { get; set; }
}