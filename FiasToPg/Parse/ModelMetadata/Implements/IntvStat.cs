using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class IntvStat : BaseModelDescription<IntvStat, IntervalStatuses.IntervalStatusRow, IntervalStatuses>
    {
        public IntvStat() : base(new []{ nameof(IntervalStatuses.IntervalStatusRow.INTVSTATID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class IntervalStatuses
    {
        public partial class IntervalStatusRow
        {
            public IntervalStatusRow() : base(null)
            {
            }
        }

    }
}
