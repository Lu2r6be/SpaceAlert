namespace SpaceAlertMonitor.Model
{
    // Classe abstrata: não se instancia diretamente
    // Serve como base para Satelite e Sensor
    public abstract class DispositivoEspacial
    {
        // Campos privados (encapsulamento)
        private int id;
        private string nome;
        private DateTime dataRegistro;
        private bool ativo;

        // Contador estatico, gera IDs unicos para cada dispositivo
        private static int contadorId = 1;

        // Propriedades publicas
        public int Id
        {
            get { return id; }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O nome do dispositivo não pode ser vazio.");
                nome = value;
            }
        }

        public DateTime DataRegistro
        {
            get { return dataRegistro; }
        }

        public bool Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }

        // Construtor base
        public DispositivoEspacial(string nome)
        {
            id = contadorId++;
            Nome = nome;
            dataRegistro = DateTime.Now;
            ativo = true;
        }

        // Metodo abstrato que obriga cada subclasse a implementar
        public abstract string ExibirInfo();

        // Metodo concreto compartilhado por todas as subclasses
        public string ObterStatus()
        {
            return Ativo ? "Ativo" : "Inativo";
        }
    }
}
