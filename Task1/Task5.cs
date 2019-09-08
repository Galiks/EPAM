namespace Task1
{
    public static class Task5
    {
        public static int GetSumOfNumbers()
        {
            int sumOfNumbers = 0;
            for (int i = 0; i < 1001; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sumOfNumbers += i;
                }
            }

            return sumOfNumbers;
        }
    }
}
