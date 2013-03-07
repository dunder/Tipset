using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tipset.WebApi.Dto;

namespace RavenDb.Repository
{
    public class TodoRepository
    {
        List<Todo> todos = new List<Todo>();

        public List<Todo> GetByIds(long[] ids)
        {
            return todos.Where(x => ids.Contains(x.Id)).ToList();
        }

        public List<Todo> GetAll()
        {
            return todos;
        }

        public Todo Store(Todo todo)
        {
            var existing = todos.FirstOrDefault(x => x.Id == todo.Id);
            if (existing == null)
            {
                var newId = todos.Count > 0 ? todos.Max(x => x.Id) + 1 : 1;
                todo.Id = newId;
            }
            todos.Add(todo);
            return todo;
        }

        public void DeleteByIds(params long[] ids)
        {
            todos.RemoveAll(x => ids.Contains(x.Id));
        }
    }
}