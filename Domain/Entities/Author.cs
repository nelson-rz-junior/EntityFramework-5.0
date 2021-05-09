﻿using System.Collections.Generic;

namespace EntityFramework5.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
