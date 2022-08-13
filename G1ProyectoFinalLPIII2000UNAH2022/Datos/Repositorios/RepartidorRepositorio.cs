using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;
using Dapper;

namespace Datos.Repositorios
{
    public class RepartidorRepositorio : IRepartidorRepositorio
    {
        private string CadenaConexion;

        public RepartidorRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<bool> Actualizar(Repartidor repartidor)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"UPDATE Repartidor SET  Nombre = @Nombre , Clave = @Clave, EstaActivo=@EstaActivo
                                 WHERE CodigoRepartidor=@CodigoRepartidor;";

                result = Convert.ToBoolean(await conexion.ExecuteAsync(sql, repartidor));

            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<bool> Eliminar(Repartidor repartidor)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"DELETE  FROM Repartidor WHERE CodigoRepartidor = @CodigoRepartidor;";
                result = Convert.ToBoolean(await conexion.ExecuteAsync(sql, new { repartidor.CodigoRepartidor }));

            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<IEnumerable<Repartidor>> GetLista()
        {
            IEnumerable<Repartidor> lista = new List<Repartidor>();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"SELECT * FROM Repartidor;";
                lista = await conexion.QueryAsync<Repartidor>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public async Task<Repartidor> GetPorCodigo(string CodigoRepartidor)
        {
            Repartidor rep = new Repartidor();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @" SELECT * FROM Repartidor WHERE CodigoRepartidor = @CodigoRepartidor;";
                rep = await conexion.QueryFirstAsync<Repartidor>(sql, new { CodigoRepartidor });
            }
            catch (Exception)
            {
            }
            return rep;
        }

        public async Task<bool> Nuevo(Repartidor repartidor)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO Repartidor (CodigoRepartidor, Nombre, Clave, EstaActivo) 
                                 VALUES (@CodigoRepartidor, @Nombre, @Clave, @EstaActivo);";

                result = Convert.ToBoolean(await conexion.ExecuteAsync(sql, repartidor));

            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
