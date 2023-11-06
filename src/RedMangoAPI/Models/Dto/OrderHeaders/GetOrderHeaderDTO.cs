namespace RedMangoAPI.Models.Dto.OrderHeaders
{
    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Services.Mapper.Interfaces;

    public class GetOrderHeaderDTO : IMapFrom<OrderHeader>
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
    }
}
