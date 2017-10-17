using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Evernote.DataLayer;
using Evernote.DataLayer.Sql;
using Evernote.Model;

namespace Evernote.Api.Controllers
{
	/// <summary>
	/// Управление пользователями
	/// </summary>
	public class UsersController : ApiController
	{
		private const string ConnectionString = @"Data Source=106sv0013\sql2012;Initial Catalog=evernote;User ID=sa";
		private readonly IUsersRepository _usersRepository;

		public UsersController()
		{
			_usersRepository = new UsersRepository(ConnectionString, new CategoriesRepository(ConnectionString));
		}

		/// <summary>
		/// Получить пользователя по идентификатору
		/// </summary>
		/// <param name="id">Идентификатор пользователя</param>
		/// <returns></returns>
		[HttpGet]
		[Route("api/users/{id}")]
		public User Get(Guid id)
		{
			return _usersRepository.Get(id);
		}

		/// <summary>
		/// Создание пользователя
		/// </summary>
		/// <param name="user">Пользователь</param>
		/// <returns></returns>
		[HttpPost]
		[Route("api/users")]
		public User Post([FromBody] User user)
		{
			return _usersRepository.Create(user);
		}

		[HttpDelete]
		[Route("api/users/{id}")]
		public void Delete(Guid id)
		{
			_usersRepository.Delete(id);
		}

		[HttpGet]
		[Route("api/users/{id}/categories")]
		public IEnumerable<Category> GetUserCategories(Guid id)
		{
			return _usersRepository.Get(id).Categories;
		}
	}
}
