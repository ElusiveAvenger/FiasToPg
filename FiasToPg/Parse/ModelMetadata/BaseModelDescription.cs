using System;
using System.Data;

namespace FiasToPg.Parse.ModelMetadata
{
    public abstract class BaseModelDescription<TModel, TData, TDataSet> : IModelDescription
        where TModel : IModelDescription
        where TData : DataRow, new()
        where TDataSet : DataSet, new()
    {
        protected BaseModelDescription(string[] primaryKey)
        {
            PrimaryKey = primaryKey;
        }

        public Type Type => typeof(TData);

        public Type DataSetType => typeof(TDataSet);

        public string Table => typeof(TModel).Name.ToUpper();

        public string[] PrimaryKey { get; }

        public DataSet BuildDataSet() => new TDataSet();
    }
}
