﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevSearch.Models;
using System.Data.Entity;
using System.Web;

namespace DevSearch.Repository
{
	public class Repository<T>: IRepository<T> where T : class
	{
		private FavoriteContext db;
		private DbSet<T> dbSet;

		public Repository()
		{
			db = new FavoriteContext();
			dbSet = db.Set<T>();
		}
		public IEnumerable<T> GetAll()
		{
			return dbSet.ToList();
		}

		public T GetById( object Id )
		{
			return dbSet.Find(Id);
		}

		public void Insert( T obj )
		{
			dbSet.Add(obj);
		}
		public void Update( T obj )
		{
			db.Entry(obj).State = EntityState.Modified;
		}
		public void Delete( object Id )
		{
			T getObjById = dbSet.Find(Id);
			dbSet.Remove(getObjById);
		}
		public void Save()
		{
			db.SaveChanges();
		}
		protected virtual void Dispose( bool disposing )
		{
			if (disposing)
			{
				if (this.db != null)
				{
					this.db.Dispose();
					this.db = null;
				}
			}
		}
	}
}
