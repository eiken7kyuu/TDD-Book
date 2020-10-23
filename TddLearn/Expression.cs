namespace TddLearn
{
    public interface Expression
    {
        Money Reduce(Bank bank, string to);
    }
}