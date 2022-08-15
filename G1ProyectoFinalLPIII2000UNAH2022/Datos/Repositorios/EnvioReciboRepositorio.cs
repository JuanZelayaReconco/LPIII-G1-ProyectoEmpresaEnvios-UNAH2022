using Dapper;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class EnvioReciboRepositorio : IEnvioReciboRepositorio
    {
        private string CadenaConexion;
        public EnvioReciboRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<int> Nuevo(EnvioRecibo enviorecibo)
        {
            int idEnvioRecibo = 0;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO EnvioRecibo (FechaHora, IdentidadCliente, NombreCliente, DireccionEnvio, Telefono, Costo, CodigoUsuario, CodigoRepartidor) 
                             VALUES(@FechaHora, @IdentidadCliente, @NombreCliente, @DireccionEnvio, @Telefono, @Costo, @CodigoUsuario, @CodigoRepartidor); SELECT LAST_INSERT_ID()";
                //En la anterior instrucción podemos dar enter, y que siga siendo la misma y una
                //unica instrucción sin agregar "+", al ingresar una "@" al principio después del
                //igual.
                idEnvioRecibo = Convert.ToInt32(await conexion.ExecuteScalarAsync(sql, enviorecibo));
            }
            catch (Exception)
            {
            }
            return idEnvioRecibo;
        }
    }
}
