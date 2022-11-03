using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Entity
{
    [Table("Students")]
    public class Student : BaseEntity<long>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public long ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public Student() { }
    }
}
