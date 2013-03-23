using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Raven.Client.Document;
using Tipset.Domain;

namespace RavenDb.Repository
{
    public class RavenRepository : IRepository
    {
        private readonly DocumentStore store;
        private readonly IDocumentSession session;

        public RavenRepository(DocumentStore store)
        {
            this.store = store;
            session = this.store.OpenSession();
        }

        public T SingleOrDefault<T>(Func<T, bool> predicate) where T : IModel
        {
            return session.Query<T>().SingleOrDefault(predicate);
        }

        public IEnumerable<T> All<T>() where T : IModel
        {
            return session.Query<T>();
        }

        public void Add<T>(T item) where T : IModel
        {
            session.Store(item);
        }

        public void Delete<T>(T item) where T : IModel
        {
            session.Delete(item);
        }

        public void Save()
        {
            session.SaveChanges();
        }
    }
}