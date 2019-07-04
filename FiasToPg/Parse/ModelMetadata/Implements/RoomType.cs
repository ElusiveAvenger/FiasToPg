using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class RoomType : BaseModelDescription<RoomType, RoomTypes.RoomTypeRow, RoomTypes>
    {
        public RoomType() : base(new []{ nameof(RoomTypes.RoomTypeRow.RMTYPEID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class RoomTypes
    {
        public partial class RoomTypeRow
        {
            public RoomTypeRow() : base(null)
            {
            }
        }
    }

}
