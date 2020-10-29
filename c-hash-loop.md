---
C# | Podstawy
---

# 1. While

```c#
Console.Write("i: ");
int i = int.Parse(Console.ReadLine());
while(i < 10) 
{
  Console.Write(i + " ");
  i++;
}
```

```c#
do
{
  Console.Write(i + " ");
  i++;
}
while(i < 10) 
```



```c#
for(int i = 0; i < 10; i++) 
{
  if(i == 3) break;
  Console.Write(i + " ");
}
```


```c#
Console.Write("koniec: ");
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

```c#
x % 5 == 0
```


## Zadanie
Napisać program, który wylicza wypisuje liczby pierwsze z podanego przedziału.