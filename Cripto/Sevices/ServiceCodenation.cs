using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Cripto.Models;
using Newtonsoft.Json;

namespace Cripto.Sevices
{
    public class ServiceCodenation
    {
      

        public Mensagem ObterMensagem2(){

        Mensagem m = new Mensagem();

        m.Numero_casas = 7;
        m.Cifrado = "jvkl pz sprl obtvy. dolu fvb ohcl av lewshpu pa, pa pz ihk. jvyf ovbzl";
               
        return m;
    }

    public void EnviarMensagem(Mensagem mensagem){
        Console.WriteLine("iniciando metodo de post...");
          var bytes = System.Text.Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(mensagem));
        var response = Task.Run(async ()=> await Upload(bytes));

        Console.WriteLine(response);
        Console.WriteLine("encerrando metodo de post...");

    }

    public Mensagem ObterMensagem()    
    {
         Mensagem mensagem = null;
    using (var httpClient = new HttpClient())
    {
        Console.WriteLine("estrei aqui");
        var response = Task.Run(async ()=> await httpClient.GetAsync("https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=181b56956283596b7fb18c75c2760cca935e3d7c")).Result;
         
           string apiResponse =  Task.Run(async ()=> await response.Content.ReadAsStringAsync()).Result;
            //AsyncContext.RunTask
             //;
            mensagem = JsonConvert.DeserializeObject<Mensagem>(apiResponse);
    }
    
    return mensagem;
    }


public static async Task<string> Upload(byte[] msg)
{

    try
    {
         using (var client = new HttpClient())
     {
         using (var content =
             new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
         {
             content.Add(new StreamContent(new MemoryStream(msg)), "answer", "answer.json");

              using (
                 var message =
                     await client.PostAsync("https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=181b56956283596b7fb18c75c2760cca935e3d7c", content))
              {
                  var input = await message.Content.ReadAsStringAsync();

                Console.WriteLine(input);

                  return input;
              }
          }
        
    }
    }
    catch (System.Exception e)
    {
       Console.WriteLine(e.Message);
       return null;
    }
    
     }

}
}