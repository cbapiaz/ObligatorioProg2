using System;
using System.Collections.Generic;

namespace Dominio
{


    public class Empresa
    {
        #region atributos

        private static Empresa _instancia = null;
        public static Empresa Instancia { 
            get {
                if (_instancia == null)
                {
                    _instancia = new Empresa();
                }
                return _instancia;
            }
        }

        public bool LoggedIn { get; set; } = true;

        public int Id { get; set; }



        public string Nombre { get; set; }
        public List<Paquete> Paquetes { get; } = new List<Paquete>();
        public List<Canal> Canales { get; } = new List<Canal>();
        public List<User> Usuarios { get; } = new List<User>();
        public List<Compra> Compras { get; } = new List<Compra>();
        #endregion

        #region constructores
        private Empresa()
        {
            PrecargaPaquetes();
            PrecargaCanales();
            PrecargaCanalesAPaquetes();

            PreCargaUsuarios();
        }

     
        private void PreCargaUsuarios()
        {
            AltaUsuarioCliente(45042994, "Sebas", "Piaz", "Cba123");
            AltaUsuarioCliente(47294379, "Mathi", "Sanchez", "Mathi123");
            AltaUsuarioOperador("Ceci", "Pepe123");
            AltaUsuarioOperador("Klein", "Pepe666");
        }

        #endregion

        #region metodos


        /** USUARIO **/

        public User BuscarUsuario(string username)
        {
            foreach (User user in Usuarios)
            {
                if (user.NombreUsuario == username)
                {
                    return user;
                }
            }

            return null;
        }

        //logica de alta de usuario
        public bool AltaUsuario(User user)
        {
            if (user.Rol == User.ROL_CLIENTE)
            {
                //verificar que no exista el usuario cliente con esa cedula
                if (BuscarUsuario(user.Cedula.ToString()) == null) { 
                    return AltaUsuarioCliente(user.Cedula, user.Nombre, user.Apellido, user.Password);
                }
                else
                {
                    return false;
                }
            }

            if (user.Rol == User.ROL_OPERADOR)
            {
                //verificar que no exista otro usuario operador
                if (BuscarUsuario(user.Nombre) == null)
                {
                    return AltaUsuarioOperador(user.Nombre, user.Password);
                }
            }
            return false;
        }


        private bool AltaUsuarioCliente(int cedula, string nombre, string apellido, string password)
        {
            if (User.ValidarCedula(cedula) && User.ValidarPassword(password)
                && User.ValidarNombreApellido(nombre) && User.ValidarNombreApellido(apellido))
            {
                User u = new User(cedula, nombre, apellido, password, User.ROL_CLIENTE);
                Usuarios.Add(u);
                return true;
            }
            else
            {
                return false;
            }
        }



        private bool AltaUsuarioOperador(string nombreUsuario, string password)
        {
            if (User.ValidarPassword(password))
            {
                User u = new User(nombreUsuario, password, User.ROL_OPERADOR);
                Usuarios.Add(u);
                return true;
            }
            else
            {
                return false;
            }
        }

        public User BuscarUsuario(string username, string pass)
        {
            User u = null;
            foreach (User unU in Usuarios)
            {
                if (unU.NombreUsuario == username && unU.Password == pass)
                {
                    u = unU;
                    break;
                }
            }

            return u;
        }


        /// <summary>
        /// precargar los paquetes con distintos datos
        /// </summary>
        public void PrecargaPaquetes()
        {
            PaqueteHD.CostoFijo = 566;
            AgregarPaqueteHD("paqueteHD1", true, 580, true, new List<Canal>());
            AgregarPaqueteHD("paqueteHD2", true, 523, true, new List<Canal>());
            AgregarPaqueteHD("paqueteHD3", false, 623, true, new List<Canal>());
            AgregarPaqueteHD("paqueteHD4", false, 871, true, new List<Canal>());
            AgregarPaqueteHD("paqueteHD5", true, 174, true, new List<Canal>());
            AgregarPaqueteHD("paqueteHD6", true, 823, true, new List<Canal>());
            AgregarPaqueteHD("paqueteHD7", false, 284, true, new List<Canal>());
            AgregarPaqueteHD("paqueteHD8", false, 937, true, new List<Canal>());
            AgregarPaqueteHD("paqueteHD9", true, 127, true, new List<Canal>());
            AgregarPaqueteHD("paqueteHD10", true, 264, true, new List<Canal>());
            AgregarPaqueteSD("paqueteSD1", true, 385, true, new List<Canal>());
            AgregarPaqueteSD("paqueteSD2", true, 396, true, new List<Canal>());
            AgregarPaqueteSD("paqueteSD3", false, 295, true, new List<Canal>());
            AgregarPaqueteSD("paqueteSD4", false, 285, true, new List<Canal>());
            AgregarPaqueteSD("paqueteSD5", true, 184, true, new List<Canal>());
            AgregarPaqueteSD("paqueteSD6", true, 195, true, new List<Canal>());
            AgregarPaqueteSD("paqueteSD7", false, 186, true, new List<Canal>());
            AgregarPaqueteSD("paqueteSD8", false, 275, true, new List<Canal>());
            AgregarPaqueteSD("paqueteSD9", true, 275, true, new List<Canal>());
            AgregarPaqueteSD("paqueteSD10", true, 195, true, new List<Canal>());
        }

