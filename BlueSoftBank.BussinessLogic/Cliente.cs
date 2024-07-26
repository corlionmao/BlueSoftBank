namespace BlueSoftBank.BussinessLogic
{
    public class Cliente
    {
        private string nombre;
        private int id;
        private Tipo tipoCliente;
        public enum Tipo {persona, empresa }
        public Cliente(string _nombre, int _id, Tipo _tipoCliente) { 
            this.nombre = _nombre;
            this.id = _id;
            this.TipoCliente = _tipoCliente;
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }
        public Tipo TipoCliente { get => tipoCliente; set => tipoCliente = value; }

    }
}
