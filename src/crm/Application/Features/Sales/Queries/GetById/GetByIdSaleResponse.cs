using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sales.Queries.GetById;

public class GetByIdSaleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid RequestId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal SaleAmount { get; set; }
    public string Description { get; set; }
}