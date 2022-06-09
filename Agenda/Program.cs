using System.IO;

Console.WriteLine("MINHA AGENDA TELEFONICA");
Console.WriteLine("==============================");
Console.WriteLine("Seja bem vindo(a)");
Console.WriteLine("O que deseja fazer?: ");
Console.WriteLine("1 - CADASTRAR NOVO CONTATO \r\n2 - BUSCAR CONTATO");
int resposta = Int32.Parse(Console.ReadLine());

// Cadastros
string nome = "";
string telefone = "";
string email = "";

//Condição de saida da agenda
int sair = 0;

// Condição para cadastrar novo contato
if (resposta == 1)

{
    while(resposta == 1)
    {
        Console.WriteLine("Nome: ");
        nome = Console.ReadLine();
        Console.WriteLine("Telefone: ");
        telefone = Console.ReadLine();
        Console.WriteLine("E-mail: ");
        email = Console.ReadLine();
        Console.WriteLine("==============================");
        Console.WriteLine("Dados Adicionados a sua Agenda: ");
        Console.WriteLine(nome);
        Console.WriteLine(telefone);
        Console.WriteLine(email);
        Console.WriteLine("DESEJA SALVAR: \r\n1 - SIM \r\n2 - NÂO");
        int salvar = int.Parse(Console.ReadLine());
        if (salvar == 1)
        {
            try
            {
                //Stream saida = File.Open("D:\\agenda.txt", FileMode.Create);
                StreamWriter sw = File.AppendText("D:\\agenda.txt");
                sw.WriteLine(nome);
                sw.WriteLine(telefone);
                sw.WriteLine(email);
                sw.Close();
                //saida.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: "+ e.Message);
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
        Console.WriteLine("Salvar outro contato? \r\n1 - SIM \r\n2 - NÃO");
        sair = Int32.Parse(Console.ReadLine());
        if (sair == 2)
            break;
    } 

}

if(resposta == 2)
{
    while(resposta == 2)
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

    }
}
Console.WriteLine("Fechando sua Agenda...");