using SpaceAlertMonitor.Interface;
using SpaceAlertMonitor.Model;
using SpaceAlertMonitor.Service;

// Listas em memoria (simula banco de dados)
List<DispositivoEspacial> dispositivos = new List<DispositivoEspacial>();
AlertaService alertaService = new AlertaService();
bool continuar = true;

// Loop principal do menu
while (continuar)
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine("      SPACE ALERT MONITOR       ");
    Console.WriteLine("================================");
    Console.WriteLine("  1 - Cadastrar Satelite");
    Console.WriteLine("  2 - Cadastrar Sensor");
    Console.WriteLine("  3 - Registrar Alerta");
    Console.WriteLine("  4 - Listar Dispositivos");
    Console.WriteLine("  5 - Listar Alertas");
    Console.WriteLine("  6 - Relatorio de Alertas");
    Console.WriteLine("  0 - Sair");
    Console.WriteLine("================================");
    Console.Write("Opcao: ");

    try
    {
        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                CadastrarSatelite();
                break;
            case 2:
                CadastrarSensor();
                break;
            case 3:
                RegistrarAlerta();
                break;
            case 4:
                ListarDispositivos();
                break;
            case 5:
                alertaService.ListarAlertas();
                break;
            case 6:
                alertaService.GerarRelatorio();
                break;
            case 0:
                continuar = false;
                Console.WriteLine("\nEncerrando sistema. Ate logo!");
                break;
            default:
                Console.WriteLine("\nOpcao invalida. Tente novamente.");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("\nErro: Digite apenas numeros no menu.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nErro inesperado: {ex.Message}");
    }

    if (continuar)
    {
        Console.WriteLine("\nPressione ENTER para continuar...");
        Console.ReadLine();
    }
}

// ============================================================
// METODOS LOCAIS
// ============================================================

void CadastrarSatelite()
{
    Console.WriteLine("\n--- CADASTRAR SATELITE ---");

    try
    {
        Console.Write("Nome do satelite: ");
        string nome = Console.ReadLine();

        Console.Write("Orbita (ex: LEO, MEO, GEO): ");
        string orbita = Console.ReadLine();

        Console.Write("Latitude (-90 a 90): ");
        double lat = double.Parse(Console.ReadLine());

        Console.Write("Longitude (-180 a 180): ");
        double lon = double.Parse(Console.ReadLine());

        Coordenada coord = new Coordenada(lat, lon);
        Satelite satelite = new Satelite(nome, orbita, coord);
        dispositivos.Add(satelite);

        // Injecao de dependencia via interface IMonitoravel
        IMonitoravel monitor = satelite;
        monitor.Monitorar();

        Console.WriteLine($"\nSatelite '{nome}' cadastrado com ID {satelite.Id}!");
    }
    catch (FormatException)
    {
        Console.WriteLine("\nErro: Coordenadas invalidas. Use numeros.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"\nErro: {ex.Message}");
    }
}

void CadastrarSensor()
{
    Console.WriteLine("\n--- CADASTRAR SENSOR ---");

    try
    {
        Console.Write("Nome do sensor: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Tipos disponiveis: Temperatura | Radiacao | Pressao | Movimento");
        Console.Write("Tipo do sensor: ");
        string tipo = Console.ReadLine();

        Sensor sensor = new Sensor(nome, tipo);
        dispositivos.Add(sensor);

        // Injecao de dependencia via interface IMonitoravel
        IMonitoravel monitor = sensor;
        monitor.Monitorar();

        Console.WriteLine($"\nSensor '{nome}' cadastrado com ID {sensor.Id}!");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"\nErro: {ex.Message}");
    }
}

void RegistrarAlerta()
{
    Console.WriteLine("\n--- REGISTRAR ALERTA ---");

    if (dispositivos.Count == 0)
    {
        Console.WriteLine("Nenhum dispositivo cadastrado. Cadastre um primeiro.");
        return;
    }

    ListarDispositivos();

    try
    {
        Console.Write("\nID do dispositivo: ");
        int id = int.Parse(Console.ReadLine());

        // Busca o dispositivo pelo ID
        DispositivoEspacial dispositivo = null;
        foreach (var d in dispositivos)
        {
            if (d.Id == id)
            {
                dispositivo = d;
                break;
            }
        }

        if (dispositivo == null)
        {
            Console.WriteLine("Dispositivo nao encontrado.");
            return;
        }

        Console.Write("Descricao do alerta: ");
        string descricao = Console.ReadLine();

        Console.WriteLine("Nivel: 1-BAIXO | 2-MEDIO | 3-ALTO");
        Console.Write("Nivel: ");
        int nivelOpcao = int.Parse(Console.ReadLine());

        string nivel = nivelOpcao switch
        {
            1 => "BAIXO",
            2 => "MEDIO",
            3 => "ALTO",
            _ => "BAIXO"
        };

        alertaService.RegistrarAlerta(id, descricao, nivel);
    }
    catch (FormatException)
    {
        Console.WriteLine("\nErro: Entrada invalida. Use numeros para ID e nivel.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"\nErro: {ex.Message}");
    }
}

void ListarDispositivos()
{
    if (dispositivos.Count == 0)
    {
        Console.WriteLine("\nNenhum dispositivo cadastrado.");
        return;
    }

    Console.WriteLine("\n=== DISPOSITIVOS CADASTRADOS ===");
    foreach (var dispositivo in dispositivos)
    {
        // Polimorfismo: chama ExibirInfo() correto para cada tipo
        Console.WriteLine(dispositivo.ExibirInfo());
    }
}
