namespace TFGDevopsApp1.UseCases.Contributor.Command.IntegrarTareas
{
    internal class Program
    {
        public static void Main()
        {
            VersionControlSystem vcs = new VersionControlSystem();
            List<Task> tasks = vcs.GetTasksFromIntegrarTareas();

            Console.WriteLine("Tareas disponibles desde el sistema externo:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"[{task.TaskId}] {task.Description}");
            }

            Console.WriteLine("Selecciona las tareas que deseas integrar (ingresa los números separados por comas):");
            string input = Console.ReadLine();
            string[] selectedTaskIds = input.Split(',');

            foreach (var taskId in selectedTaskIds)
            {
                if (int.TryParse(taskId, out int index) && index > 0 && index <= tasks.Count)
                {
                    tasks[index - 1].IsSelected = true;
                }
            }

            vcs.IntegrateSelectedTasks(tasks);

            Console.WriteLine("Tareas seleccionadas integradas con éxito.");
        }
    }
}
