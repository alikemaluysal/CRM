using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Sales.Queries.GetList;

public class GetListSaleListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid RequestId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal SaleAmount { get; set; }
    public string Description { get; set; }
}