using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Entity
{
    [Table("ClassRooms")]
    public class ClassRoom : BaseEntity<long>
    {
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public ClassRoom() { }
    }
}
