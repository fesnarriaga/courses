using System;
using System.Collections.Generic;

namespace BasicApp.Models
{
    public abstract class Production : Entity
    {
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        // EF Relations
        public IEnumerable<Character> Characters { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
    }

    public class Movie : Production
    {
        public int DurationInMinutes { get; set; }

        public double WorldwideBoxOfficeGross { get; set; }
    }

    public class Series : Production
    {
        public int NumberOfEpisodes { get; set; }
    }

    public class Character : Entity
    {
        public string Name { get; set; }

        // Foreign Keys
        public Guid ProductionId { get; set; }
        public Guid ActorId { get; set; }

        // EF Relations
        public Production Production { get; set; }
        public Actor Actor { get; set; }
    }

    public class Actor : Entity
    {
        public string Name { get; set; }

        // EF Relations
        public IEnumerable<Character> Characters { get; set; }
    }

    public class Rating : Entity
    {
        public string Source { get; set; }

        public int Stars { get; set; }

        // Foreign Keys
        public Guid ProductionId { get; set; }

        // EF Relations
        public Production Production { get; set; }
    }
}
