using DatabaseReader;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleDetails;

namespace DataToJsonAdaptor
{
    public class DatabaseToJsonAdapter : IJsonTarget
    {
        private readonly DbReader? dbReader;

        public DatabaseToJsonAdapter(DbReader dbReader)
        {
            this.dbReader = dbReader;
        }
        public string ReadDataFromSource()
        {
            var list = dbReader?.GetData();
            string json = JsonConvert.SerializeObject(list);
            return json;
        }
    }
}

