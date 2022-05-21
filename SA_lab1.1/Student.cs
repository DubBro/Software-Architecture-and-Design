using System;

namespace SA_lab1._1
{
    class Student
    {
        private int grade;
        private Grant grant = null;
        private Order order = null;

        public Student(int grade)
        {
            this.grade = grade;
        }

        public void CreateOrder()
        {
            this.order = new Order(this.grade);
            this.order.RequestForProcessing();
            this.grant = this.order.RequestForConfirming();
        }

        public void CancelOrder()
        {
            this.order.Cancel();
            this.grant = null;
        }

        public void ShowGrant()
        {
            if (this.grant != null)
            {
                Console.WriteLine("Student has a grant");
            }
            else
            {
                Console.WriteLine("Student has no grant");
            }
        }
    }
}
