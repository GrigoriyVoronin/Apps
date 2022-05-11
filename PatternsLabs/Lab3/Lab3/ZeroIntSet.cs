namespace Lab3
{
    public class ZeroIntSet : TIntSet
    {
        public ZeroIntSet()
        {
        }

        public ZeroIntSet(int size)
            : base(size)
        {
        }

        public ZeroIntSet(ZeroIntSet zeroIntSet)
            : base(zeroIntSet)
        {
        }

        protected override string GetSetType()
        {
            return "Zero";
        }

        public override bool IsValidNumber(int number)
        {
            return number == 0;
        }
    }
}