        /// <summary>
        /// precarga los canales con distintos datos
        /// </summary>
        public void PrecargaCanales()
        {
            AgregarCanal("canal1", Resolucion.BAJA, true, 180);
            AgregarCanal("canal2", Resolucion.BAJA, true, 190);
            AgregarCanal("canal3", Resolucion.ALTA, true, 100);
            AgregarCanal("canal4", Resolucion.ALTA, true, 120);
            AgregarCanal("canal5", Resolucion.BAJA, true, 130);
            AgregarCanal("canal6", Resolucion.BAJA, true, 145);
            AgregarCanal("canal7", Resolucion.ALTA, true, 150);
            AgregarCanal("canal8", Resolucion.ALTA, true, 155);
            AgregarCanal("canal9", Resolucion.BAJA, true, 160);
            AgregarCanal("canal10", Resolucion.BAJA, true, 165);
            AgregarCanal("canal11", Resolucion.ALTA, true, 170);
            AgregarCanal("canal12", Resolucion.ALTA, true, 180);
            AgregarCanal("canal13", Resolucion.BAJA, true, 180);
            AgregarCanal("canal14", Resolucion.ALTA, true, 181);
            AgregarCanal("canal15", Resolucion.ALTA, true, 182);
            AgregarCanal("canal16", Resolucion.BAJA, true, 183);
            AgregarCanal("canal17", Resolucion.BAJA, true, 184);
            AgregarCanal("canal18", Resolucion.ALTA, true, 185);
            AgregarCanal("canal19", Resolucion.ALTA, true, 186);
            AgregarCanal("canal20", Resolucion.BAJA, true, 180);
            AgregarCanal("canal21", Resolucion.BAJA, true, 180);
            AgregarCanal("canal22", Resolucion.ALTA, true, 1950);
            AgregarCanal("canal23", Resolucion.ALTA, true, 196);
            AgregarCanal("canal24", Resolucion.BAJA, true, 112);
            AgregarCanal("canal25", Resolucion.BAJA, true, 113);
            AgregarCanal("canal26", Resolucion.ALTA, true, 114);
            AgregarCanal("canal27", Resolucion.ALTA, true, 180);
            AgregarCanal("canal28", Resolucion.BAJA, true, 116);
            AgregarCanal("canal29", Resolucion.BAJA, true, 180);
            AgregarCanal("canal30", Resolucion.ALTA, true, 180);
            AgregarCanal("canal31", Resolucion.ALTA, true, 117);
            AgregarCanal("canal32", Resolucion.BAJA, true, 118);
            AgregarCanal("canal33", Resolucion.BAJA, true, 119);
            AgregarCanal("canal34", Resolucion.ALTA, true, 132);
            AgregarCanal("canal35", Resolucion.ALTA, true, 133);
            AgregarCanal("canal36", Resolucion.BAJA, true, 134);
            AgregarCanal("canal37", Resolucion.BAJA, true, 180);
            AgregarCanal("canal38", Resolucion.ALTA, true, 180);
            AgregarCanal("canal39", Resolucion.ALTA, true, 180);
            AgregarCanal("canal40", Resolucion.BAJA, true, 180);
            AgregarCanal("canal41", Resolucion.BAJA, true, 180);
            AgregarCanal("canal42", Resolucion.ALTA, true, 180);
            AgregarCanal("canal43", Resolucion.ALTA, true, 180);
            AgregarCanal("canal44", Resolucion.BAJA, true, 180);
            AgregarCanal("canal45", Resolucion.BAJA, true, 135);
            AgregarCanal("canal46", Resolucion.ALTA, true, 136);
            AgregarCanal("canal47", Resolucion.ALTA, true, 137);
            AgregarCanal("canal48", Resolucion.BAJA, true, 188);
            AgregarCanal("canal49", Resolucion.BAJA, true, 139);
            AgregarCanal("canal50", Resolucion.BAJA, true, 184);
        }

