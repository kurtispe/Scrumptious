namespace Scrumptious.MvcClient.Models
{
    public class BacklogViewModel
    {

        public int BacklogId { get; set; }
        public int FKSprintId { get; set; }
        public SprintViewModel Sprint { get; set; }


    }
}