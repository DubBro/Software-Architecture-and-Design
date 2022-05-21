namespace SA_lab1._1
{
    class ProcessingState : IState
    {
        public Grant ToConfirmedState(Order order)
        {
            order.SetState(new ConfirmedState());
            return Grant.GetInstance();
        }

        public void ToProcessingState(Order order) { }

        public void ToRejectedState(Order order)
        {
            order.SetState(new RejectedState());
        }

        public void ToCanceledState(Order order)
        {
            order.SetState(new CanceledState());
        }
    }
}
