using ReservaHotel.Models;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede ", "1");
Pessoa p2 = new Pessoa(nome: "Hóspede ", "2");

hospedes.Add(p1);
hospedes.Add(p2);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 10);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe os dados da reserva
Console.WriteLine($"Reserva criada com sucesso!");
Console.WriteLine($"Tipo de suíte: {reserva.Suite.TipoSuite}");
Console.WriteLine($"Capacidade: {reserva.Suite.Capacidade}");
Console.WriteLine(reserva.ObterQuantidadeHospedes().quantidadeString);
Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes().quantidadeInt}");
Console.WriteLine($"Valor da diária: {reserva.CalcularValorDiaria().valor:C}");
Console.WriteLine(reserva.CalcularValorDiaria().desconto);