#include "stm32f10x.h"
#include "led.h"

int main(void)
{
  LED_Init();
	while(1)
	{
		
		//GPIO_ResetBits(GPIOC,GPIO_Pin_13);
		GPIO_SetBits(GPIOC,GPIO_Pin_13);
		
	}
	
}