        /// <summary>
        /// asociar canales existentes a paquetes
        /// </summary>
        /// <returns></returns>
        public string PrecargaCanalesAPaquetes()
        {
            string errores = "";
            Paquete auxPaq1 = BuscarPaquete("paqueteHD1");
            auxPaq1.IngresarCanal(BuscarCanal("canal3"));
            auxPaq1.IngresarCanal(BuscarCanal("canal4"));
            auxPaq1.IngresarCanal(BuscarCanal("canal7"));
            auxPaq1.IngresarCanal(BuscarCanal("canal8"));
            if (!auxPaq1.IngresarCanal(BuscarCanal("canal9")))
            { //No se debe agregar un canal de resolucion BAJA a un paquete de resolcuion ALTA
                errores += "ERROR AL INGRESAR UN CANAL\n";
            }
            Paquete auxPaq2 = BuscarPaquete("paqueteSD1");
            auxPaq2.IngresarCanal(BuscarCanal("canal1"));
            auxPaq2.IngresarCanal(BuscarCanal("canal2"));
            return errores;

        }

        /// <summary>
        /// dado un nombre resolucion, multilenguaje y precio crea un canal nuevo y lo agrega a la lista de canales
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="resolucion"></param>
        /// <param name="multilenguaje"></param>
        /// <param name="precio"></param>
        /// <returns></returns>
        public Canal AgregarCanal(string nombre, Resolucion resolucion, bool multilenguaje, decimal precio)
        {
            Canal unC = null;
            if (Canal.ValidarNombre(nombre) && Canal.ValidarPrecio(precio) && BuscarCanal(nombre) == null)
            {
                unC = new Canal(nombre, resolucion, multilenguaje, precio);
                Canales.Add(unC);
            }

            return unC;
        }


        /// <summary>
        /// agregar una nueva instancia de paquete hd al sistema
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="promocion"></param>
        /// <param name="precioBase"></param>
        /// <param name="grabacionNube"></param>
        /// <param name="canales"></param>
        /// <returns></returns>
        public PaqueteHD AgregarPaqueteHD(string nombre, bool promocion, decimal precioBase, bool grabacionNube, List<Canal> canales)
        {
            PaqueteHD unP = null;
            if (BuscarPaquete(nombre) == null)
            {
                unP = new PaqueteHD(nombre, promocion, precioBase, canales, grabacionNube);
                Paquetes.Add(unP);
            }

            return unP;
        }

        /// <summary>
        /// agregar una nueva instancia de paquete sd al sistema
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="promocion"></param>
        /// <param name="precioBase"></param>
        /// <param name="mejoraImagen"></param>
        /// <param name="canales"></param>
        /// <returns></returns>
        public PaqueteSD AgregarPaqueteSD(string nombre, bool promocion, decimal precioBase, bool mejoraImagen, List<Canal> canales)
        {
            PaqueteSD unP = null;
            if (BuscarPaquete(nombre) == null)
            {
                unP = new PaqueteSD(nombre, promocion, precioBase, canales, mejoraImagen);
                Paquetes.Add(unP);
            }

            return unP;
        }

        //COMPRAS

        public decimal TotalCompras()
        {
            decimal res = 0;
            foreach (var c in Compras)
            {
                res += c.GetTotalCompra();
            }
            return res;
        }

        public decimal TotalCompras(DateTime start, DateTime end)
        {
            decimal res = 0;
            foreach (var c in Compras)
            {
                if (c.Fecha >= start && c.Fecha <= end)
                {
                    res += c.GetTotalCompra();
                }
            }
            return res;
        }



        /// <summary>
        /// Agregar una nueva compra a un usuario existente
        /// </summary>
        /// <param name="username"></param>
        /// <param name="fechaVencimiento"></param>
        /// <param name="cancelada"></param>
        /// <returns></returns>
        public Compra AgregarNuevaCompra(string username,DateTime date,List<string> paquetes)
        {
            User user = BuscarUsuario(username);
            // usuario debe existir
            if (user != null) {
                List<Paquete> paquetesAux = new List<Paquete>();
                foreach (string nombrePaquete in  paquetes)
                {
                    Paquete paquete1 = BuscarPaquete(nombrePaquete);
                    paquetesAux.Add(paquete1);
                }

                Compra nuevaCompra = new Compra(date, false, paquetesAux);
                
                //agregar compra al sistema
                Compras.Add(nuevaCompra);

                //agregar compra al usuario
                user.AgregarCompra(nuevaCompra);

                return nuevaCompra;
            }
            else
            {
                return null;
            } 
        }

