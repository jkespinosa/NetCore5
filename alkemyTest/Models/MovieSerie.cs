using System;
using System.Collections.Generic;

namespace alkemyTest.Models
{
    public class MovieSerie
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Img { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public int puntaje { get; set; }
        public virtual ICollection<MovieSerie> CharacterAssociated { get; set; }


    }

}
