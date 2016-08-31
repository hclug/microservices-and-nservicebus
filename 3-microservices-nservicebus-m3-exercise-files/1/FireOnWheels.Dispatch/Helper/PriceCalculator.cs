using FireOnWheels.Messages;

namespace FireOnWheels.Dispatch.Helper
{
    public static class PriceCalculator
    {
        public static int GetPrice(PriceRequest priceRequest)
        {
            return priceRequest.Weight < 10 ? 6 : 10;
        }
    }
}
