using System;

namespace Task6_part_1
{
    public class FlatInfo
    {
        public readonly string OwnerName;
        public readonly int IncomingCounter;
        public readonly int OutPutCounter;
        public readonly int Number;
        public readonly DateTime Date;

        public FlatInfo(string name, int income, int output, DateTime date, int number)
        {
            OwnerName = name;
            IncomingCounter = income;
            OutPutCounter = output;
            Date = date;
            Number = number;
        }

        public override string ToString()
        {
            return string.Format("\tApartment number: {0},\v  \towner: {1},\v \tincoming counter value: {2},\v " +
                        " \toutput counter value: {3},\tdate: {4} \v \t",
                        Number, OwnerName, IncomingCounter, OutPutCounter, ConvertToFullData());
        }

        public string ConvertToFullData()
        {
            string fullData = Date.Day + " ";
            switch (Date.Month)
            {
                case 1:
                    fullData += "January ";
                    break;
                case 2:
                    fullData += "February ";
                    break;
                case 3:
                    fullData += "March ";
                    break;
                case 4:
                    fullData += "April ";
                    break;
                case 5:
                    fullData += "May ";
                    break;
                case 6:
                    fullData += "June ";
                    break;
                case 7:
                    fullData += "July ";
                    break;
                case 8:
                    fullData += "August ";
                    break;
                case 9:
                    fullData += "September ";
                    break;
                case 10:
                    fullData += "October ";
                    break;
                case 11:
                    fullData += "November ";
                    break;
                case 12:
                    fullData += "December ";
                    break;
            }
            fullData += Date.Year;
            return fullData;
        }
    }
}
