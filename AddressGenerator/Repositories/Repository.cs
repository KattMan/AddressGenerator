using AddressGeneratorInterfaces;
using System.Collections.Generic;
using System.Reflection;

namespace AddressGenerator.Repositories
{
    public class Repository : IRepository
    {
        public List<string> GetAdjectives()
        {
            return LoadList("Adjectives");
        }

        public List<string> GetNouns()
        {
            return LoadList("Nouns");
        }

        public List<string> GetStreetTypes()
        {
            return LoadList("StreetTypes");
        }

        public List<string> GetSubTypes()
        {
            return LoadList("SubAddress");
        }

        public List<string> GetZipCodeInfo()
        {
            return LoadList("ZipCodes");
        }

        private List<string> LoadList(string listToLoad)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var localNamespace = executingAssembly.GetName().Name;
            var resourceName = string.Format("{0}.Data.{1}.txt", localNamespace, listToLoad);
            var dataList = new List<string>();

            using (var stream = executingAssembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (var reader = new System.IO.StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            dataList.Add(reader.ReadLine());
                        }
                    }
                }
            }

            return dataList;

        }
    }
}
