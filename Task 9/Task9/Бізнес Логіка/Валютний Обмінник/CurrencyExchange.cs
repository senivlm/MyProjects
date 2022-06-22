namespace Task9
{
    static class CurrencyExchange
    {
        private static Dictionary<Currencies, double> UAHtoOthers;

        static CurrencyExchange()
        {
            UAHtoOthers = new();
            UAHtoOthers[Currencies.UAH] = 1.00;
            UAHtoOthers[Currencies.USD] = 34.00;
            UAHtoOthers[Currencies.EURO] = 36.00;
        }

        public static void ChangeCurrencyExchange(double uSDtoUAH, double eUROtoUAH)
        {
            UAHtoOthers[Currencies.USD] = uSDtoUAH;
            UAHtoOthers[Currencies.EURO] = eUROtoUAH;
        }

        public static void ReadExchangeRateFromFile(string path)
        {
            using(var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    object? typeOfCurren;
                    double valueUah = 0.0;
                    double valueOther = 0.0;
                    var dataRate = sr.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (!double.TryParse(dataRate[0], out valueUah))
                    {
                        throw new FormatException();
                    }
                    if (!double.TryParse(dataRate[3], out valueOther))
                    {
                        throw new FormatException();
                    }
                    if (Enum.TryParse(typeof(Currencies), dataRate[1], out typeOfCurren))
                    {
                        double value = valueOther / valueUah;
                        UAHtoOthers[(Currencies)typeOfCurren] = value;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
            }
        }

        public static double ConvertCurrency(double value, Currencies fromCurrency, Currencies toCurrency)
        {
            double rate = UAHtoOthers[fromCurrency] / UAHtoOthers[toCurrency];
            return value * rate;
        }
    }
}