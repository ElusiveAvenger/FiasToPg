using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class AddrObj : BaseModelDescription<AddrObj, AddressObjects.ObjectRow, AddressObjects>
    {
        public AddrObj() : base(new []{ nameof(AddressObjects.ObjectRow.AOID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class AddressObjects
    {
        public partial class ObjectRow
        {
            public ObjectRow() : base(null)
            {
            }
        }

    }
}
