using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Connections.Database
{
    public class Connection
    {
        private readonly string _connectionString;
        private readonly DbProviderFactory _providerFactory;


        public Connection(DbProviderFactory providerFactory, string connectionString)
        {
            _connectionString = connectionString;
            _providerFactory = providerFactory;

        }

        public int ExecuteNonQuery(Command command)
        {
            //créer la connexion SQL (DbConnection)
            using (DbConnection dbConnection = CreateConnection())
            {
                //créer la commande SQL (DbCommand)
                using (DbCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    dbConnection.Open();

                    //retourner le résultat de la méthode ExecuteNonQuery de l'objet de type DbCommand
                    return dbCommand.ExecuteNonQuery();
                }
            }
        }

        public object ExecuteScalar(Command command)
        {
            //créer la connexion SQL (DbConnection)
            using (DbConnection dbConnection = CreateConnection())
            {
                //créer la commande SQL (DbCommand)
                using (DbCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    dbConnection.Open();

                    object o = dbCommand.ExecuteScalar();
                    //retourner le résultat de la méthode ExecuteScalar de l'objet de type DbCommand
                    return o is DBNull ? null : o;
                }
            }
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<IDataRecord, TResult> selector)
        {
            //créer la connexion SQL (DbConnection)
            using (DbConnection dbConnection = CreateConnection())
            {
                //créer la commande SQL (DbCommand)
                using (DbCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    using (DbDataReader sqlDataReader = dbCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            yield return selector(sqlDataReader);
                        }
                    }
                }
            }
        }

        public DataTable GetDataTable(Command command)
        {
            //créer la connexion SQL (DbConnection)
            using (DbConnection dbConnection = CreateConnection())
            {
                //créer la commande SQL (DbCommand)
                using (DbCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    using (DbDataAdapter sqlDataAdapter = _providerFactory.CreateDataAdapter())
                    {
                        //créer le SqlDataAdapter
                        sqlDataAdapter.SelectCommand = dbCommand;
                        //créer la DataTable
                        DataTable dataTable = new DataTable();
                        //appeler la méthode Fill du SqlDataAdapter pour remplir la DataTable
                        sqlDataAdapter.Fill(dataTable);

                        //retourner la DataTable
                        return dataTable;
                    }
                }
            }
        }

        private DbConnection CreateConnection()
        {
            DbConnection dbConnection = _providerFactory.CreateConnection();
            dbConnection.ConnectionString = _connectionString;

            return dbConnection;
        }

        private DbCommand CreateCommand(Command command, DbConnection dbConnection)
        {
            DbCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = command.Query;
            if (command.IsStoredProcedure)
            {
                dbCommand.CommandType = CommandType.StoredProcedure;
            }

            foreach (KeyValuePair<string, object> kvp in command.Parameters)
            {
                DbParameter sqlParameter = dbCommand.CreateParameter();
                sqlParameter.ParameterName = kvp.Key;
                sqlParameter.Value = kvp.Value;
                dbCommand.Parameters.Add(sqlParameter);

                // A utiliser uniquement avec SQL Server
                // dbCommand.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }

            return dbCommand;
        }
    }
}
