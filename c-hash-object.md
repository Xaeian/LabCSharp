<!---
```c#
static string[] Name =
{
  "Karabin Kacper",
  "Kośnicki Aleksander",
  "Kowalski Miłosz",
  "Kubera Tadeusz",
  "Kwiatkowski Jakub",
  "Lamberski Marcin",
  "Leszczyński Wojciech",
  "Rutkowski Michał",
  "Sanecki Dawid",
  "Tylman Wojciech"
};

static void Main(string[] args)
{
  Random rng = new Random();
  int nbr = rng.Next() % Name.Length;
  Console.WriteLine(Name[nbr]);
}
```
--->

# 1. Metody / Funkcje

Umieszczanie wszystkich operacji w funkcji `Main` nie jest zbyt dobrą praktyką. Może okazać się to szczególnie słabe w przypadku dużych programów. Siadając po miesiącu (lub znacznie dłuższym czasie) do takiego kodu będziemy zmuszenie rozkminiać go od zera. Dlatego też nauka dobrych nawyków programowania strukturalnego oraz efektywne operowanie w przestrzeniach nazw tylko pozornie jest *opcjonalne* do nauczenia. W dużych firmach jest to bezwzględny wymóg, który pozwala efektywnie dzielić pracę oraz korzystać z modułów przygotowanych przez innych bez zagłębiana się w kod. Rozwój takiego kodu również jest prostszy no i… w sumie każdy pod roku samodzielnej nauki programowania zmierza w tym kierunku.

Zauważmy, że już w programach, które pisaliśmy zadeklarowaliśmy przestrzeń nazw `namespace` wewnątrz, której mamy klasę `Program`, a w niej funkcję główną `Main`. Na początek dodajmy do klasy `Program` funkcje `Sum`, która doda do siebie dwie zmienne typu `double`:

```c#
class Program
{ 
  static double Sum(double a, double b = 5)
  {
    a = a + b;
    return a;
  }

  static void Main(string[] args)
  {
    double x = 3, y = 2;
    Console.WriteLine(x + " + " + y + " = " + Sum(x, y));
  }
}
```
Przyjrzyjmy się deklaracji funkcji. Przed samą jej nazwą (`Sum`) znajduję się zmienna, którą funkcja zwróci przy pomocy słowa kluczowego `return`. Jest to oczywiście zmienna typu `double`. Podobnie jak zmienne wejściowe `a` oraz `b`, które znajdują się pomiędzy `()`. Na samym początku znajdują się przedrostki. Akurat w `c#` słowo `static` oznacza, że zmienna lub metoda widoczna jest w całej klasie. Jedynym niepokojącym aspektem jest fragment `b = 5`. W ten sposób przypisujemy zmiennym wartości domyślne, na wypadek ich nie podania podczas przywoływania funkcji - jak w poniższym przykładzie:

```c#
double x = 3;
Console.WriteLine(x + " + 5 = " + Sum(x));
```
*W innych językach `funkcja != metoda`, jednak w `c#` wszystkie funkcje są w klasach, co z automatu czyni je metodami, jednak myślę, że w przypadku tego języka używanie ciągle nazwy metoda byłaby niepotrzebną precyzją*
 
Kolejną kłodą lecącą ...., będzie 




```c#
class Program
{
  static double ArraySum(double[] ary)
  {
    double sum = 0;
    for (int i = 0; i < tab.Length; i++) sum += ary[i];
    return sum;
  }

  static string ArrayToString(double[] ary)
  {
    string str = "";
    for (int i = 0; i < array.Length; i++) str += ary[i] + " ";
    return str;
  }

  static void Main(string[] args)
  {
    double[] array = { 12, 45, 56.5, 8, 94 };
    Console.WriteLine("Array: " + ArrayToString(array));
    Console.WriteLine("Sum: " + ArraySum(array));
  }
}
```

# Hero

