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

using System.Collections.Generic;
using System.Linq;

namespace Surveys.DataTables
{
	interface IDataTable<T>
	{
		IQueryable<T> Query { get; }
		StorageAccount Account { get; }

		void EnsureExist();
		void Add(T obj);
		void Add(IEnumerable<T> objs);
		void AddOrUpdate(T obj);
		void AddOrUpdate(IEnumerable<T> objs);
		void Delete(T obj);
		void Delete(IEnumerable<T> objs);
	}
}
