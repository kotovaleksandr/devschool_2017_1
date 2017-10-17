using System;
using System.Collections.Generic;
using System.Linq;
using Evernote.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evernote.DataLayer.Sql.Tests
{
	[TestClass]
	public class UsersRepositoryTests
	{
		private const string ConnectionString = @"Data Source=106sv0013\sql2012;Initial Catalog=evernote;User ID=sa";
		private readonly List<Guid> _tempUsers = new List<Guid>();

		[TestMethod]
		public void ShouldCreateUser()
		{
			//arrange
			var user = new User
			{
				Name = "test"
			};

			//act
			var repository = new UsersRepository(ConnectionString, new CategoriesRepository(ConnectionString));
			var result = repository.Create(user);

			_tempUsers.Add(user.Id);

			var userFromDb = repository.Get(result.Id);

			//asserts
			Assert.AreEqual(user.Name, userFromDb.Name);
		}

		[TestMethod]
		public void ShouldCreateUserAndAddCategory()
		{
			//arrange
			var user = new User
			{
				Name = "test"
			};
			const string category = "testCategory";

			//act
			var categoriesRepository = new CategoriesRepository(ConnectionString);
			var usersRepository = new UsersRepository(ConnectionString, categoriesRepository);
			user = usersRepository.Create(user);

			_tempUsers.Add(user.Id);

			categoriesRepository.Create(user.Id, category);
			user = usersRepository.Get(user.Id);

			//asserts
			Assert.AreEqual(category, user.Categories.Single().Name);
		}

		[TestCleanup]
		public void CleanData()
		{
			foreach (var id in _tempUsers)
				new UsersRepository(ConnectionString, new CategoriesRepository(ConnectionString)).Delete(id);
		}
	}
}
