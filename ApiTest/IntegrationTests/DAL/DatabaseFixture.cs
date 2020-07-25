using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using Xunit;
using Xunit.Abstractions;

namespace Tests.IntegrationTests.DAL
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DatabaseFixture : IDisposable
         {
        //this class will backup the database before any test start and after all of the test are done, its restore the previous instance
        //any test class that use the database should use [Collection("Database collection")] attribute
        private bool _isBackup;
        private bool _doRestore;

        private  string _sqlConnectionString ;
        private  string _backupPath;//on SQL server hard drive

        public void SetBackupPath(string backupPath)
        {
            _backupPath = backupPath + @"\testDB.bak";
        }
        public void SetConnectionString(string sqlConnectionString)
        {
            _sqlConnectionString = sqlConnectionString;
        }

        public void BackupDatabase()
        {
            //backup db
            using (var connection = new SqlConnection(_sqlConnectionString))
            {
                //get Database name after 'DATABASE=' and before ';' in the connection string
                var dbName = new Regex(@"(?<=DATABASE=)[^;]*").Match(_sqlConnectionString.ToUpper()).Value;
                var queryString = $"BACKUP DATABASE {dbName} TO DISK = '{_backupPath}' WITH INIT;";
                var command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            _isBackup = true;
        }

        public void RestoreDatabaseOnDispose(bool doRestore)
        {
            _doRestore = doRestore;
        }

        public void Dispose()
        {
            if (!_isBackup || !_doRestore) return;
            //restore db
            using (var connection = new SqlConnection(_sqlConnectionString))
            {
                //get Database name after 'DATABASE=' and before ';' in the connection string
                var dbName = new Regex(@"(?<=DATABASE=)[^;]*").Match(_sqlConnectionString.ToUpper()).Value;

                var queryString = $"ALTER DATABASE {dbName} SET OFFLINE WITH ROLLBACK IMMEDIATE " +
                                     $"DROP DATABASE  {dbName} " +
                                     $"RESTORE DATABASE {dbName} FROM DISK= '{_backupPath}' WITH REPLACE ; ";
                queryString = string.Format($@"
                            declare @file_path  nvarchar(500)
                            declare @file_exists    int
                            set @file_path = '{_backupPath}'
                            exec master.dbo.xp_fileexist 
                                @file_path,
                                @file_exists output
                            IF @file_exists = 1
                            BEGIN
                               {queryString}  
                            END");

                var command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        [CollectionDefinition("Database collection Backup and Restore")]
        public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
        {
            // This class has no code, and is never created. Its purpose is simply
            // to be the place to apply [CollectionDefinition] and all the
            // ICollectionFixture<> interfaces.
        }
    }
}
