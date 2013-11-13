//===============================================================================
// Microsoft patterns & practices
// Unity Application Block
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Surveys.Retries;

namespace Surveys.DataTables
{
	class DataTable<T> : StorageWithRetryPolicyFactory, IDataTable<T>
	{
		private readonly string tableName;
		private readonly StorageAccount account;

		public DataTable(StorageAccount account, IRetryPolicyFactory retryPolicyFactory)
			: this(account, retryPolicyFactory, typeof(T).Name)
		{
		}

		public DataTable(StorageAccount account, IRetryPolicyFactory retryPolicyFactory, string tableName)
			: base(retryPolicyFactory)
		{
			Trace.WriteLine(string.Format("Called constructor in DataTable with account={0}, tableName={1}", account.ConnectionString, tableName), "UNITY");
			this.account = account;
			this.tableName = tableName;
		}

		public IQueryable<T> Query
		{
			get { throw new NotImplementedException(); }
		}

		public StorageAccount Account
		{
			get
			{
				return this.account;
			}
		}

		public void EnsureExist()
		{
			Trace.WriteLine(string.Format("Checking DataTable {0} exists", tableName), "UNITY");
		}

		public void Add(T obj)
		{
			throw new NotImplementedException();
		}

		public void Add(IEnumerable<T> objs)
		{
			throw new NotImplementedException();
		}

		public void AddOrUpdate(T obj)
		{
			throw new NotImplementedException();
		}

		public void AddOrUpdate(IEnumerable<T> objs)
		{
			throw new NotImplementedException();
		}

		public void Delete(T obj)
		{
			throw new NotImplementedException();
		}

		public void Delete(IEnumerable<T> objs)
		{
			throw new NotImplementedException();
		}
	}
}
