﻿namespace EmpresaDeliveryGodSpeed.Data
{
    public class MySQLConfiguracion
    {
        public string CadenaConexion { get; set; }
        public MySQLConfiguracion(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }
    }
}