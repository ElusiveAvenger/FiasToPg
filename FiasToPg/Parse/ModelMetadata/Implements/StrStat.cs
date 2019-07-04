using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class StrStat : BaseModelDescription<StrStat, StructureStatuses.StructureStatusRow, StructureStatuses>
    {
        public StrStat() : base(new []{ nameof(StructureStatuses.StructureStatusRow.STRSTATID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class StructureStatuses
    {
        public partial class StructureStatusRow
        {
            public StructureStatusRow() : base(null)
            {
            }
        }

    }
}