```c#
using System;

namespace objectx2
{
  public class Hero
  {
    public string Name;
    static int Strength;
    static int Dexterity;
    static int Intelligence;

    static void Init(int strength = 5, int dexterity = 5, int intelligence = 5)
    {
      Strength = strength;
      Dexterity = dexterity;
      Intelligence = intelligence;
    }

    public int GetStrength() { return Strength; }
    public int GetDexterity() { return Dexterity; }
    public int GetIntelligence() { return Intelligence; }

    public Hero(string name, string myclass)
    {
      Name = name;
      switch(myclass)
      {
        case "warior": Init(8, 5, 2); break;
        case "assassin": Init(3, 8, 4); break;
        case "sorcerer": Init(4, 2, 9); break;
        default: Init(); break;
      }
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Hero hero = new Hero("Edward Białykij", "sorcerer");
      Console.WriteLine(hero.Name + " Str:{0} Dex:{1} Int:{2}", hero.GetStrength(), hero.GetDexterity(), hero.GetIntelligence());
    }
  }
}
```

# Hero2 

```c#
using System;

namespace objectx2
{
  public class Rand
  {
    public int Run(int min, int max)
    {
      int range = (max - min) + 1;
      Random rng = new Random();
      return min + rng.Next() % range;
    }
  }

  public class Hero
  {
    public string Name;
    static int Strength;
    static int Dexterity;
    static int Intelligence;
    public double HP;
    public double MP;
    public static double ManaRegeneration;

    public void Init(int strength = 10, int dexterity = 10, int intelligence = 10)
    {
      Strength = strength;
      Dexterity = dexterity;
      Intelligence = intelligence;
      HP = 50 + strength;
      ManaRegeneration = intelligence / 2;
    }

    public int GetStrength() { return Strength; }
    public int GetDexterity() { return Dexterity; }
    public int GetIntelligence() { return Intelligence; }

    public Hero(string name, string myclass)
    {
      Name = name;
      switch(myclass)
      {
        case "warior": Init(16, 10, 4); break;
        case "assassin": Init(6, 16, 8); break;
        case "sorcerer": Init(8, 4, 18); break;
        default: Init(); break;
      }
    }

    public void Attack(Hero enemy)
    {
      Rand rand = new Rand();
      double damage = Strength * rand.Run(5, 10) / 10;

      if(rand.Run(0, 100) > enemy.GetDexterity())
      {
        Console.WriteLine("Bang!");
        enemy.HP -= damage;
      }
      else Console.WriteLine("Dodge!");
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      int tour = 1;

      Hero hero1 = new Hero("Edward Białykij", "sorcerer");
      Console.WriteLine(hero1.Name + " Str:{0} Dex:{1} Int:{2} HP:{3}", hero1.GetStrength(), hero1.GetDexterity(), hero1.GetIntelligence(), hero1.HP);

      Hero hero2 = new Hero("Wataszka Stefan", "assassin");
      Console.WriteLine(hero2.Name + " Str:{0} Dex:{1} Int:{2} HP:{3}", hero2.GetStrength(), hero2.GetDexterity(), hero2.GetIntelligence(), hero2.HP);

      Console.WriteLine();

      while(hero1.HP > 0 && hero2.HP > 0)
      {
        if(tour == 1) Console.WriteLine("Your Turn: " + hero1.Name);
        else Console.WriteLine("Your Turn: " + hero2.Name);

        Console.Write("1:Attack, 2:Spell, 3:LevelUp ... ");
        int opt = int.Parse(Console.ReadLine());
    
        switch(opt)
        {
          case 1:
            if(tour == 1) hero1.Attack(hero2);
            else hero2.Attack(hero1);
          break;

          case 2:
          break;

          case 3:
          break;
        }

        Console.WriteLine(hero1.Name + " Str:{0} Dex:{1} Int:{2} HP:{3}", hero1.GetStrength(), hero1.GetDexterity(), hero1.GetIntelligence(), hero1.HP);
        Console.WriteLine(hero2.Name + " Str:{0} Dex:{1} Int:{2} HP:{3}", hero2.GetStrength(), hero2.GetDexterity(), hero2.GetIntelligence(), hero2.HP);
        Console.WriteLine();

        tour++;
        if(tour > 2) tour = 1;
      }
      // atak
      // spell
      // level-up
    }
  }
}
```