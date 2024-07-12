using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmSense4.Business
{
    internal class InitializeData
    {
        private List<Chemical_Combinations> _combinations { get; set; }
        private string docName;
        
        public InitializeData(String url) 
        {
            _combinations = new List<Chemical_Combinations>();
            docName = url;
        }

        public List<Chemical_Combinations> InitializeChemicalCombinations()
        {
            //../../
            //./src/PalmSense4/
            using (StreamReader r = new StreamReader(docName))
            {
                string json = r.ReadToEnd();
                JObject j = JObject.Parse(json);

                JArray commonGasesAndLiquitsArray = j["Common Gases and Liquits"] as JArray;
                JArray saltsArray = j["Salts"] as JArray;
                JArray acidsArray = j["Acids"] as JArray;
                JArray alkaliArray = j["Alkali"] as JArray;
                JArray organicArray = j["Organic"] as JArray;
                JArray pureMetalsArray = j["Pure Metals"] as JArray;

                List<JArray> arrays = new List<JArray>();
                arrays.Add(commonGasesAndLiquitsArray);
                arrays.Add(saltsArray);
                arrays.Add(acidsArray);
                arrays.Add(alkaliArray);
                arrays.Add(organicArray);
                arrays.Add(pureMetalsArray);

                
                foreach (JArray array in arrays)
                {
                    for (int i = 0; i < array.Count; i++)
                    {
                        JObject parsedData = JObject.Parse(array[i].ToString());
                        Chemical_Combinations newCombination = new Chemical_Combinations(parsedData["type"].ToString(), parsedData["name"].ToString(), (float) parsedData["molarMass"]);

                        _combinations.Add(newCombination);
                    }
                }


                return _combinations;
            }
        }
    }
}
