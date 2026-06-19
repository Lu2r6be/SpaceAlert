namespace SpaceAlertMonitor.Model
{
    // Struct: tipo de valor simples para armazenar coordenadas geográficas
    public struct Coordenada
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Coordenada(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"Lat: {Latitude}° | Lon: {Longitude}°";
        }
    }
}