        public bool ActualizarCompra(int idCompra,bool cancelada)
        {
            Compra compra = BuscarCompra(idCompra);
            if(compra != null)
            {
                compra.Cancelada = cancelada;
                return true;
            }

            return false;
        }

        /// <summary>
        /// agregar un paquete a una compra existente
        /// </summary>
        /// <param name="idCompra"></param>
        /// <param name="paquete"></param>
        /// <returns></returns>
        public Compra AgregarPaqueteCompra(int idCompra, Paquete paquete)
        {
            Compra compra = BuscarCompra(idCompra);
            if(compra!= null)
            {
                compra.AgregarPaquete(paquete);
                return compra;
            }

            return null;
        }

        private Compra BuscarCompra(int idCompra)
        {
            foreach (Compra c in Compras)
            {
                if (c.Id == idCompra)
                {
                    return c;
                }
            }
            return null;
        }


        /// <summary>
        /// retorna toda la lista de compras del sistema
        /// </summary>
        /// <returns></returns>
        public List<Compra> ListarCompras()
        {
            return Compras;
        }

        public List<Compra> ListarCompras(DateTime inicio, DateTime fin)
        {
            List<Compra> res = new List<Compra>();

            foreach (Compra compra in Compras)
            {
                if (compra.Fecha >=inicio && compra.Fecha <=fin)
                {
                    res.Add(compra);
                }
            }

            return res;
        }


        /// <summary>
        /// retorna toda la lista de paquetes del sistema
        /// </summary>
        /// <returns></returns>
        public List<Paquete> ListarPaquetes()
        {
            return Paquetes;
        }

        /// <summary>
        /// retorna toda la lista de canales del sistema
        /// </summary>
        /// <returns></returns>
        public List<Canal> ListarCanales()
        {
            return Canales;
        }

        /// <summary>
        /// lista los paquetes que tienen mayor cantidad de canales asociados
        /// </summary>
        /// <returns></returns>
        public List<Paquete> ListarPaquetesConMasCanales()
        {
            int mayor = int.MinValue;
            List<Paquete> aux = new List<Paquete>();

            foreach (Paquete item in Paquetes)
            {
                int cant = item.CantCanales();
                if (cant > mayor)
                {
                    mayor = cant;

                    aux.Clear();
                    aux.Add(item);

                }
                else if (cant == mayor)
                {
                    aux.Add(item);
                }
            }

            return aux;
        }

        /// <summary>
        /// a partir de un nobmre retorna el canal asociado
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Canal BuscarCanal(string nombre)
        {
            Canal unC = null;
            int i = 0;
            while (unC == null && i < Canales.Count)
            {
                if (Canales[i].Nombre == nombre)
                {
                    unC = Canales[i];
                }
                i++;
            }
            return unC;
        }


        /// <summary>
        /// a partir de un nombre retorna el paquete asociado
        /// </summary>
        /// <param name="nombreBuscar"></param>
        /// <returns></returns>
        public Paquete BuscarPaquete(string nombreBuscar)
        {
            Paquete unP = null;
            int i = 0;
            while (unP == null && i < Paquetes.Count)
            {
                if (Paquetes[i].Nombre == nombreBuscar)
                {
                    unP = Paquetes[i];
                }
                i++;
            }
            return unP;
        }

        /// <summary>
        /// lista los paquetes con precio mayor a "precio"
        /// </summary>
        /// <param name="precio"></param>
        /// <returns></returns>
        public List<Paquete> PaquetesMayorPrecio(decimal precioComparar)
        {
            decimal max = precioComparar;
            List<Paquete> paquetesAux = new List<Paquete>();

            foreach (Paquete paqueteAux in Paquetes)
            {
                decimal precioActual = paqueteAux.PrecioBase;

                if (precioActual > max)
                {
                    paquetesAux.Add(paqueteAux);
                }
            }
            return paquetesAux;
        }


        /// <summary>
        ///Dado el nombre de un canal obtener todos los paquetes que la incluyen.
        /// </summary>
        /// <param name="nombreCanal"></param>
        /// <returns></returns>
        public List<Paquete> CanalesEnPaquete(string nombreCanal ) 
        {
           
            List<Paquete> paquetesAux = new List<Paquete>();

            foreach (Paquete paqueteAux in Paquetes)
            {
                Canal canal = BuscarCanal(nombreCanal);
                if ( canal != null)
                {
                    if(paqueteAux.Canales.Contains(canal))
                    {
                        paquetesAux.Add(paqueteAux);
                    }
                }
            }
            
            return paquetesAux;


        }



        #endregion

    }
}
