using System;
using System.Collections.Generic;
using System.Text;

using Todo.BL;

namespace Todo.BL
{
    public static class TodoManager
    {
        static TodoManager()
        {

        }

        public static Task GetTodo(int id)
        {
            return DAL.TodoRepository.GetTodo(id);
        }

        public static IList<Task> GetTodos()
        {
            return new List<Task>(DAL.TodoRepository.GetTodos());
        }

        public static int SaveTodo (Task item)
        {
            return DAL.TodoRepository.SavaTodo(item);
        }
    }
}
