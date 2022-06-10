


//Inicialização
int finalizacao = 1;
while (finalizacao == 1)
{

    Console.WriteLine("MINHA AGENDA TELEFONICA");
    Console.WriteLine("=======================================");
    Console.WriteLine("Seja bem vindo(a)");
    Console.WriteLine("O que deseja fazer?: ");
    Console.WriteLine("1 - CADASTRAR NOVO CONTATO | 2 - BUSCAR CONTATO");
    string resposta = Console.ReadLine();

    // Cadastros
    string nome = "";
    string telefone = "";
    string email = "";


    //Condição de saida da agenda
    int sair = 0;

    // Condição para cadastrar novo contato
    if (resposta == "1")

    {
        while (resposta == "1")
        {
            //Cadastro para salvamento
            Console.WriteLine("Nome: ");
            nome = Console.ReadLine();
            Console.WriteLine("Telefone: ");
            telefone = Console.ReadLine();
            Console.WriteLine("E-mail: ");
            email = Console.ReadLine();
            // Confirmação para Salvamento
            Console.WriteLine("=======================================");
            Console.WriteLine("Dados Adicionados a sua Agenda: ");
            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Telefone: " + telefone);
            Console.WriteLine("E-mail: " + email);
            Console.WriteLine("DESEJA SALVAR: \r\n1 - SIM | 2 - NÂO");
            int salvar = Int32.Parse(Console.ReadLine());
            if (salvar == 1)
            {
                try
                {
                    Dictionary<string, string> agenda = new Dictionary<string, string>();
                    {
                        agenda.Add("Nome: ", nome);
                        agenda.Add("Telefone: ", telefone);
                        agenda.Add("E-mail: ", email);
                    };

                    foreach (var (key, value) in agenda)
                    {
                        StreamWriter sw = File.AppendText("D:\\agenda.txt");
                        sw.WriteLine(key + value);
                        sw.Close();
                    }

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
            Console.WriteLine("Salvo com Sucesso !!!");

            Console.WriteLine("Salvar outro contato? \r\n1 - SIM \r\n2 - NÃO");
            finalizacao = Int32.Parse(Console.ReadLine());
            if (finalizacao == 2)
                break;
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
    finalizacao = Int32.Parse(Console.ReadLine());
    if (finalizacao == 2)
        break;

}
Console.WriteLine("Fechando sua Agenda...");
