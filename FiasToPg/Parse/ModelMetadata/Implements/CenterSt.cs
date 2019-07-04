using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class CenterSt : BaseModelDescription<CenterSt, CenterStatuses.CenterStatusRow, CenterStatuses>
    {
        public CenterSt() : base(new []{ nameof(CenterStatuses.CenterStatusRow.CENTERSTID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class CenterStatuses
    {
        public partial class CenterStatusRow
        {
            public CenterStatusRow() : base(null)
            {
            }
        }

    }
}
