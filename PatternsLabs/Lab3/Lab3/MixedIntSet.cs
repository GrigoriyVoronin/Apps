namespace Lab3
{
    public class MixedIntSet : TIntSet
    {
        public MixedIntSet()
        {
        }

        public MixedIntSet(int size)
            : base(size)
        {
        }

        public MixedIntSet(MixedIntSet mixedIntSet)
            : base(mixedIntSet)
        {
        }

        protected override string GetSetType()
        {
            return "Mixed";
        }

        public override bool IsValidNumber(int number)
        {
            return true;
        }
    }
}