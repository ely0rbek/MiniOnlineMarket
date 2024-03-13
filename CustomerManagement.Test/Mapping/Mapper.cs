using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Test.Mapping
{
    public static class Mapper
    {
        public static ToEntity Map<ToEntity>(this object FromEntity) where ToEntity : class
        {
            var returnEntity = Activator.CreateInstance<ToEntity>();
            var typeReturnEntity = returnEntity.GetType();
            var typeEntity = FromEntity.GetType();

            var properties = typeReturnEntity.GetProperties();
            foreach (var property in properties)
            {
                var fromEntityProperty = typeEntity.GetProperty(property.Name);
                if (fromEntityProperty != null)
                    property.SetValue(returnEntity, fromEntityProperty.GetValue(FromEntity));
            }

            return (ToEntity)returnEntity;
        }
    }
}
