namespace PL.Presentation.Interfaces
{
    public interface IDeliveryController
    {
        void ShowMenu();
        void ShowMenuByCategory();
        void ShowMenuByDay();
        void ShowComplex();
        void CreateOrder();
        void CreateOrderComplex();
        void ShowOrders();
    }
}
