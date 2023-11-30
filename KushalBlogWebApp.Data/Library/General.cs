using Dapper;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;

namespace KushalBlogWebApp
{
    /// <summary>
    /// The general.
    /// </summary>
    public static class General
    {


        /// <summary>
        /// Prepares the dynamic parameters.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>A DynamicParameters.</returns>
        public static DynamicParameters PrepareDynamicParameters<T>(this T item)
        {
            //  var properties = item.GetType().GetProperties().Where(x => x.DeclaringType == typeof(T));
            var properties = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            //.Where(x => x.DeclaringType == typeof(T) || x.DeclaringType.IsSubclassOf(typeof(T)));
            var model = new DynamicParameters();
            foreach (PropertyInfo prop in properties)
            {
                if (prop.GetCustomAttribute<NotMappedAttribute>() != null)
                    continue;
                var val = prop.GetValue(item); model.Add(prop.Name, val);
            }
            return model;
        }



        /// <summary>
        /// Gets the sql parameters.
        /// </summary>
        public static List<SqlParameter> SqlParameters
        {
            get
            {
                return new List<SqlParameter>();
            }
        }

        /// <summary>
        /// Adds the more.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns>A DynamicParameters.</returns>
        public static DynamicParameters AddMore(this DynamicParameters parameters, string name, object value)
        {
            parameters.Add(name, value);
            return parameters;
        }




        /// <summary>
        /// Adds the more.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns>A DynamicParameters.</returns>
        public static DynamicParameters AddMore(this DynamicParameters parameters, string name, int? value)
        {
            parameters.Add(name, value);
            return parameters;
        }



        /// <summary>
        /// Adds the more.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="parseDbNull">If true, parse db null.</param>
        /// <returns><![CDATA[List<SqlParameter>]]></returns>
        public static List<SqlParameter> AddMore(this List<SqlParameter> parameters, string name, object value, bool parseDbNull = true)
        {
            if (value == null && parseDbNull)
                parameters.Add(new SqlParameter(name, DBNull.Value));
            else
                parameters.Add(new SqlParameter(name, value));
            return parameters;
        }



        /// <summary>
        /// Adds the more.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns><![CDATA[List<SqlParameter>]]></returns>
        public static List<SqlParameter> AddMore(this List<SqlParameter> parameters, string name, int? value)
        {
            var p = new SqlParameter(name, value);
            if (!value.HasValue)
                p.Value = DBNull.Value;
            parameters.Add(p);
            return parameters;
        }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        public static DynamicParameters Parameters
        {
            get
            {
                return new DynamicParameters();
            }
        }
    }
}
