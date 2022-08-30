using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tests
{
    public class MetricBmiCalculatorTestsData : IEnumerable<object[]>
    {
        private const string jsonPath = "Data/MetricBmiCalculatorData.json";
        public IEnumerator<object[]> GetEnumerator()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var jsonFileFullPath = Path.GetRelativePath(currentDirectory, jsonPath);

            if (!File.Exists(jsonFileFullPath))
            {
                throw new ArgumentException($"couldn't find file: {jsonFileFullPath}");
            }

            var jsonData = File.ReadAllText(jsonFileFullPath);
            var allClasses = JsonConvert.DeserializeObject<IEnumerable<object[]>>(jsonData);
            return allClasses.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
