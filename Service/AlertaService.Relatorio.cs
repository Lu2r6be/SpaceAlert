namespace SpaceAlertMonitor.Service
{

    public partial class AlertaService
    {
        public void GerarRelatorio()
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("     RELATORIO DE ALERTAS     ");
            Console.WriteLine("==============================");
            Console.WriteLine($"Total de alertas: {alertas.Count}");

            int baixo = 0, medio = 0, alto = 0;

            foreach (var alerta in alertas)
            {
                if (alerta.Nivel == "BAIXO") baixo++;
                else if (alerta.Nivel == "MEDIO") medio++;
                else if (alerta.Nivel == "ALTO") alto++;
            }

            Console.WriteLine($"  BAIXO  : {baixo}");
            Console.WriteLine($"  MEDIO  : {medio}");
            Console.WriteLine($"  ALTO   : {alto}");
            Console.WriteLine("==============================");
        }
    }
}
