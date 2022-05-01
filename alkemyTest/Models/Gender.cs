using System;
using System.Collections.Generic;

namespace alkemyTest.Models
{
    public class Gender 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Img { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<MovieSerie> MovieAssociated { get; set; }



    }

}

