using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TaskPlannerApi.Models
{
    public class TaskItem
    {
        private string _unitCode;
        public long Id { get; set; }
        public string UnitCode
        {
            get { return _unitCode; }
            set { _unitCode = value.ToUpper(); } //always force unit code to uppercase
        }
        public string Name { get; set; }
        public string Comments { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string? Secret { get; set; }
    }
}
