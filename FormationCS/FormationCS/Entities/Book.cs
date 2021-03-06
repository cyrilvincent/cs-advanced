﻿using System;
using System.Collections.Generic;

namespace FormationCS.Entities
{
    public class Book : IEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double VATPrice => Price * 1.055;
    }
}
