---
Uniwersytet Morski w Gdyni | C# | Podstawy
---

# 1. Intro C#

Aplikacja konsolowa umieszczona jest w pewnej przestrzeni nazw `App` związanej z naszym projektem.
Po odpaleniou aplikacji wykonywana jest funkcja `Main` umieszczona w klacie `Program`.

```c#
using System;

namespace App
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Guantanamera!");
    }
  }
}
```
Jedynym zadaniem naszej aplikacji jest wypisanie tekstu:

    "Guantanamera!"

Z konsoli można także pobierać tekst wprowadzony przez użytkownika. Pozwala to tworzyć nieco bardziej użytkowe aplikacje.

```c#
Console.Write("Jak się nazwywasz? ");
string name = Console.ReadLine();

Console.WriteLine("Witaj " + age + "!");
```
Niestety, jeżeli chcemy wykorzystać wejściowy ciąg znaków w obliczeniach to będziemy musieli oddać ją konwersji.
Dzieje się tak dlatego, że wszystko co wprowadza użytkownik początkowo traktowane jest jako 'string'.

```c#
double tax = 0.18;

Console.Write("Ile zł byś chciał zarabiać? ");
double pay = double.Parse(Console.ReadLine());

pay = pay * (1 - tax);
Console.WriteLine("Niestety po odprowadzeniu podatku zostanie ci " + pay + " zł");
```
W przypadku wyświetlenia następuje domyślna konwerersja z `int` na `string`.
W `C#` przyjęto konwencje, że konwersje związane z utratą danych trzeba wykonać ręcznie,
natomiast w przypadku, gdy nie tracimy danych konwersje wykonywane są automatycznie

Konwersje automatyczne: `char` ⟶ `int` ⟶ `long` ⟶ `double` ⟶ `string`

Konwersje ręczne: `string` ⟶ `double` ⟶ `long` ⟶ `int` ⟶ `char`

# 2. Switch...Case

Instrukcja `switch` stosujemy wówczas gdy chcemy przeskoczyć do odpowiedniego miejsca w kodzie oznaczonego jako `case`
w zależności od wartości jaką przyjmuje zmienna `option`.

```c#
switch(option) 
{
  case x:
    // option x
    break;
  case y:
    // option y
    break;
  default:
    // default options
    break;
}
```

W przykładzie w zależności od zmiennej `day` ma wyświetlić się nazwa dnia tygodnia, na który wskazuje.

```c#
int day = 4;
switch(day) 
{
  case 1:
    Console.WriteLine("Dziś jest poniedziałek");
    break;
  case 2:
    Console.WriteLine("Dziś jest wtorek");
    break;
  case 3:
    Console.WriteLine("Dziś jest środa");
    break;
  case 4:
    Console.WriteLine("Dziś jest czwartek");
    break;
  case 5:
    Console.WriteLine("Dziś jest piątek");
    break;
  case 6:
    Console.WriteLine("Dziś jest sobota");
    break;
  case 0: case 7:
    Console.WriteLine("Dziś jest niedziela");
    break;
}
```
W znacznej większości języków programowania indeksowanie zaczyna się od `0`, jednak dni tygodnia wydają się wyjątkiem, ponieważ w wielu państwach pierwszym dniem tygodnia jest niedziela. Zatem w przykładzie, zarówno dla `day == 0`, jak i dla `day == 7` zostaniemy poinformowani, że jest niedziela. Jest to możliwe ponieważ kilka `case`-ów  może prowadzić do tego samego miejsca w kodzie.

Widzimy, że po każdym bloku kodu dla każdej opcji znajduje się instrukcji `break`. Instrukcja to wymusza wyjście z instrukcji 'switch', a także pętki takich jak `while`, czy `for`. Zamiast instrukcji `break` możemy użyć `goto case`, które spowoduje przeskoczeni do odpowiedniego `case`-a

```c#
int day = 4;
switch (day)
{
  case 1:
    Console.WriteLine("Do weekendy jeszcze trzeba przeżyć poniedziałek");
    goto case 2;
  case 2:
    Console.WriteLine("Do weekendy jeszcze trzeba przeżyć wtorek");
    goto case 3;
  case 3:
    Console.WriteLine("Do weekendy jeszcze trzeba przeżyć środę");
  goto case 4;
    case 4:
    Console.WriteLine("Do weekendy jeszcze trzeba przeżyć czwartek");
    goto case 5;
  case 5:
    Console.WriteLine("Do weekendy jeszcze trzeba przeżyć piątek");
    break;
  default:
    Console.WriteLine("Weekend trwa w najlepsze!");
    break;
}
```

# 3. Operatory arytmetyczne

Pobierzmy z konsoli zmienną `x` oraz `y`, a następnie wykonajmy operacje arytmetyczną, którą wskaże użytkownik.

