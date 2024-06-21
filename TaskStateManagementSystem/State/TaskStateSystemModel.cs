using TaskStateManagementSystem.State.Enum;

namespace TaskStateManagementSystem.State
{
    //Define os atributos
    public class TaskStateSystemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public StateTask State { get; set; }
    }
}
