using JsonSubTypes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using wscad.BusinessLogic.Models;

namespace wscad.BusinessLogic.Services
{
    public class JsonFileLoader : IFileLoader
    {
        public async Task<List<Primitive>> LoadFileAsync(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                string json = await reader.ReadToEndAsync();

                var settings = new JsonSerializerSettings();
                settings.Converters.Add(JsonSubtypesConverterBuilder
                    .Of<Primitive>("Type")
                    .RegisterSubtype<Line>(nameof(Line).ToLower())
                    .RegisterSubtype<Circle>(nameof(Circle).ToLower())
                    .RegisterSubtype<Triangle>(nameof(Triangle).ToLower())
                    .SerializeDiscriminatorProperty()
                    .Build());

                return JsonConvert.DeserializeObject<List<Primitive>>(json, settings);
            }
        }
    }
}
