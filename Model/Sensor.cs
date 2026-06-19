using SpaceAlertMonitor.Interface;

namespace SpaceAlertMonitor.Model
{
    // Heranca: Sensor herda de DispositivoEspacial
    // Implementa a interface IMonitoravel
    public class Sensor : DispositivoEspacial, IMonitoravel
    {
        // Campo privado especifico do Sensor
        private string tipoSensor;

        // Propriedade publica
        public string TipoSensor
        {
            get { return tipoSensor; }
            set { tipoSensor = value; }
        }

        // Construtor: chama o construtor base com base()
        public Sensor(string nome, string tipoSensor) : base(nome)
        {
            TipoSensor = tipoSensor;
        }

        // Polimorfismo: sobrescreve o metodo abstrato da classe base
        public override string ExibirInfo()
        {
            return $"[SENSOR]   ID: {Id} | Nome: {Nome} | Tipo: {TipoSensor} | " +
                   $"Registro: {DataRegistro:dd/MM/yyyy HH:mm} | Status: {ObterStatus()}";
        }

        // Implementacao da interface IMonitoravel
        public void Monitorar()
        {
            Console.WriteLine($">> Monitorando sensor '{Nome}' do tipo {TipoSensor}.");
        }

        public bool EstaAtivo()
        {
            return Ativo;
        }
    }
}
