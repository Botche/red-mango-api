namespace RedMangoAPI.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.OpenApi.Models;

    using Swashbuckle.AspNetCore.SwaggerGen;

    using System.Text.Json.Serialization;

    public class IgnorePropertyFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription == null || operation.Parameters == null)
            {
                return;
            }

            if (!context.ApiDescription.ParameterDescriptions.Any())
            {
                return;
            }

            var excludedProperties = context.ApiDescription
                .ParameterDescriptions
                .Where(p => p.Source.Equals(BindingSource.Form)
                    || p.Source.Equals(BindingSource.Query));

            if (excludedProperties.Any())
            {
                foreach (var excludedProperty in excludedProperties)
                {
                    foreach (var customAttribute in excludedProperty.CustomAttributes())
                    {
                        if (customAttribute.GetType() == typeof(JsonIgnoreAttribute))
                        {
                            var countOfValues = operation.RequestBody.Content.Values.Count;
                            for (int i = 0; i < countOfValues; i++)
                            {
                                var value = operation.RequestBody.Content.Values.ElementAt(i);
                                var propertiesEncoding = value.Encoding;
                                var countOfElements = propertiesEncoding.Count;
                                for (int j = 0; j < countOfElements; j++)
                                {
                                    var propertyEncodingKey = propertiesEncoding
                                        .ElementAt(j)
                                        .Key;
                                    if (propertyEncodingKey == excludedProperty.Name)
                                    {
                                        propertiesEncoding
                                            .Remove(propertiesEncoding.ElementAt(j));
                                        value.Schema.Properties.Remove(excludedProperty.Name);
                                    }
                                }
                            }

                        }
                    }
                }
            }
        }
    }
}
