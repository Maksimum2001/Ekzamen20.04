using MyLibrary;
using System;
using System.Collections.Generic;

namespace MyLibrary
{
    public class Application
    {
        public Application application;
        public List<TaskList> tasklist;

        public Application()
        {
            tasklist = new List<TaskList>();
        }
        
        /// <summary>
        /// возвращает ссылку на экземпляр приложения, а в его отсутствие создает экземпляр
        /// </summary>
        /// <returns></returns>
        public Application GetApplication()
        {
            if (application == null)
                return new Application();

            return application;
        }
        
        /// <summary>
        /// Создает список задач 
        /// </summary>
        /// <param name="name"></param>
        public void CreateTaskList(string name)
        {
            tasklist.Add(new TaskList(name));
        }

        /// <summary>
        /// возвращает имена списков задач
        /// </summary>
        /// <returns></returns>
        public List<string> GetTaskListNames()
        {
            if (tasklist == null)
                return null;

            List<string> taskListNames = new List<string>();

            foreach (TaskList task in tasklist)
            {
                taskListNames.Add(task.Name);
            }

            return taskListNames;
        }

        /// <summary>
        /// возвращает список задач по имени списка
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TaskList GetTaskByName(string name)
        {
            TaskList taskList = tasklist.Find(t => t.Name == name);
            return taskList;
        }

        /// <summary>
        /// получает задачи запланированные на сегодня
        /// </summary>
        /// <returns></returns>
        public List<Task> GetTasksByToday()
        {
            List<Task> tasksByToday = new List<Task>();

            foreach (TaskList taskList in tasklist)
            {
                tasksByToday.AddRange(taskList.GetTasksByToday());
            }

            return tasksByToday;
        }

        /// <summary>
        /// получает задачи запланированные на завтра и последующие дни
        /// </summary>
        /// <returns></returns>
        public List<Task> GetTasksByFuture()
        {
            List<Task> tasksByFuture = new List<Task>();

            foreach (TaskList taskList in tasklist)
            {
                tasksByFuture.AddRange(taskList.GetTasksByFuture());
            }

            return tasksByFuture;
        }
    }
}
