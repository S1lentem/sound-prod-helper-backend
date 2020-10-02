using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Read.Entities;

namespace SoundProdHelper.DAL.Read.Configurations
{
    public class DataBaseConfigurations
    {
        public string DataBaseName { get; }
        public string ConnectionString { get; }
        public ReadOnlyDictionary<Type, string> CollectionNameMap { get; }

        public DataBaseConfigurations(string dataBaseName, string connectionString)
        {
            DataBaseName = dataBaseName;
            ConnectionString = connectionString;

            CollectionNameMap = new ReadOnlyDictionary<Type, string>(
                new Dictionary<Type, string>
                {
                    {typeof(User), "Users"},
                }
            );

            RegisterDomainModel<User>();
        }

        private static void RegisterDomainModel<T>()
            where T: EntityBase
        {
     
        }
    }
}