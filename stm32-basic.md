






 




```c
#include "stm32f10x.h"
#define _delay_ms(ms) for(delay = 10000 * ms; delay; delay--) __NOP()


int main(void)
{
  RCC->APB2ENR = RCC_APB2ENR_IOPBEN;
  GPIOB->CRL |= GPIO_CRL_MODE1_1;
  GPIOB->CRL &= ~GPIO_CRL_CNF1_0;
  volatile uint32_t delay;
    
  while(1)
  {
    GPIOB->ODR |= GPIO_ODR_ODR1;
    _delay_ms(1000);
    GPIOB->ODR &= ~GPIO_ODR_ODR1;
    _delay_ms(1000);
  }
}
```

W procesorach stm32 nie mamy wbudowanej funkcji _delay_ms tak jak to działało w mikrokontrolerach AVR. Po prostu nie ma takeij potrzeby, ponieważ w procesorze Atmega328P mieliśmy 3 timery z czego w ardruino jeden był wykorzystywany do niewiem czego. Procesory STM32 z rodziny G0 mamy do dyspozycji 10 timerów i jeden z nich możemy wykożystać w celu oprogramowania funkcji _delay_ms i takie rozwiazanie będzie znacznie bardziej dokładne i precyzyjne, ponadto nasza funkcja niezależnie czy zaostanie przerwana, czy nie przerwa będzie trwać dokładnie tyle co zostało podane jako parametr 



Przyszedł czas na zapalenie pierwszej diody.



|31|30|29|28|27|26|25|24|23|22|21|20|19|18|17|16|
|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|
|BR15|BR14|BR13|BR12|BR11|BR10|BR9|BR8|BR7|BR6|BR5|BR4<td colspan=2>BR3BR2<td colspan=2>BR1BR0
|W|W|W|W|W|W|W|W|W|W|W|W|W|W|W|W|

[Reference manual STM32G0x1 page 207](http://www.sqrt.pl/datasheet/STM32G0x1.pdf#page=207)