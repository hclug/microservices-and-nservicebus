using FireOnWheels.Messages;

namespace FireOnWheels.Order.Helper
{
    public static class PriceCalculator
    {
        public static int GetPrice(PriceRequest priceRequest)
        {
            return priceRequest.Weight < 10 ? 6 : 10;
        }
    }
}
