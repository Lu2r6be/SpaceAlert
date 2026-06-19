using SpaceAlertMonitor.Interface;

namespace SpaceAlertMonitor.Model
{
    // Heranca: Satelite herda de DispositivoEspacial
    // Implementa a interface IMonitoravel
    public class Satelite : DispositivoEspacial, IMonitoravel
    {
        // Campos privados especificos do Satrlite
        private string orbita;
        private Coordenada coordenada;

        // Propriedades publicas
        public string Orbita
        {
            get { return orbita; }
            set { orbita = value; }
        }

        public Coordenada Coordenada
        {
            get { return coordenada; }
            set { coordenada = value; }
        }

        // Construtor: chama o construtor base com base()
        public Satelite(string nome, string orbita, Coordenada coordenada) : base(nome)
        {
            Orbita = orbita;
            Coordenada = coordenada;
        }

        // Polimorfismo: sobrescreve o metodo abstrato da classe base
        public override string ExibirInfo()
        {
            return $"[SATELITE] ID: {Id} | Nome: {Nome} | Orbita: {Orbita} | " +
                   $"Posicao: {Coordenada} | Registro: {DataRegistro:dd/MM/yyyy HH:mm} | Status: {ObterStatus()}";
        }

        // Implementacao da interface IMonitoravel
        public void Monitorar()
        {
            Console.WriteLine($">> Monitorando satelite '{Nome}' em orbita {Orbita}.");
        }

        public bool EstaAtivo()
        {
            return Ativo;
        }
    }
}
