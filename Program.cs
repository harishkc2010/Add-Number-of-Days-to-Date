using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the date (dd/mm/yyyy): ");
            string inputDate = Console.ReadLine();
            Console.Write("Enter the number of days to add: ");
            int daysToAdd = int.Parse(Console.ReadLine());

            string[] dateParts = inputDate.Split('/');

            int day = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int year = int.Parse(dateParts[2]);

            AddDays(ref day, ref month, ref year, daysToAdd);

            Console.WriteLine($"New date: {day:D2}/{month:D2}/{year}");
        }

        static void AddDays(ref int day, ref int month, ref int year, int daysToAdd)
        {
            while (daysToAdd > 0)
            {
                int daysInCurrentMonth = GetDaysInMonth(month, year);

                if (day + daysToAdd <= daysInCurrentMonth)
                {
                    day += daysToAdd;
                    daysToAdd = 0;
                }
                else
                {
                    daysToAdd -= (daysInCurrentMonth - day + 1);
                    day = 1;

                    if (month == 12)
                    {
                        month = 1;
                        year++;
                    }
                    else
                    {
                        month++;
                    }
                }
            }
        }

        static int GetDaysInMonth(int month, int year)
        {
            int[] daysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (month == 2 && IsLeapYear(year))
            {
                return 29;
            }

            return daysInMonths[month - 1];
        }

        static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
    }
}
