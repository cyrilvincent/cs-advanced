using System;

namespace FormationCS.MediaEntities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double VATPrice => Price * 1.055;
        /*{
            get { return Price * 1.055; }
        }*/
    }
}
