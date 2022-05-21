using System;

namespace SA_lab1._1
{
    class Order
    {
        private IState state;
        private int grade;

        public Order(int grade)
        {
            this.state = new CreatedState();
            this.grade = grade;
            ShowState();
        }

        public void SetState(IState state)
        {
            this.state = state;
            ShowState();
        }

        public void RequestForProcessing()
        {
            this.state.ToProcessingState(this);
        }

        public Grant RequestForConfirming()
        {
            if (grade >= 90)
            {
                return this.state.ToConfirmedState(this);
            }
            else
            {
                this.state.ToRejectedState(this);
                return null;
            }
        }

        public void Cancel()
        {
            this.state.ToCanceledState(this);
        }

        public void ShowState()
        {
            Console.WriteLine($"Order is in {this.state.GetType().Name}");
        }
    }
}
