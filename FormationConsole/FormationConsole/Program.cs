// See https://aka.ms/new-console-template for more information

using FormationConsole;

Console.WriteLine("Hello, World!");
var r1 = new Rectangle { Width = 3.2, Length = 2 };
var r2 = new Rectangle(3.2, 2);
var r3 = new Rectangle(width:2, length:2);
Console.WriteLine(r1.Surface);
Console.WriteLine(r1.GetPerimeter());

List<Rectangle> list = new List<Rectangle>();    
list.Add(r1);
list.Add(new Square(3));

var magazine = new Magazine { Id = 1, 
    Shelves = [ new Shelf { Id = 1, Diameter = 2.0, Height = 3.5 }, 
        new Shelf { Id = 1, Diameter = 2.0, Height = 3.5 }] };

int i = 3;
Console.WriteLine($"Ton texte {i:.2f}");

Func<float, float> my_lambda = (float x) => x + 1;
Func<bool> my_empty_lambda = () => true;
Func<int, int, int> add_lambda = (int x, int y) => x + y;

List<Rectangle> rectangles = [r1, r2, r3];

var result1 = rectangles.Where(r => r.Surface > 2).OrderByDescending(r => r.Surface).ThenByDescending(r => r.Width).ToList();
var result2 = rectangles.Where(r => r.Width < 5).OrderByDescending(r => r.Surface).ThenByDescending(r => r.Width).ToList();
var result3 = result1.Intersect(result2).ToList();

Console.WriteLine(result3);
foreach (Rectangle rectangle in result3)
{
    Console.WriteLine(rectangle);
}

// Créer une liste de shelves et requeter par diameter, tri



