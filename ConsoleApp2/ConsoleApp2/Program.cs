namespace ConsoleApp2
{
    public interface IUsuario // Al colocar esta interfaz en Usuario, especifico que Usuario debe tener el método GetDni. Similar a TypeScript
    {
        int GetDni();
    }

    public class Usuario : IUsuario
    {
        private string _nombre;
        private string _apellido;
        private int _dni;
        private string _email;
        private int _edad;
        private string _domicilio;

        public Usuario(string nombre, string apellido, int dni, string email, int edad, string domicilio)
        {
            this._nombre = nombre; // Los this no eran necesarios en este caso, ya que no hay ambiguedad sobre quién es _nombre
            this._apellido = apellido;
            this._dni = dni;
            this._email = email;
            this._edad = edad;
            this._domicilio = domicilio;
        }

        public string DondeVive()
        {
            return this._domicilio;
        }

        public int GetDni()
        {
            return this._dni;
        }

        public void SetNewDomicilio(string nuevoDomicilio)
        {
            this._domicilio = nuevoDomicilio;
        }
    }

    class ProbarObjetos
    {
        static void Main(string[] args)
        {
            var user = new Usuario("Luis", "Pérez", 423534645, "LuisP@gmail.com", 30, "Calle Falsa 123");

            Console.WriteLine($"El usuario vive en: {user.DondeVive()}");
            Console.WriteLine($"El dni del usuario es: {user.GetDni()}");
            user.SetNewDomicilio("Calle Falsa 321");
            Console.WriteLine($"El nuevo domicilio del usuario es: {user.DondeVive()}");

        }
    }
}
