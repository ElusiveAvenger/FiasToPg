using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class ActStat : BaseModelDescription<ActStat, ActualStatuses.ActualStatusRow, ActualStatuses>
    {
        public ActStat() : base(new []{ nameof(ActualStatuses.ActualStatusRow.ACTSTATID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class ActualStatuses
    {
        public partial class ActualStatusRow
        {
            public ActualStatusRow() : base(null)
            {
            }
        }

    }
}
