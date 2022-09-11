using FastMember;
using System.Data.SqlClient;
using MyContact.Core.Constants;
using MyContact.Core.DataAccess.Abstract;
using MyContact.Core.Entities;
using MyContact.Core.Utilities.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace MyContact.Core.DataAccess.Concrete.Ado.Net
{
    public class AdoRepositoryBase<TEntity> : IRepository<TEntity>,IAsyncRepository<TEntity>
        where TEntity : class, IEntity, new()

    {
        private readonly string connectionString = ConnectionString.AdoNetConnectionString;
        public void Add(TEntity entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(GetAddQuery(entity), con);
                var result = command.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Delete(TEntity entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(GetDeleteQuery(entity), con);
                var result = command.ExecuteNonQuery();
                con.Close();
            }
        }
        public TEntity Get(TEntity entity)
        {

            TEntity TEntity = new TEntity();
            Type type = typeof(TEntity);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                PropertyInfo propertyInfo = GetIdendityProperty(entity);
                SqlCommand command = new SqlCommand($"select * from {typeof(TEntity).Name}s where {propertyInfo.Name}={propertyInfo.GetValue(entity)}", con);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while ( reader.Read())
                    {
                        TEntity=Mapper.CustomMap<TEntity>(reader);
                    }
                    reader.Close();
                }
                con.Close();

            }


            return TEntity;
        }
        public void Update(TEntity entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(GetUpdateQuery(entity), con);
                var result = command.ExecuteNonQuery();
                con.Close();
            }
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            List<TEntity> listTEntity = new List<TEntity>();
            Type type = typeof(TEntity);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand($"select * from {typeof(TEntity).Name}s", con);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        listTEntity.Add(Mapper.CustomMap<TEntity>(reader));
                    }
                    reader.Close();
                }
                con.Close();

            }

            return filter != null
                  ? listTEntity.AsQueryable().Where(filter).ToList()
                  : listTEntity;
        }
        List<TEntity> IRepository<TEntity>.GetAll(Expression<Func<TEntity, bool>> filter)
        {
            List<TEntity> listTEntity = new List<TEntity>();
            Type type = typeof(TEntity);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand($"select * from {typeof(TEntity).Name}s", con);
                using (SqlDataReader reader =  command.ExecuteReader())
                {
                    while ( reader.Read())
                    {
                        listTEntity.Add(Mapper.CustomMap<TEntity>(reader));
                    }
                    reader.Close();
                }
                con.Close();

            }


           return filter != null
                ? listTEntity.AsQueryable().Where(filter).ToList()
                : listTEntity;
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        //Local Helper
        private string GetAddQuery(TEntity entity)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"insert into {entity.GetType().Name}s (");
            foreach (var property in entity.GetType().GetProperties())
            {
                if (property.Name.ToLower().IndexOf("id") != -1)
                {
                    continue;
                }
                builder.Append(property.Name + ",");

            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append(") values (");
            foreach (var property in entity.GetType().GetProperties())
            {
                if (property.Name.ToLower().IndexOf("id") != -1)
                {
                    continue;
                }
                builder.Append("'" + property.GetValue(entity) + "'" + ",");

            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append(')');
            return builder.ToString();
        }
        private string GetUpdateQuery(TEntity entity)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"update {entity.GetType().Name}s set ");
            foreach (var property in entity.GetType().GetProperties())
            {
                if (property.Name.ToLower().IndexOf("id") != -1)
                {
                    continue;
                }
                builder.Append($"{property.Name} = '{property.GetValue(entity)}',");

            }
            builder.Remove(builder.Length - 1, 1);

            PropertyInfo propertyInfo = GetIdendityProperty(entity);
            builder.Append($" where {propertyInfo.Name}={propertyInfo.GetValue(entity)}");
            return builder.ToString();
        }

        private static PropertyInfo GetIdendityProperty(TEntity entity)
        {
            PropertyInfo propertyInfo= entity.GetType().GetProperties().FirstOrDefault(x => x.Name.ToLower().IndexOf("id") != -1);
            if (propertyInfo != null)
            {
                return propertyInfo;
            }

            throw new Exception("This object does not have Idendity property");
        }

        private string GetDeleteQuery(TEntity entity)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Delete {entity.GetType().Name}s  ");
            PropertyInfo propertyInfo = GetIdendityProperty(entity);
            builder.Append($" where {propertyInfo.Name}={propertyInfo.GetValue(entity)}");
            return builder.ToString();
        }

        
    }

   
}
