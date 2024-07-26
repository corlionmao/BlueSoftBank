namespace BlueSoftBank.BussinessLogic
{
    public class Ciudad
    {
        private string _id;
        private string nombre;

        public Ciudad(string id, string nombre)
        {
            _id = id;
            this.nombre = nombre;
        }

        public string Id { get => _id; set => _id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}