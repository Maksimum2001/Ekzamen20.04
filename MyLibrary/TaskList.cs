using MyLibrary;
using System;
using System.Collections.Generic;

namespace MyLibrary
{
    public class TaskList
    {
        public string Name { get; set; }
        public List<Task> tasks { get; set; }

        public TaskList(string name)
        {
            Name = name;
        }

        /// <summary>
        /// получение имени списка задач
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return Name;
        }

        /// <summary>
        /// добавление задачи в список задач
        /// </summary>
        /// <param name="task">Задача</param>
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        /// <summary>
        /// Метод получения задач списка задач
        /// </summary>
        /// <returns></returns>
        public List<Task> GetTasks()
        {
            return tasks;
        }

        /// <summary>
        /// удаление задачи из списка задач
        /// </summary>
        /// <param name="task">Задача</param>
        public void Remove(Task task)
        {
            if (tasks.Contains(task))
            {
                tasks.Remove(task);
            }
        }

        /// <summary>
        /// получение задач на сегодня
        /// </summary>
        /// <returns></returns>
        public List<Task> GetTasksByToday()
        {
            List<Task> tasksByToday = new List<Task>();

            foreach (Task task in tasks)
            {
                if (task.Due.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    tasksByToday.Add(task);
                }
            }

            return tasksByToday;
        }

        /// <summary>
        /// получение задач на сегодня и последущие дни
        /// </summary>
        /// <returns></returns>
        public List<Task> GetTasksByFuture()
        {
            List<Task> tasksByFuture = new List<Task>();

            foreach (Task task in tasks)
            {
                if (task.Due > DateTime.Now)
                {
                    tasksByFuture.Add(task);
                }
            }

            return tasksByFuture;
        }
    }
}
