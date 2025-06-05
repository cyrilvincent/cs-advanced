// See https://aka.ms/new-console-template for more information

using FormationConsole;

Console.WriteLine("Hello, World!");
var r1 = new Rectangle { Width = 3.2, Length = 2 };
var r2 = new Rectangle(3.2, 2);
var r3 = new Rectangle(width:2, length:2);
Console.WriteLine(r1.Surface);

List<Rectangle> list = new List<Rectangle>();
list.Add(r1);
list.Add(new Square(3));

var magazine = new Magazine { Id = 1, 
    Shelves = [ new Shelf { Id = 1, Diameter = 2.0, Height = 3.5 }, 
        new Shelf { Id = 1, Diameter = 2.0, Height = 3.5 }] };
