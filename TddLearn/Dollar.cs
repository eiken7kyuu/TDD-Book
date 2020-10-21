namespace TddLearn
{
    public class Dollar
    {
        public int Amount { get; set; }

        public Dollar(int amount)
        {
            Amount = amount;
        }

        public Dollar Times(int multiplier)
        {
            return new Dollar(Amount * multiplier);
        }

        public override bool Equals(object obj)
        {
            var dollar = (Dollar)obj;
            return Amount == dollar.Amount;
        }
    }
}