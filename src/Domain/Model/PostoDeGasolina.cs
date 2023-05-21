namespace Domain.Model
{
    public class PostoDeGasolina
    {
        public int Id { get; private set; }
        public int QuantidadeBombas { get; private set; }
        public List<Carro> FilaDeEspera { get; private set; }
        public List<Carro> CarrosAbastecidos { get; private set; }

        public PostoDeGasolina()
        {
        }
    }
}
