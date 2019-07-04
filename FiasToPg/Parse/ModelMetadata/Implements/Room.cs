using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class Room : BaseModelDescription<Room, Rooms.RoomRow, Rooms>
    {
        public Room() : base(new []{ nameof(Rooms.RoomRow.ROOMID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class Rooms
    {
        public partial class RoomRow
        {
            public RoomRow() : base(null)
            {
            }
        }

    }
}