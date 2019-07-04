using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class SocrBase : BaseModelDescription<SocrBase, AddressObjectTypes.AddressObjectTypeRow, AddressObjectTypes>
    {
        public SocrBase() : base(new []{ nameof(AddressObjectTypes.AddressObjectTypeRow.KOD_T_ST) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class AddressObjectTypes
    {
        public partial class AddressObjectTypeRow
        {
            public AddressObjectTypeRow() : base(null)
            {
            }
        }

    }
}
