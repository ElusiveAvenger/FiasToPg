using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class NormDoc : BaseModelDescription<NormDoc, NormativeDocumentes.NormativeDocumentRow, NormativeDocumentes>
    {
        public NormDoc() : base(new []{ nameof(NormativeDocumentes.NormativeDocumentRow.NORMDOCID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class NormativeDocumentes
    {
        public partial class NormativeDocumentRow
        {
            public NormativeDocumentRow() : base(null)
            {
            }
        }

    }
}
