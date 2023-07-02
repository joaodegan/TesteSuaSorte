string mensagemDeBoasVindas = "Seja bem vindo!!!";
int dicasRestantes = 3;
int tentativas = 1;
int numero = 0;

void ExibirMensagemDeBoasVindas() {
    Console.WriteLine(@"

▀█▀ █▀▀ █▀ ▀█▀ █▀▀   █▀ █░█ ▄▀█   █▀ █▀█ █▀█ ▀█▀ █▀▀ █
░█░ ██▄ ▄█ ░█░ ██▄   ▄█ █▄█ █▀█   ▄█ █▄█ █▀▄ ░█░ ██▄ ▄
");
    Console.WriteLine(mensagemDeBoasVindas);
}

int SortearNumero()
{
    Random random = new Random();
    Console.WriteLine("\nSorteando...");
    //Thread.Sleep(4000);
    int numeroSorteado = random.Next(1, 101);
    Console.WriteLine("\nO número já foi sorteado!!!");
    return numeroSorteado;
}

int EscolherNumero()
{
    do
    {
        Console.Write("Escolha um número de 1 a 100: ");
        try
        {
            int numeroEscolhido = int.Parse(Console.ReadLine()!);
            if (numeroEscolhido > 100 || numeroEscolhido < 1)
            {
                Console.WriteLine("Número digitado é inválido!!!\n");
            }
            else
            {
                return numeroEscolhido;
            }
        }   
        catch(Exception ex)
        {
            Console.WriteLine("Caractere inválido!!!\n");
        }
    }
    while (true);
}

void VerificarAcerto(int numeroSorteado, int numeroEscolhido) 
{
    bool novoJogo = false;
    if (numeroSorteado == numeroEscolhido)
    {
        Console.WriteLine("\nUAUU, você acertou.. Parabéns!!!\n");
        novoJogo = true;
    }
    else
    {
        Console.WriteLine("\n:( , não foi dessa vez!\n");
        DarDicas(numeroEscolhido);
    }
    JogarNovamente(novoJogo);
}

void Jogar(bool novoJogo)
{
    Console.WriteLine($"\n\n\n\n----> Tentativas #{tentativas}\n\n\n\n");
    tentativas++;
    if (novoJogo)
    {
        numero = SortearNumero();
    }
    Console.WriteLine(numero);
    VerificarAcerto(numero, EscolherNumero());
}

void JogarNovamente(bool novoJogo)
{
    do
    {
        Console.Write("--> Deseja jogar novamente? [ S / N ] ");
        string jogarNovamente = Console.ReadLine()!;
        if (jogarNovamente.ToUpper() == "S")
        {
            Jogar(novoJogo);
        }
        else if (jogarNovamente.ToUpper() == "N")
        {
            Console.WriteLine("Até mais, volte sempre!");
        }
        else
        {
            Console.WriteLine("Comando inválido!\n");
        }
        return;
    }
    while (true);
}

void DarDicas(int numeroEscolhido)
{
    Console.WriteLine($"Dicas restantes {dicasRestantes}");
    if (dicasRestantes == 0)
    {
        Console.WriteLine("Você não tem mais dicas :/");
    }
    else
    {
        do
        {
            Console.Write("\n--> Gostaria de receber uma dica? [ S / N ] ");
            string receberDica = Console.ReadLine()!;
            if (receberDica.ToUpper() == "S")
            {
                if (numero >= numeroEscolhido - 10 && numero <= numeroEscolhido + 10)
                {
                    Console.WriteLine($"Está próximo!\n");
                }
                else
                {
                    Console.WriteLine($"Está longe!\n");
                }
                dicasRestantes--;
            }
            else if (receberDica.ToUpper() == "N")
            {
                return;
            }
            else
            {
                Console.WriteLine("Comando inválido!\n");
            }
            return;
        } while (true);
    }
}

ExibirMensagemDeBoasVindas();
Jogar(true);
