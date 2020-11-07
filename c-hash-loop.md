---
C# | Podstawy
---

# 1. Podstawy

Pętla **while**

```c#
Console.Write("i: ");
int end = int.Parse(Console.ReadLine());
int i = 0;
while(i < end)
{
  Console.Write(i + " ");
  i++;
}
```
Pętla **do ... while**

```c#
do
{
  Console.Write(i + " ");
  i++;
}
while(i < 10) 
```

Pętla **for**

```c#
for(int i = 0; i < 10; i++) 
{
  if(i == 3) break;
  Console.Write(i + " ");
}
```

Program, który wypisze liczby od 100 do podanej przez użytkownika liczby.

```c#
Console.Write("End: ");
int end = int.Parse(Console.ReadLine());

if(end < 100)
{
  for(int i = 100; i >= end; i--) Console.Write(i + " ");
}
else 
{
  for(int i = 100; i <= end; i++)  Console.Write(i + " ");
}
```
## Zadanie 1

Poniższy program pobiera od urzytkownika długośc tablicy. Następnie pobiera wszystkie jej elementy, na samym końcu je wypisuje. 

```c#
Console.Write("Length: ");
int n = int.Parse(Console.ReadLine());
  
double[] arr = new double[n];

for(int i = 0; i < n; i++)
{
  Console.Write("Element[" + i + "]: ");
  arr[i] = double.Parse(Console.ReadLine());
}

// TODO: 

Console.Write("Output:");
for(int i = 0; i < n; i++)
{
  Console.Write(" " + arr[i]);
}
```

Pierzym krokiem będzie pobranie operacji arytmentycznej podanej przez użytkownika (`+`, `-`, `*`, `/`) oraz liczby z kają ta operacja ma być wykonana.

Opracj ma być wykonana na wszystkich elementach tablicy podanej przez użytkownika. Przykładowo dla dodawania:

```c#
for(int i = 0; i < n; i++) arr[i] += y
```

Gdzie `y` jest liczbą podaną przez użytkownika. Kolejnym krokiem będzie zmiana sposobu wprowadzania liczb przez użytkownika. Użytkownik poda łańcuch liczb oddzielonych spacjami. Przykładowo.

    12 45 56.5 8 94

Naszym zadaniem będzie przkształcenie tego łańcucha znaków na tablicę typu double.

```c#
{ 12 45 56.5 8 94 }
```

## Zadanie 2
<s>Napisać program, który wylicza wypisuje liczby pierwsze od 2 do podanej przez użytkownika liczby.</s>

Program wypisujący liczby peirwsze:

```c#
Console.Write("End: ");

int end = int.Parse(Console.ReadLine());
bool flag;

for(int i = 1; i <= end; i++)
{
  c = true;
  for (int j = 2; j <= Math.Sqrt(i); j++)
  {
    if(i % j == 0)
    {
      flag = false;
      break;
    }
  }
  if(flag == true) Console.Write(i + " ");
}
```
Program taki jest dość wolny podczas szukania bardzo dużych liczb pierwszych. Dlatego, żeby go przyspieszyć będziemy zapisywać znalezione liczby pierwsze i sprawdzać dzielenie tylko przez liczby z tablicy. Ponieważ gdy liczba nie dzieli się przez wszystkie mniejsze od niej liczy pierwsze to tym bardziej nie dzieli się przez ich wielokrotności. Do dzieła!