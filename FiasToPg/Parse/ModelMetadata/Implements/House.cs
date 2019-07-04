using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class House : BaseModelDescription<House, Houses.HouseRow, Houses>
    {
        public House() : base(new []{ nameof(Houses.HouseRow.HOUSEID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class Houses
    {
        public partial class HouseRow
        {
            public HouseRow() : base(null)
            {
            }
        }

    }
}

