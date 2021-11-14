using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.Common.Entities
{
    public class pet
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
