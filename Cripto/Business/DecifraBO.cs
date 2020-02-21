using System;
using System.Text;
using Cripto.Models;
using Cripto.Sevices;

namespace Cripto.Business
{
    public class DecifraBO
    {
        
        public Mensagem Decifrar(){
            Mensagem m = new Mensagem();
            ServiceCodenation s = new ServiceCodenation();
            m = s.ObterMensagem();
            m.Decifrado = CalculoJulioCesar(m.Cifrado, m.Numero_casas);
            m.Resumo_criptografado =  GerarHashsha1(m.Decifrado);
            s.EnviarMensagem(m);
            return m;
        }

        public string GerarHashsha1(string mensagemDecodificada){
                var sha1 = System.Security.Cryptography.SHA1.Create();
                var bytes = System.Text.Encoding.UTF8.GetBytes(mensagemDecodificada);
                var hash = sha1.ComputeHash(bytes);

            var sb = new StringBuilder();
             foreach (var hashByte in hash)
            {
                    sb.AppendFormat("{0:x2}", hashByte);
             }

                return sb.ToString();   
                     }
            private string CalculoJulioCesar (string mensagemCodificada, int chaveCriptografia){
            mensagemCodificada = mensagemCodificada.ToLower();
            string mensagemDecodificada = "";
            foreach (char item in mensagemCodificada)
            {
                int p = (int)item;

                if (p>=97 && p<=122)
                {
                    int n = 0;
                    if (p-chaveCriptografia<97)
                    {
                        n = p - 97;
                        n = 123 - (chaveCriptografia-n);
                    }else{
                        n = p-chaveCriptografia;
                    }
                    mensagemDecodificada += (char)n;

                }else{
                    mensagemDecodificada += item;
                }
            }
            return mensagemDecodificada;
        }

        
    }

    


}