namespace Lab3
{
    public class NegativeIntSet : TIntSet
    {
        public NegativeIntSet()
        {
        }

        public NegativeIntSet(int size)
            : base(size)
        {
        }

        public NegativeIntSet(NegativeIntSet negativeIntSet)
            : base(negativeIntSet)
        {
        }

        protected override string GetSetType()
        {
            return "Negative";
        }

        public override bool IsValidNumber(int number)
        {
            return number < 0;
        }
    }
}