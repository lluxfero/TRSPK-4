using System.Drawing;
using static System.Math;

/*string s;
Console.WriteLine("======Man======");
var FirstMan = new Man();
s = FirstMan.ToString();
Console.WriteLine(s);

Console.WriteLine("======Teenager======");
var FirstTeenager = new Teenager();
s = FirstTeenager.ToString();
Console.WriteLine(s);

Console.WriteLine("======Worker======");
var FirstWorker = new Worker();
s = FirstWorker.ToString();
Console.WriteLine(s);

Console.WriteLine("\nPress <Enter>");
Console.ReadLine();*/


Element e1 = new Element("First", 123);
Element e2 = new Element("Second", 456);
Element e3 = new Element("Third", 789);
ArrEl ArrEl = new ArrEl();
ArrEl.Insert(e1, e2, e3);
Console.WriteLine(ArrEl[0].ToString());
Console.WriteLine(ArrEl["Second"].ToString());
Console.WriteLine($"Sum: {ArrEl.Sum(e1, e2, e3)}");
int n1 = 0, n2 = 1;
Numbers.Swap(ref n1, ref n2);
Console.WriteLine($"Swap: {n1}, {n2}");

Console.WriteLine("====Math=====");
/*Point a = new Point(-4, -3);
Point b = new Point(-2, 3);
Point c = new Point(4, 4);
Point d = new Point(1, -1);*/
Point a = new Point(4, 0);
Point b = new Point(2, 4);
Point c = new Point(1, 1);
Point d = new Point(4, -2);
double P, S;
Numbers.GetQuadrilateralPerimeterAndArea(a, b, c, d, out P, out S);
Console.WriteLine($"Периметр: {P}; Площадь: {S}");
class Man
{
    protected string? name;
    protected int age;
    public string? Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            age = value;
        }
    }
    public Man()
    {
        SetName();
        SetAge();
    }
    public void SetName()
    {
        Console.Write("Введите имя: ");
        Name = Console.ReadLine();
        if (string.IsNullOrEmpty(Name)) throw new Exception();
    }
    public virtual void SetAge()
    {
        Console.Write("Введите возраст: ");
        string? t = Console.ReadLine();
        if (!(string.IsNullOrEmpty(t)) && Convert.ToInt32(t) >= 0) Age = Convert.ToInt32(t);
        else throw new Exception();
    }
    public override string ToString()
    {
        return $"Человек, {Name}, {Age}";
    }
}
class Teenager : Man
{
    string? school;
    public string? School
    {
        get
        {
            return school;
        }
        set
        {
            school = value;
        }
    }

    public Teenager()
    {
        SetSchool();
    }
    public void SetSchool()
    {
        Console.Write("Введите школу: ");
        School = Console.ReadLine();
    }
    public override void SetAge()
    {
        Console.Write("Введите возраст: ");
        string? t = Console.ReadLine();
        if (!(string.IsNullOrEmpty(t)) && Convert.ToInt32(t) < 19 && Convert.ToInt32(t) > 13) 
            Age = Convert.ToInt32(t);
        else throw new Exception();
    }
    public override string ToString()
    {
        return $"Подросток, {Name}, {Age}, Место учебы: {School}";
    }
}
class Worker : Man
{
    string? work;
    public string? Work
    {
        get
        {
            return work;
        }
        set
        {
            work = value;
        }
    }
    public Worker()
    {
        SetWork();
    }
    public void SetWork()
    {
        Console.Write("Введите место работы: ");
        Work = Console.ReadLine();
    }
    public override void SetAge()
    {
        Console.Write("Введите возраст: ");
        string? t = Console.ReadLine();
        if (!(string.IsNullOrEmpty(t)) && Convert.ToInt32(t) < 70 && Convert.ToInt32(t) > 16)
            Age = Convert.ToInt32(t);
        else throw new Exception();
    }
    public override string ToString()
    {
        return $"Работник, {Name}, {Age}, Место работы: {Work}";
    }
}

class Element
{
    string name;
    int val;
    public string Name 
    { 
        get
        {
            return name;
        }
        set
        {
            name = value;
        } 
    }
    public int Val
    {
        get
        {
            return val;
        }
        set
        {
            val = value;
        }
    }
    public Element(string n, int v)
    {
        name = n;
        val = v;
    }
    public override string ToString()
    {
        return $"Элемент: {Name}, {Val}";
    }

}
class ArrEl
{
    int size = 0;
    Element[] Arr;
    public ArrEl()
    {
        Arr = new Element[100];
    }
    public void Insert(params Element[] n)
    {
        foreach (Element e in n)
        {
            if (size < 100)
            {
                Arr[size] = e;
                size++;
            }
            else throw new Exception();
        }
    }
    public static int Sum(params Element[] n)
    {
        int result = 0;
        foreach (Element e in n)
        {
            result += e.Val;
        }
        return result;
    }
    public Element this[int index]
    {
        get
        {
            return Arr[index];
        }
    }
    public Element this[string name]
    {
        get
        {
            foreach (Element e in Arr)
                if (e.Name == name) return e;
            throw new Exception();
        }
    }
}
class Numbers
{
    public static void Swap(ref int n1, ref int n2)
    {
        (n1, n2) = (n2, n1);
    }
    public static (double, double) GetPositiveVector(Point a, Point b)
    {
        double x, y;
        if (a.X < b.X) x = b.X - a.X;
        else x = a.X - b.X;
        if (a.Y < b.Y) y = b.Y - a.Y;
        else y = a.Y - b.Y;
        return (x, y);
    }
    public static double GetSegmentLength(Point a, Point b)
    {
        double x, y;
        (x, y) = GetPositiveVector(a, b);
        x = Math.Pow(x, 2);
        y = Math.Pow(y, 2);
        return Math.Sqrt(y + x);
    }
    public static double FromCosToSin(double c)
    {
        return Math.Sqrt(1 - Math.Pow(c, 2));
    }
    public static double GetSegmentAngle(Point a, Point c, Point b, Point d)
    {
        double x1, y1, x2, y2;
        (x1, y1) = (a.X - c.X, a.Y - c.Y);
        (x2, y2) = (b.X - d.X, b.Y - d.Y);
        return FromCosToSin((x1 * x2 + y1 * y2) / (GetSegmentLength(a, c) * GetSegmentLength(b, d))); //скалярное произведение = длины векторов * cos угла между ними
    }
    public static bool GetQuadrilateralPerimeterAndArea(Point a, Point b, Point c, Point d, out double Perimeter, out double Area)
    {
        double A = GetSegmentLength(a, b);
        double B = GetSegmentLength(b, c);
        double C = GetSegmentLength(c, d);
        double D = GetSegmentLength(d, a); 
        Perimeter = A + B + C + D;
        double E = GetSegmentLength(a, c);
        double F = GetSegmentLength(b, d);
        Area = 0.5 * E * F * GetSegmentAngle(a, c, b, d);
        return true; 
    }
}