using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class OperStat : BaseModelDescription<OperStat, OperationStatuses.OperationStatusRow, OperationStatuses>
    {
        public OperStat() : base(new []{ nameof(OperationStatuses.OperationStatusRow.OPERSTATID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class OperationStatuses
    {
        public partial class OperationStatusRow
        {
            public OperationStatusRow() : base(null)
            {
            }
        }

    }
}
