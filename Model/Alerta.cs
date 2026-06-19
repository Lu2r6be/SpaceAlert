namespace SpaceAlertMonitor.Model
{
    public class Alerta
    {
        // Campos privados
        private int id;
        private int dispositivoId;
        private string descricao;
        private DateTime registradoEm;
        private string nivel;

        // Contador estatico de IDs
        private static int contadorId = 1;

        // Propriedades públicas
        public int Id { get { return id; } }
        public int DispositivoId { get { return dispositivoId; } }
        public DateTime RegistradoEm { get { return registradoEm; } }
        public string Nivel { get { return nivel; } set { nivel = value; } }

        public string Descricao
        {
            get { return descricao; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A descricao do alerta nao pode ser vazia.");
                descricao = value;
            }
        }

        // Construtor: registra data/hora automaticamente com DateTime.Now
        public Alerta(int dispositivoId, string descricao, string nivel)
        {
            id = contadorId++;
            this.dispositivoId = dispositivoId;
            Descricao = descricao;
            Nivel = nivel;
            registradoEm = DateTime.Now;
        }

        public string ExibirInfo()
        {
            return $"[ALERTA #{Id}] Dispositivo ID: {DispositivoId} | Nivel: {Nivel} | " +
                   $"{Descricao} | Em: {RegistradoEm:dd/MM/yyyy HH:mm}";
        }
    }
}
