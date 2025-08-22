using ReservaHotel.Models;

#region Variáveis

string option = "0";
bool showMenu = true;
bool showMenuReserva = true;
bool showMenuSuite = true;
Reserva reserva = new Reserva(diasReservados: 0);
List<Pessoa> hospedes = new List<Pessoa>();

#endregion

#region Criação das suítes

Suite suiteComum = new Suite(tipoSuite: "Comum", capacidade: 2, valorDiaria: 30);
Suite suitePremium = new Suite(tipoSuite: "Premium", capacidade: 3, valorDiaria: 50);
Suite suiteMasterPremium = new Suite(tipoSuite: "Master Premium", capacidade: 3, valorDiaria: 70);
Suite suiteUltraMasterPremium = new Suite(tipoSuite: "Ultra Master Premium", capacidade: 4, valorDiaria: 100);

#endregion

// Menu da reserva
while (showMenu)
{
    Console.Clear();
    Console.WriteLine("Escolha uma opção: ");
    Console.WriteLine("1. Fazer reserva");
    Console.WriteLine("2. Fechar");
    option = Console.ReadLine();

    switch (option)
    {
        case "1":   // fazer reserva
           
            // Menu de seleção da suíte
            while (showMenuSuite)
            {
                Console.Clear();
                Console.WriteLine("Escolha a suíte: ");
                Console.WriteLine($"1 - Comum - capacidade de {suiteComum.Capacidade} hóspedes");
                Console.WriteLine($"2 - Premium - capacidade de {suitePremium.Capacidade} hóspedes");
                Console.WriteLine($"3 - Master Premium - capacidade de {suiteMasterPremium.Capacidade} hóspedes");
                Console.WriteLine($"4 - Ultra Master Premium - capacidade de {suiteUltraMasterPremium.Capacidade} hóspedes");

                switch (Console.ReadLine())
                {
                    case "1": // suiteComum
                        reserva.CadastrarSuite(suiteComum);
                        showMenuSuite = false;
                        break;
                    case "2": // suitePremium
                        reserva.CadastrarSuite(suitePremium);
                        showMenuSuite = false;
                        break;
                    case "3": // suiteMasterPremium
                        reserva.CadastrarSuite(suiteMasterPremium);
                        showMenuSuite = false;
                        break;
                    case "4": // suiteUltraMasterPremium
                        reserva.CadastrarSuite(suiteUltraMasterPremium);
                        showMenuSuite = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida, pressione uma tecla para tentar de novo.");
                        Console.ReadKey();
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Reserva para quantos dias? ");
            int diasReservados = int.Parse(Console.ReadLine());
            reserva.DiasReservados = diasReservados;

            // cria um hóspede novo
            while (showMenuReserva)
            {
                Console.WriteLine("Digite o primeiro nome do hóspede: ");
                string nome = Console.ReadLine();
                Console.WriteLine("Digite o sobrenome do hóspede: ");
                string sobrenome = Console.ReadLine();

                Pessoa hospede = new Pessoa(nome, sobrenome);
                hospedes.Add(hospede);

                Console.WriteLine("Deseja adicionar outro hóspede? (s/n)");
                string resposta = Console.ReadLine();
                while (resposta.ToLower() != "n" && resposta.ToLower() != "s")
                {
                    Console.WriteLine("Resposta inválida. Deseja adicionar outro hóspede? (s/n)");
                    resposta = Console.ReadLine();
                }

                //  se o usuário não quiser adicionar mais hóspedes, adiciona a lista de hóspedes à reserva
                if (resposta.ToLower() == "n")
                {
                    showMenuReserva = false;
                    showMenu = false;
                    reserva.CadastrarHospedes(hospedes);
                }
            }

            break;
        case "2":   // fechar
            Console.WriteLine("Fechando...");
            showMenu = false;
            break;
        default:
            Console.WriteLine("Opção inválida, pressione uma tecla para tentar de novo.");
            Console.ReadKey();
            break;
    }
}

// Exibe os dados da reserva
if (reserva.DiasReservados > 0)
{
    Console.Clear();
    Console.WriteLine($"Reserva criada com sucesso!");
    Console.WriteLine($"Tipo de suíte: {reserva.Suite.TipoSuite}");
    Console.WriteLine($"Capacidade: {reserva.Suite.Capacidade}");
    Console.WriteLine(reserva.ObterQuantidadeHospedes().quantidadeString);
    Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes().quantidadeInt}");
    Console.WriteLine($"Valor da diária: {reserva.CalcularValorDiaria().valor:C}");
    Console.WriteLine(reserva.CalcularValorDiaria().desconto);
}
else
{
    Console.WriteLine("Nenhuma reserva foi feita.");
}