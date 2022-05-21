namespace SA_lab1._1
{
    sealed class Grant
    {
        private static Grant instance;
        private Grant() { }

        public static Grant GetInstance()
        {
            if (instance == null)
            {
                instance = new Grant();
            }

            return instance;
        }
    }
}
