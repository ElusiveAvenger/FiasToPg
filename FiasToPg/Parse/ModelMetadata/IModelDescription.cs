using System;
using System.Data;

namespace FiasToPg.Parse.ModelMetadata
{
    public interface IModelDescription
    {
        Type Type { get; }

        Type DataSetType { get; }

        string Table { get; }

        string[] PrimaryKey { get; }

        DataSet BuildDataSet();
    }
}
