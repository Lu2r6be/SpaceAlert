using SpaceAlertMonitor.Model;

namespace SpaceAlertMonitor.Service
{

    public partial class AlertaService
    {
        // simulando banco de dados
        private List<Alerta> alertas = new List<Alerta>();

        public void RegistrarAlerta(int dispositivoId, string descricao, string nivel)
        {
            Alerta alerta = new Alerta(dispositivoId, descricao, nivel);
            alertas.Add(alerta);
            Console.WriteLine($"\nAlerta registrado com sucesso! ID: {alerta.Id}");
        }

        public void ListarAlertas()
        {
            if (alertas.Count == 0)
            {
                Console.WriteLine("\nNenhum alerta registrado.");
                return;
            }

            Console.WriteLine("\n=== ALERTAS REGISTRADOS ===");
            foreach (var alerta in alertas)
            {
                Console.WriteLine(alerta.ExibirInfo());
            }
        }

        public List<Alerta> ObterTodos()
        {
            return alertas;
        }
    }
}
