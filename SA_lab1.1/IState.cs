namespace SA_lab1._1
{
    interface IState
    {
        void ToProcessingState(Order order);

        Grant ToConfirmedState(Order order);

        void ToRejectedState(Order order);

        void ToCanceledState(Order order);
    }
}
