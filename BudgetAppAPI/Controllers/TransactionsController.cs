﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YabaAPI.Models;
using YabaAPI.Repositories;

namespace YabaAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TransactionsController : ControllerBase
	{
		private readonly DataContext _context;

		public TransactionsController(DataContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult Create([FromBody] Transaction transaction)
		{
			try
			{
				_context.Transactions.Add(transaction);
				_context.SaveChanges();

				return Ok();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_context.Transactions.ToList());
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			try
			{
				return Ok(_context.Transactions.Find(id));
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var transaction = _context.Transactions.Find(id);
				_context.Transactions.Remove(transaction);
				_context.SaveChanges();

				return Ok();
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] Transaction newTransaction)
		{
			try
			{
				var transaction = _context.Transactions.Find(id);
				transaction.Origin = newTransaction.Origin;
				transaction.Date = newTransaction.Date;
				transaction.Amount = newTransaction.Amount;

				_context.Transactions.Update(transaction);
				_context.SaveChanges();

				return Ok();
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
	/* NOTES:
	 - Most parsers use ISO 8601 (talking about dates: 2020-01-01T17:16:40)
	 - Return types
		https://docs.microsoft.com/pt-br/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.accepted?view=aspnetcore-3.1
	 */
}