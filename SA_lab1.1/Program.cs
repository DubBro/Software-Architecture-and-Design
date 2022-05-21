namespace SA_lab1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(90);
            student.CreateOrder();
            student.ShowGrant();
            student.CancelOrder();
            student.ShowGrant();
        }
    }
}
