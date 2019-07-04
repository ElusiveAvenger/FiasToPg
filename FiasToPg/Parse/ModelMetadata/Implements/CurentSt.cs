using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class CurentSt : BaseModelDescription<CurentSt, CurrentStatuses.CurrentStatusRow, CurrentStatuses>
    {
        public CurentSt() : base(new []{ nameof(CurrentStatuses.CurrentStatusRow.CURENTSTID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class CurrentStatuses
    {
        public partial class CurrentStatusRow
        {
            public CurrentStatusRow() : base(null) { }
        }
    }
}