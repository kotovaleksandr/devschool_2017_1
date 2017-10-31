using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Evernote.Model;

namespace Evernote.WinForms
{
	internal class ServiceClient
	{
		private readonly HttpClient _client;

		public ServiceClient(string connectionString)
		{
			_client = new HttpClient();
			_client.BaseAddress = new Uri(connectionString);
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public User CreateUser(User user)
		{
			user = _client.PostAsJsonAsync("users", user).Result.Content.ReadAsAsync<User>().Result;
			return user;
		}
	}
}
