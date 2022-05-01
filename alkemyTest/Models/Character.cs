using System;
using System.Collections.Generic;

namespace alkemyTest.Models
{
    public class Character
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Img { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public string History { get; set; }
        public virtual ICollection<MovieSerie> MovieAssociated { get; set; }

    }

}
