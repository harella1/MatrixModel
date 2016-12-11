namespace DesignPatterns.Memento
{
    public class Selection
    {
        public Selection(int start, int length)
        {
            Length = length;
            Start = start;
        }

        public int Start { get; private set; }
        public int Length { get; private set; }

        public bool IsEmpty
        {
            get { return Start == Length; }
        }

        public bool Includes(int index)
        {
            return index >= Start && index < Start + Length;
        }

        public static Selection Empty
        {
            get { return new Selection(0, 0); }
        }

        protected bool Equals(Selection other)
        {
            return Start == other.Start && Length == other.Length;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Selection) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Start*397) ^ Length;
            }
        }
    }
}