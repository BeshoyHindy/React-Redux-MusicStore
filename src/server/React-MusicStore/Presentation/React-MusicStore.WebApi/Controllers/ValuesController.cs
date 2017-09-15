using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Services.Interfaces;

namespace ReactMusicStore.WebApi.Controllers
{
	public class ValuesController : ApiController
	{
		private readonly IAlbumAppService _albumAppService;
		public ValuesController(IAlbumAppService albumAppService)
		{
			_albumAppService = albumAppService;
		}
		// GET api/<controller>
		public IHttpActionResult Get()
		{
			//return new string[] { "value1", "value2" };
			var albums = _albumAppService.GetTopSellingAlbums(5).ToList();
			return Ok(albums);
		}

		// GET api/<controller>/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<controller>
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}