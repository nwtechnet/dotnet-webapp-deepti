﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevSearch.Repository
{
	public interface IRepository<T> where T: class
	{
		IEnumerable<T> GetAll();
		T GetById( object Id );
		void Insert( T obj );
		void Update( T obj );
		void Delete( Object Id );
		void Save();
	}
}
