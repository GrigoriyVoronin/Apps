namespace Lab3
{
    public class PositiveIntSet : TIntSet
    {
        public PositiveIntSet()
        {
        }

        public PositiveIntSet(int size)
            : base(size)
        {
        }

        public PositiveIntSet(PositiveIntSet positiveIntSet)
            : base(positiveIntSet)
        {
        }

        protected override string GetSetType()
        {
            return "Positive";
        }

        public override bool IsValidNumber(int number)
        {
            return number > 0;
        }
    }
}