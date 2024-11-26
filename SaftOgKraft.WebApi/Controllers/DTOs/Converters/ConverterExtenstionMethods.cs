using System.Reflection;

namespace SaftOgKraft.WebApi.Controllers.DTOs.Converters;

public static class ConverterExtenstionMethods
{
    public static T CopyPropertiesTo<T>(this object sourceObject, T destinationObject)
    {
        if(destinationObject == null)
        {
            throw new ArgumentNullException(nameof(destinationObject));
        }
        foreach (PropertyInfo destinationProperty in destinationObject.GetType().GetProperties().Where(p => p.CanWrite))
        {
            if (!sourceObject.GetType().GetProperties().Any(sourceProp => sourceProp.Name == destinationProperty.Name && sourceProp.PropertyType == destinationProperty.PropertyType)) continue;
            var sourceProp = sourceObject.GetType().GetProperty(destinationProperty.Name);
            if (sourceProp != null) 
            {
                destinationProperty.SetValue(destinationObject, sourceProp.GetValue(sourceObject, null), null);  
            } else
            {
                throw new ArgumentNullException(nameof(sourceProp));
            }
        }

        return destinationObject;
    }
}
