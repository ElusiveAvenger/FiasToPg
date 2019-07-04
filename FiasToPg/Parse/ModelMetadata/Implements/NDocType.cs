using FiasToPg.DataModels.AsDataSet;

namespace FiasToPg.Parse.ModelMetadata.Implements
{
    public class NDocType : BaseModelDescription<NDocType, NormativeDocumentTypes.NormativeDocumentTypeRow, NormativeDocumentTypes>
    {
        public NDocType() : base(new []{ nameof(NormativeDocumentTypes.NormativeDocumentTypeRow.NDTYPEID) })
        {
        }
    }
}

namespace FiasToPg.DataModels.AsDataSet
{
    public partial class NormativeDocumentTypes
    {
        public partial class NormativeDocumentTypeRow
        {
            public NormativeDocumentTypeRow() : base(null)
            {
            }
        }

    }
}
