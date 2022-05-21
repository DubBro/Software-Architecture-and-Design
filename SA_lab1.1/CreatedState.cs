namespace SA_lab1._1
{
    class CreatedState : IState
    {
        public Grant ToConfirmedState(Order order)
        {
            return null;
        }

        public void ToProcessingState(Order order)
        {
            order.SetState(new ProcessingState());
        }

        public void ToRejectedState(Order order) { }

        public void ToCanceledState(Order order)
        {
            order.SetState(new CanceledState());
        }
    }
}
