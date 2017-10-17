using System;
using System.IO;
namespace FileManagement
{
    class Program
    {
        static string op1;
        static string op2;
        static string[] perguntas;
        static string[] respostas;
        static StreamWriter sw;
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Bem vindo!\n\n");
            do{
                Console.WriteLine("\n\nEscolha uma das opções abaixo\n1 - Listar Perguntas\n2 - Adicionar Perguntas\n3 - Realizar Cadastro\n4 - Listas Cadastros\n5- Encerrar");
                do
                {

                    op2 = Console.ReadLine();
                } while (op2!="1" && op2!="2" && op2!="3" && op2!="4" && op2!="5");
                switch (op2)
                {
                    case "1":ListarPerguntas();break;
                    case "2":AdicionarPerguntas();break;
                    case "3":Cadastro();break;
                    case "4":ListarRespostas();break;
                    case "5":Environment.Exit(0);break;
                }

            } while (op2!="5");
        }
        static void Cadastro()
        {
            perguntas = File.ReadAllLines("perguntas.txt");
            respostas = new string[perguntas.Length];
            StreamWriter sw = new StreamWriter("respostas.csv",true);
            do
            {
                for(int i=0; i<perguntas.Length; i++)
                {
                    Console.WriteLine(perguntas[i]);
                    sw.Write(Console.ReadLine()+";");
                }
                sw.WriteLine();
                do
                {
                    Console.Write("\nDeseja realizar um novo cadastro? (S ou N)");
                    op1 = Console.ReadLine();
                } while (op1!="S" && op1!="N" && op1!="s" && op1!="n");
            } while(op1=="S" || op1=="s");
            sw.Close();
        }
        static void ListarPerguntas()
        {
            if(!File.Exists("perguntas.txt"))
            {
                File.Create("perguntas.txt").Close();
            }
            perguntas = File.ReadAllLines("perguntas.txt");
            if(perguntas.Length==0)
            {
                Console.WriteLine("\nNão existem perguntas! Crie!");
            }
            else
            {
                Console.WriteLine();
                perguntas = File.ReadAllLines("perguntas.txt");
                for(int i=0; i<perguntas.Length; i++)
                {
                Console.WriteLine(perguntas[i]);
                }
            }
        }
        static void AdicionarPerguntas()
        {
            char c;
            int co;
            StreamWriter sp = new StreamWriter("perguntas.txt",true);
            Console.Write("\nDigite a quantidade desejada: ");
            do
            {
                c = char.Parse(Console.ReadLine());
            } while (!char.IsDigit(c));
            co = int.Parse(c.ToString());
            for(int i=1;i<=co;i++)
            {
                Console.Write("\nPergunta "+ i +": ");
                sp.Write(Console.ReadLine());
                sp.WriteLine();
            }
            sp.Close();
        }
        static void ListarRespostas()
        {
            string[] respostaslinha;
            perguntas = File.ReadAllLines("perguntas.txt");
            respostas = File.ReadAllLines("respostas.csv");
            for(int i=0; i<respostas.Length; i++)
            {
                respostaslinha = respostas[i].Split(';');
                for(int e=0; e<perguntas.Length; e++)
                {
                    Console.WriteLine(perguntas[e]+": "+respostaslinha[e]);
                }
                Console.WriteLine();
            }
        }
    }
}
