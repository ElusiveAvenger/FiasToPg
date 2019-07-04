using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class HouseInt : BaseModelDescription<HouseInt, HouseIntervals.HouseIntervalRow, HouseIntervals>
    {
        public HouseInt() : base(new []{ nameof(HouseIntervals.HouseIntervalRow.HOUSEINTID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class HouseIntervals
    {
        public partial class HouseIntervalRow
        {
            public HouseIntervalRow() : base(null) { }
        }
    }
}
