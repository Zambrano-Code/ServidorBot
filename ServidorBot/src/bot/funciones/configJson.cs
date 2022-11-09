using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using bot.modelos;

namespace bot.funciones;

public class configJson
{

    public ModeloJsonBot bot { get; private set; }
    public ModeloJsonMysql mysql { get; private set; }
    public configJson()
    {
        var botjson = buscarArchivo("../../../src/bot/config.json");
        bot = JsonConvert.DeserializeObject<ModeloJsonBot>(botjson);

        var mysqljson = buscarArchivo("../../../src/configmysql.json");
        mysql = JsonConvert.DeserializeObject<ModeloJsonMysql>(mysqljson);
    }

    private string buscarArchivo(string url)
    {
        string json = string.Empty;
        var fs = File.OpenRead(url);
        var sr = new StreamReader(fs, new UTF8Encoding(false));
        json = sr.ReadToEnd();
        return json;
           
    }
}
