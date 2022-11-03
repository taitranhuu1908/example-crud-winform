using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Entity
{
    public abstract class BaseEntity<T> : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        object IEntity.Id
        {
            get { return Id; }
            set { }
        }

        [Required]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
