namespace SA_lab1._1
{
    class RejectedState : IState
    {
        public Grant ToConfirmedState(Order order)
        {
            return null;
        }

        public void ToProcessingState(Order order) { }

        public void ToRejectedState(Order order) { }

        public void ToCanceledState(Order order) { }
    }
}
