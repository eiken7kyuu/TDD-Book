namespace TddLearn
{
    public class Pair
    {
        private string _from;
        private string _to;

        public Pair(string from, string to)
        {
            _from = from;
            _to = to;
        }

        public override bool Equals(object obj)
        {
            Pair pair = (Pair)obj;
            return _from == pair._from && _to == pair._to;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}