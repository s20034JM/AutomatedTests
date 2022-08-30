using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace MyProject.Tests
{
    internal class JsonFileData : DataAttribute
    {
        private readonly string jsonPath;
        public JsonFileData(string jsonPath)
        {
            this.jsonPath = jsonPath;
        }
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            var currentDirectory = Directory.GetCurrentDirectory();
            var jsonFileFullPath = Path.GetRelativePath(currentDirectory, jsonPath);

            if (!File.Exists(jsonFileFullPath))
            {
                throw new ArgumentException($"couldn't find file: {jsonFileFullPath}");
            }

            var jsonData = File.ReadAllText(jsonFileFullPath);
            var allClasses = JsonConvert.DeserializeObject<IEnumerable<object[]>>(jsonData);
            return allClasses;
        }
    }
}
