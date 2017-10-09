using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evernote.Model;

namespace Evernote.DataLayer.Sql
{
	public class CategoriesRepository : ICategoriesRepository
	{
		private readonly string _connectionString;

		public CategoriesRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public Category Create(Guid userId, string name)
		{
			using (var sqlConnection = new SqlConnection(_connectionString))
			{
				sqlConnection.Open();
				using (var command = sqlConnection.CreateCommand())
				{
					command.CommandText = "insert into categories (id, name, userid) values (@id, @name, @userid)";

					var category = new Category
					{
						Id = Guid.NewGuid(),
						Name = name
					};
					command.Parameters.AddWithValue("@userId", userId);
					command.Parameters.AddWithValue("@name", category.Name);
					command.Parameters.AddWithValue("@id", category.Id);
					command.ExecuteNonQuery();

					return category;
				}
			}
		}

		public IEnumerable<Category> GetUserCategories(Guid userId)
		{
			using (var sqlConnection = new SqlConnection(_connectionString))
			{
				sqlConnection.Open();
				using (var command = sqlConnection.CreateCommand())
				{
					command.CommandText = "select id, name from categories where userId = @userId";
					command.Parameters.AddWithValue("@userId", userId);

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return new Category
							{
								Name = reader.GetString(reader.GetOrdinal("name")),
								Id = reader.GetGuid(reader.GetOrdinal("id"))
							};
						}
					}
				}
			}
		}
	}
}
