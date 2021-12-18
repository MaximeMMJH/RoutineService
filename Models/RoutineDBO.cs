using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RoutineService.Models
{
    public class RoutineDBO
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TimesCompleted { get; set; }
        public Guid UserId { get; set; }
        public string InternalData { get; set; }
        [NotMapped]

        public List<Guid> ExerciseIds
        {
            get
            {
                return InternalData.Split(';').Select(Guid.Parse).ToList();
            }
            set
            {
                InternalData = String.Join(";", value.Select(p => p.ToString()).ToArray());
            }
        }
    }
}
