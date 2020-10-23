namespace TddLearn
{
    public class Money
    {
        protected internal int amount { get; set; }

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return amount == money.amount;
        }
    }
}