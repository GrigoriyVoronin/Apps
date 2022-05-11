namespace Lab11
{
    public class Snapshot
    {
        public StudentsGroup GroupEma181 { get; }
        public StudentsGroup GroupEma182 { get; }

        public Snapshot(StudentsGroup groupEma181, StudentsGroup groupEma182)
        {
            GroupEma181 = groupEma181;
            GroupEma182 = groupEma182;
        }

        public Snapshot MakeSnapshot()
        {
            return new Snapshot(
                GroupEma181.Clone(),
                GroupEma182.Clone()
            );
        }
    }
}