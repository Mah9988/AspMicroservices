using Discount.Grpc.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountPortoService.DiscountPortoServiceClient _discountPortoServiceClient;

        public DiscountGrpcService(DiscountPortoService.DiscountPortoServiceClient discountPortoServiceClient)
        {
            _discountPortoServiceClient = discountPortoServiceClient ?? throw new ArgumentNullException(nameof(discountPortoServiceClient));
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = productName }; 

            return await _discountPortoServiceClient.GetDiscountAsync(discountRequest);
        }
    }
}
