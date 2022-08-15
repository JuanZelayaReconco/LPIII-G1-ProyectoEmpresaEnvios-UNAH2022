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
    public class DetalleEnvioRepositorio : IDetalleEnvioRepositorio
    {
        private string CadenaConexion;
        public DetalleEnvioRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<bool> Nuevo(DetalleEnvio detalleenvio)
        {
            bool insert = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO DetalleEnvio (IdEnvio, TipoServicio, FormaPago, DescripcionObjetosEnvio) 
                             VALUES(@IdEnvio,@TipoServicio, @FormaPago, @DescripcionObjetosEnvio);";
                //En la anterior instrucción podemos dar enter, y que siga siendo la misma y una
                //unica instrucción sin agregar "+", al ingresar una "@" al principio después del
                //igual.
                insert = Convert.ToBoolean(await conexion.ExecuteAsync(sql, detalleenvio));
            }
            catch (Exception)
            {
            }
            return insert;
        }
    }
}