|   Nazwa            | Operator | Przykłady | Z przypisaniem |
|--------------------|:--------:|-----------|----------------|
| Dodawanie          | `+`      | x = x + y | x += y         |
| Odejmopwanie       | `-`      | x = x - y | x -= y         |
| Mnożenie           | `*`      | x = x * y | x *= y         |
| Dzielenie          | `/`      | x = x / y | x /= y         |
| Reszta z dzielenia | `%`      | x = x % y | x /= y         |
| Inkrementacja      | `++`     | x++       | x += 1         |
| Dekrementacja      | `--`     | x--       | x -= 1         |

```c#
Console.Write("Podaj zmienną x: ");
int x = int.Parse(Console.ReadLine());

Console.Write("Podaj zmienną y: ");
int y = int.Parse(Console.ReadLine());

Console.Write("Podaj operację jaką chcesz wykonać ['+','-','*','/']:");
string option = Console.ReadLine();

switch(option)
{
  case "+": x = x + y; break;
  case "-": x = x + y; break;
  case "*": x = x + y; break;
  case "/": x = x / y; break;
  default: 
    Console.WriteLine("Nieobsługiwana operacja!");
    return;
}

Console.WriteLine("Wynik operacji: x " + option + " y = " + x);

```
Wszystko działa OK, jednak gdy `x = 20`, a `y = 3` i wybierzemy instrukcję `'/'` naszym oczą ukaże się rezultat

    Podaj zmienną x: 20
    Podaj zmienną y: 3
    Podaj operację jaką chcesz wykonać ['+','-','*','/']: /
    Wynik operacji: x / y = 6

Dzieje się tak dla tego, że zmienne na których pracujemy są typu 'int'
Wystarczy zmienić je na `double` i problem rozwiązany

```c#
Console.Write("Podaj zmienną x: ");
double x = double.Parse(Console.ReadLine());

Console.Write("Podaj zmienną y: ");
double y = double.Parse(Console.ReadLine());
```
    Wynik operacji: x / y = 6,666666666666667

# 4. If...Else

Instrukcja `switch...case` rewelacyjnie sprawdza się przy ograniczonej liczbie opcji. W przypadku, gdy opcji jest więcej, a niekiedy jest ich nieskończenie wiele to z pomocą przychodzi konstrukcja `if...else`

```c#
if(condition)
{
  // code for condition == true
} 
else if(second-condition) 
{
  // code for second-condition == true
} 
else
{
  // another case code
}
```

W języku `C#` warunek jest operacją logiczną. W przypadku prawdy jest wykonywany, natomiast w przypadku fałszu nie. W operacjach logicznych stosujemy operatory porównania

|   Nazwa        | Operator | Przykłady |
|----------------|:--------:|-----------|
| Równy          | `==`     | x == y    |
| Różny          | `!=`     | x != y    |
| Większy        | `>`      | x > y     |
| Mniejszy       | `<`      | x < y     |
| Większy-Równy  | `>=`     | x >= y    |
| Mniejszy-Równy | `<=`     | x <= y    |

```c#
Console.Write("Ile masz lat? ");
double age = double.Parse(Console.ReadLine());

if(age > 25)
{
  Console.WriteLine("Jesteś starym waflem");
}
else
{
  Console.WriteLine("Jeszcze możesz być głupi");
}
```
Operacje porównania można negować, a także z sobą łączyć za pomocą operatorów logicznych:

|   Nazwa        | Operator | Skrót | Przykłady              | Rezultat      |
|----------------|:--------:|:-----:|------------------------|---------------|
| Suma logiczna  | `&&`     | AND   | `x > 2 && x <= 5`      | x ∈ ( 2 ; 5 〉 |
| Większy        | `\|\|`   | OR    | `x <= 2 \|\| x > 5`    | x ∈ ( 2 ; 5 〉 |
| Równy          | `!`      | NOT   | `!(x > 2 \|\| x <= 5)` | x ∈ ( 2 ; 5 〉 |

Zadaniem jakie sobie wysnaczymy będzie obliczenie wartości funkcji w zależności od podanej wartości `x` dla **przebiegu A**

| przebieg A               | przebieg B               |
|:------------------------:|:------------------------:|
| ![](./images/plot-a.png) | ![](./images/plot-b.png) |

```c#
if(x < -2)
{
  y = -0.5 * x - 3;
}
else if(x < 1)
{
  y = (4 / 3) * x + (2 / 3);
}
else
{
  y = 2;
}
```
Jedyne trzeba:
 + dopisać deklaracje zmiennych `x`, `y`
 + dodaćpobranie wartości `x` z konsoli
 + Wyświetlenie wartości `y` jako rezultat
 + Zająć się przebiegiem B