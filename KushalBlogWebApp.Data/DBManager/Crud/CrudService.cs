using Dapper;
using System.Data;
using System.Data.Common;

namespace DBManager
{
    public class CrudService<T>
    {
        public CrudService(IDatabaseFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        public CrudService()
        {
            DbFactory = DbFactoryProvider.GetFactory();
        }

        private IDatabaseFactory DbFactory { get; }
        //public Task<int> SaveAsync(T t)
        //{
        //    using (var db = DbFactory.Open())
        //    {
        //        var x = await db.GetListAsync<T>();

        //    }
        //}

        public virtual T Query(string sql, object param = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.Open();
                var result = db.Query<T>(sql, param);
                db.Close();
                return result.FirstOrDefault();
            }
        }
        public virtual IEnumerable<T> QueryAsync(string sql, object param = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.OpenAsync();
                var result = db.Query<T>(sql, param);
                db.Close();
                return result;

            }
        }
        public virtual IEnumerable<T> QueryList(string sql, object param = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.Open();
                return db.Query<T>(sql, param);
            }
        }
        public virtual IEnumerable<T> QueryListAsync(string sql, object param = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.OpenAsync();
                return db.Query<T>(sql, param);

            }
        }
        public virtual T Get(object id)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.Open();
                return db.Get<T>(id);

            }
        }
        public virtual IEnumerable<T> GetAsync(object id)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.OpenAsync();
                return db.GetAsync<T>(id);

            }
        }
        public virtual T Get(string condition, object parameters = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.Open();
                return db.Get<T>(condition, parameters);

            }
        }
        public virtual IEnumerable<T> GetAsync(string condition, object parameters = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.OpenAsync();
                return db.GetAsync<T>(condition, parameters);

            }
        }

        public virtual IEnumerable<T> GetList(object whereConditions)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.GetList<T>(whereConditions);

                }
            }
        }
        public virtual IEnumerable<T> GetListAsync(object whereConditions)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.OpenAsync();
                    return db.GetListAsync<T>(whereConditions);

                }
            }
        }

        public virtual IEnumerable<T> GetList(string conditions,
           object parameters)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.GetList<T>(conditions, parameters);

                }
            }
        }
        public virtual IEnumerable<T> GetListAsync(string conditions,
            object parameters)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.OpenAsync();
                    return db.GetListAsync<T>(conditions, parameters);
                }
            }
        }
        public virtual IEnumerable<T> GetJoinedList(string conditions,
           object parameters = null)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.OpenAsync();
                    return db.GetJoinedList<T>(conditions, parameters);

                }
            }
        }

        public virtual IEnumerable<T> GetList()
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.GetList<T>();

                }
            }
        }
        public virtual IEnumerable<T> GetListAsync()
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.OpenAsync();
                    return db.GetListAsync<T>();

                }
            }
        }

        public virtual IEnumerable<T> GetListPaged(int pageNumber, int rowsPerPage,
           int pageSize, string conditions, string orderby, object parameters = null)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.GetListPaged<T>(pageNumber, rowsPerPage, pageSize, conditions, orderby, parameters);

                }
            }
        }
        public virtual IEnumerable<T> GetListPagedAsync(int pageNumber, int rowsPerPage,
            int pageSize, string conditions, string orderby, object parameters = null)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.OpenAsync();
                    return db.GetListPagedAsync<T>(pageNumber, rowsPerPage, pageSize, conditions, orderby, parameters);

                }
            }
        }

        public virtual int? Insert(object entityToInsert)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.Insert<int?>(entityToInsert);

                }
            }
        }
        public virtual int? InsertAsync(object entityToInsert)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.OpenAsync();
                    return db.InsertAsync<int?>(entityToInsert);

                }
            }
        }

        public virtual TKey Insert<TKey>(object entityToInsert)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.Insert<TKey>(entityToInsert);

                }
            }
        }
        public virtual TKey InsertAsync<TKey>(object entityToInsert)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.OpenAsync();
                    return db.InsertAsync<TKey>(entityToInsert);

                }
            }
        }
        public virtual TKey InsertAsync<TKey>(IDbConnection db, object entityToInsert, IDbTransaction transaction, int? commandTimeout)
        {
            {

                return db.InsertAsync<TKey>(entityToInsert, transaction, commandTimeout);

            }
        }

        public virtual int Update(object entityToUpdate)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.Update(entityToUpdate);

                }
            }
        }
        public virtual int Update(IDbConnection db, object entityToUpdate, IDbTransaction transaction, int? timeout)
        {
            {

                return db.Update(entityToUpdate, transaction, timeout);


            }
        }
        public virtual int UpdateAsync(IDbConnection db, object entityToUpdate, IDbTransaction transaction, int? commandTimeout)
        {
            {

                return db.UpdateAsync(entityToUpdate, transaction, commandTimeout);


            }
        }
        public int UpdateAsync(object entityToUpdate, string condition, object paramters = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.OpenAsync();
                return db.UpdateAsync(entityToUpdate, condition, paramters);

            }
        }
        public virtual Task<bool> UpdateAsync(object entityToUpdate)
        {

            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.OpenAsync();
                db.UpdateAsync(entityToUpdate);
                return Task.FromResult(true);
            }

        }
        public virtual int Delete(T entityToDelete)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.Delete(entityToDelete);

                }
            }
        }
        public virtual int DeleteAsync(T entityToDelete)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.OpenAsync();
                    return db.DeleteAsync(entityToDelete);

                }
            }
        }
        public virtual int Delete(object id)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.Delete<T>(id);

                }
            }
        }
        public virtual int Delete(IDbConnection db, object id, IDbTransaction transaction, int? timeout)
        {

            return db.Delete(id, transaction, timeout);
        }
        public virtual int DeleteAsync(object id)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.OpenAsync();
                return db.DeleteAsync<T>(id);

            }

        }
        public virtual int DeleteAsync(IDbConnection db, object id, IDbTransaction transaction, int? timeout)
        {
            return db.DeleteAsync(id, transaction, timeout);
        }
        public virtual int Delete(int[] ids)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.Delete<T>(ids);

                }
            }
        }
        public virtual int DeleteAsync(int[] ids)
        {

            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.OpenAsync();
                return db.DeleteAsync<T>(ids);

            }

        }
        public virtual int DeleteAsync(string condition, object parameters = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.OpenAsync();
                return db.DeleteAsync<T>(condition, parameters);
            }
        }
        public virtual int DeleteAsync(IDbConnection db, IDbTransaction transaction, string condition, object parameters, int? timeout)
        {
            return db.DeleteAsync<T>(condition, parameters, transaction, timeout);
        }
        // int DeleteList(object whereConditions);
        public virtual int DeleteListAsync(object whereConditions)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.OpenAsync();
                    return db.DeleteListAsync<T>(whereConditions);

                }
            }
        }
        public virtual int DeleteListAsync(string conditions,
            object parameters = null)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.OpenAsync();
                    return db.DeleteListAsync<T>(conditions, parameters);

                }
            }
        }

        public virtual int RecordCountAsync(string conditions = "",
            object parameters = null)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.OpenAsync();
                    return db.RecordCountAsync<T>(conditions, parameters);

                }
            }
        }
        public virtual int RecordCountAsync(object whereConditions)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.OpenAsync();
                    return db.RecordCountAsync<T>(whereConditions);

                }
            }
        }

        public virtual async Task<object> GetDependents()
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return await db.GetDependents<T>();
                }
            }
        }



        public virtual int UpdateAsDeleted(object id)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.OpenAsync();
                return db.UpdateAsDeleted<T>(id);
            }
        }

        public virtual int UpdateStatusAsync(object id, object status)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.OpenAsync();
                return db.UpdateStatus<T>(id, status);
            }
        }
    }
}