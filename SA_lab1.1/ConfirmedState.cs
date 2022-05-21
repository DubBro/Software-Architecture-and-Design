namespace SA_lab1._1
{
    class ConfirmedState : IState
    {
        public Grant ToConfirmedState(Order order)
        {
            return Grant.GetInstance();
        }

        public void ToProcessingState(Order order) { }

        public void ToRejectedState(Order order) { }

        public void ToCanceledState(Order order)
        {
            order.SetState(new CanceledState());
        }
    }
}
