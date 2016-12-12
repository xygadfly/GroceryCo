namespace GroceryCo.Discounts
{
    /// <summary>
    /// Interface that will be used by classed to implement the calculation
    /// </summary>
    public interface IDiscount
    {
        decimal Calculate(int qty);
    }
}