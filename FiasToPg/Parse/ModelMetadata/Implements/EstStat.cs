using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class EstStat : BaseModelDescription<EstStat, EstateStatuses.EstateStatusRow, EstateStatuses>
    {
        public EstStat() : base(new []{ nameof(EstateStatuses.EstateStatusRow.ESTSTATID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class EstateStatuses
    {
        public partial class EstateStatusRow
        {
            public EstateStatusRow() : base(null)
            {
            }
        }

    }
}
