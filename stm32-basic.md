---
STM32 | Podstawy
---

# 1. Intro

[Repozytorium Nucleo](https://github.com/Xaeian/nucleo)

```c
#include "stm32g0xx.h"
#define delay_ms(ms) for(int i = 3203*ms; i; i--) __NOP()

int main(void)
{
  RCC->IOPENR |= (1 << 0);
  GPIOA->MODER = (1 << (2 * 5));

  while(1)
  {
    GPIOA->ODR |= (1 << 5);
    delay_ms(200);
    GPIOA->ODR &= ~(1 << 5);
    delay_ms(200);
  }
}
```

Pracując na płytkach NUCLEO dobrze jest mieć pod ręką rysunek z oznaczonymi wyprowadzeniamu.

[User manual Nucleo G0](http://www.sqrt.pl/datasheet/NUCLEO-G0.pdf#page=32)

W procesorach stm32 nie mamy wbudowanej funkcji `delay_ms` tak jak to działało w mikrokontrolerach **AVR**. Po prostu nie ma takeij potrzeby, ponieważ w procesorze Atmega328P mieliśmy 3 timery z czego w **Arduino** jeden był wykorzystywany do *nie wiem czego*. Procesory **STM32** z rodziny **G0** mamy do dyspozycji 10 timerów i jeden z nich możemy wykorzystać w celu oprogramowania funkcji `delay_ms` i takie rozwiązanie będzie znacznie bardziej dokładne i precyzyjne. Ponadto nasza funkcja niezależnie czy zostanie przerwana, czy nie, przerwa będzie trwać dokładnie tyle co zostało podane jako parametr `ms`.

[Reference manual STM32G0x1 - GPIO](http://www.sqrt.pl/datasheet/STM32G0x1.pdf#page=205)