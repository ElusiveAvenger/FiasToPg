using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class HstStat : BaseModelDescription<HstStat, HouseStateStatuses.HouseStateStatusRow, HouseStateStatuses>
    {
        public HstStat() : base(new []{ nameof(HouseStateStatuses.HouseStateStatusRow.HOUSESTID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class HouseStateStatuses
    {
        public partial class HouseStateStatusRow
        {
            public HouseStateStatusRow() : base(null)
            {
            }
        }

    }
}

