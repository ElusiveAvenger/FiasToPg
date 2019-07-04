using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class FlatType : BaseModelDescription<FlatType, FlatTypes.FlatTypeRow, FlatTypes>
    {
        public FlatType() : base(new []{ nameof(FlatTypes.FlatTypeRow.FLTYPEID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class FlatTypes
    {
        public partial class FlatTypeRow
        {
            public FlatTypeRow() : base(null)
            {
            }
        }

    }
}
