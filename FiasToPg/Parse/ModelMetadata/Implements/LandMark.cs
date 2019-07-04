using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class LandMark : BaseModelDescription<LandMark, Landmarks.LandmarkRow, Landmarks>
    {
        public LandMark() : base(new []{ nameof(Landmarks.LandmarkRow.LANDID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class Landmarks
    {
        public partial class LandmarkRow
        {
            public LandmarkRow() : base(null) { }
        }
    }
}
