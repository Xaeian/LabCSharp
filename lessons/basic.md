---
Uniwersytet Morski w Gdyni - Emilian Świtalksi
---

# 1. Console In..Out

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

Z konsoli można także pobierać tekst wprowadzony przez użytkownika. Pozwala to tworzyć nieco bardziej użytkowe aplikacje

```c#
Console.WriteLine("Jak się nazwywasz?");
string name = Console.ReadLine();
Console.WriteLine("Witaj " + age + "!");
```
Jednak sytuacja nieco się kompiluje jeżeli chcemy 


```c#
Console.WriteLine("Jak się nazwywasz?");
string name = int.Parse(Console.ReadLine());
Console.WriteLine("Your age is: " + age);
```

# 2. Switch...Case

Instrukcja `switch` stosujemy wówczas gdy chcemy przeskoczyć do odpowiedniego miejsca w kodzie oznaczonego jako `case`
w zależności od wartości jaką przyjmuje zmienna `option`.

``` c#
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

``` c#
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

Widzimy, że po każdym bloku kodu dla każdej opcji znajduje się instrukcji `break`. Instrukcja to wymusza wyjście z instrukcji 'switch', a także pętki takich jak `while`, czy `for`. Gdy byśmy lekko zmodyfikowali nasz kod moglibyśmy uzyskać efekt wypisywania dni jakie pozostały do weekendu:

``` c#
int day = 4;
switch(day)
{
  case 1:
    Console.WriteLine("Do weekendy jeszcze trzeba przeżyć poniedziałek");
  case 2:
    Console.WriteLine("Do weekendy jeszcze trzeba przeżyć wtorek");
  case 3:
    Console.WriteLine("Do weekendy jeszcze trzeba przeżyć środę");
  case 4:
    Console.WriteLine("Do weekendy jeszcze trzeba przeżyć czwartek");
  case 5:
    Console.WriteLine("Do weekendy jeszcze trzeba przeżyć piątek");
  default: 
    Console.WriteLine("Weekend trwa w najlepsze!");
}
```

# 3. Operatory arytmetyczne

Pobierzmy z konsoli zmienną `a` oraz `b`, a następnie wykonajmy operacje arytmetyczną, którą wskaże użytkownik.

Następna lekcja:
[If...Else](https://github.com/Xaeian/c-hash/blob/main/lessons/3-if-else.md)

# 4. If...Else



# 5. Typy zmiennych
