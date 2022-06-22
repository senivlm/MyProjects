using System;

namespace Task6_part_1
{
    public class FlatInfoMonth
    {
        public readonly string PayerName;
        public readonly int IncomingCounter;
        public readonly DateTime Date;

        public FlatInfoMonth(string name, int income, DateTime date)
        {
            PayerName = name;
            IncomingCounter = income;
            Date = date;
        }

        public override string ToString()
        {
            return string.Format($"owner: {PayerName}, incoming counter value: {IncomingCounter}, " +
                        "  date: {ConvertToFullData()}");
        }
    }
}
