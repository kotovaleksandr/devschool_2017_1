using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Evernote.Model;

namespace Evernote.DataLayer.Sql
{
	public class UsersRepository : IUsersRepository
	{
		private readonly string _connectionString;
		private readonly ICategoriesRepository _categoriesRepository;

		public UsersRepository(string connectionString, ICategoriesRepository categoriesRepository)
		{
			_connectionString = connectionString;
			_categoriesRepository = categoriesRepository;
		}

		public User Create(User user)
		{
			using (var sqlConnection = new SqlConnection(_connectionString))
			{
				sqlConnection.Open();
				using (var command = sqlConnection.CreateCommand())
				{
					user.Id = Guid.NewGuid();
					command.CommandText = "insert into users (id, name) values (@id, @name)";
					command.Parameters.AddWithValue("@id", user.Id);
					command.Parameters.AddWithValue("@name", user.Name);
					command.ExecuteNonQuery();
					return user;
				}
			}
		}

		public void Delete(Guid id)
		{
			using (var sqlConnection = new SqlConnection(_connectionString))
			{
				sqlConnection.Open();
				using (var command = sqlConnection.CreateCommand())
				{
					command.CommandText = "delete from users where id = @id";
					command.Parameters.AddWithValue("@id", id);
					command.ExecuteNonQuery();
				}
			}
		}

		public User Get(Guid id)
		{
			using (var sqlConnection = new SqlConnection(_connectionString))
			{
				sqlConnection.Open();
				using (var command = sqlConnection.CreateCommand())
				{
					command.CommandText = "select id, name from users where id = @id";
					command.Parameters.AddWithValue("@id", id);

					using (var reader = command.ExecuteReader())
					{
						if (!reader.Read())
							throw new ArgumentException($"Пользователь с id {id} не найден");

						var user = new User
						{
							Id = reader.GetGuid(reader.GetOrdinal("id")),
							Name = reader.GetString(reader.GetOrdinal("name"))
						};
						user.Categories = _categoriesRepository.GetUserCategories(user.Id);
						return user;
					}
				}
			}
		}
	}
}
