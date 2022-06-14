
//Inicialização
using Agenda;
using System.Text.RegularExpressions;


//Condições de finalização de laços
int finalizacao = 1;
int sair_tudo = 0;
int sair_email = 0;
int sair_telefone = 0;
int final = 0;

while (finalizacao == 1)
{
    Console.WriteLine("MINHA AGENDA TELEFONICA");
    Console.WriteLine("=======================================");
    Console.WriteLine("Seja bem vindo(a)");
    Console.WriteLine("O que deseja fazer?: ");
    Console.WriteLine("1 - CADASTRAR NOVO CONTATO | 2 - BUSCAR CONTATO");
    string resposta = Console.ReadLine();

    // Condição para cadastrar novo contato
    if (resposta == "1")
    {
        while (sair_tudo == 0)
        {
            //Cadastro para salvamento
            Contato conta1 = new Contato();
            Console.WriteLine("Nome: ");
            conta1.nome = Console.ReadLine();
            //Validar Telefone
            while (sair_telefone == 0)
            {
                Console.WriteLine("Telefone: ");
                conta1.telefone = Console.ReadLine();
                if (conta1.telefone.Length == 11)
                {
                    sair_telefone = 1;
                }
                else
                {
                    Console.WriteLine("Telefone inválido!!!");
                    Console.WriteLine("Ex: DDD = 47 numero = 9885012555");
                }
            }
            //Validar Email
            while (sair_email == 0)
            {
                Console.WriteLine("E-mail: ");
                conta1.email = Console.ReadLine();
                Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
                if (rg.IsMatch(conta1.email))
                {
                    Console.WriteLine("Email valido");
                    sair_email = 1;
                }
                else
                {
                    Console.WriteLine("Email Invalido");
                }

                //Confirmação para Salvamento
                Console.WriteLine("=======================================");
                Console.WriteLine("Dados Adicionados a sua Agenda: ");
                Console.WriteLine("Nome: " + conta1.nome);
                Console.WriteLine("Telefone: " + conta1.telefone);
                Console.WriteLine("E-mail: " + conta1.email);
                Console.WriteLine("DESEJA SALVAR: \r\n1 - SIM | 2 - NÂO");
                int salvar = Int32.Parse(Console.ReadLine());
                if (salvar == 1)
                {
                    try
                    {
                        Dictionary<string, string> agenda = new Dictionary<string, string>();
                        {
                            agenda.Add("Nome: ", conta1.nome);
                            agenda.Add("Telefone: ", conta1.telefone);
                            agenda.Add("E-mail: ", conta1.email);
                        };

                        foreach (var (key, value) in agenda)
                        {
                            StreamWriter sw = File.AppendText("D:\\agenda.txt");
                            sw.WriteLine(key + value);
                            sw.Close();
                        }
                        Console.WriteLine("Salvo com Sucesso !!!");
                        break;


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Executing finally Block");
                    }
                }
                else
                {
                    Console.WriteLine("Seu Contato não foi salvo");
                }

            }

            //Condição para fazer a busca por contato
    if (resposta == "2") 
    {
        while (resposta == "2")
        {
            Console.WriteLine("Digite sua busca: ");
            string pesquisa = Console.ReadLine();
            //Abrindo a Agenda
            StreamReader sw = new StreamReader("D:\\agenda.txt");

            while (!sw.EndOfStream)
            {
                if (sw.ReadLine().Contains(pesquisa))
                {
                    string registro = sw.ReadLine();
                    Console.WriteLine(registro);
                }

            }
            Console.WriteLine(pesquisa + " Não foi encontrado na sua agenda!");

            Console.WriteLine("Deseja fazer outra busca?");
            Console.WriteLine("1 - SIM | 2 - NÃO");
            int respostaa = Int32.Parse(Console.ReadLine());
            if (respostaa == 2)
                break;
        }
    }

Console.WriteLine("Deseja voltar ao inicio?");
Console.WriteLine("1 - VOLTAR AO INICIO | 2 - FECHAR DA AGENDA");
resposta = "1";
sair_email = 0;
sair_telefone = 0;
sair_tudo = 0;
finalizacao = Int32.Parse(Console.ReadLine());
if (finalizacao == 2)
    break;

}
Console.WriteLine("Fechando sua Agenda...");
}
}
