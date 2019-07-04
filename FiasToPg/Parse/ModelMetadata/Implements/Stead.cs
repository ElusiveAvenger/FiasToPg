using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class Stead : BaseModelDescription<Stead, Steads.SteadRow, Steads>
    {
        public Stead() : base(new []{ nameof(Steads.SteadRow.STEADID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class Steads
    {
        public partial class SteadRow
        {
            public SteadRow() : base(null)
            {
            }
        }

    }
}
