using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilteringInBlazor.Database.Models
{
    [Table("TodoItems")]
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}