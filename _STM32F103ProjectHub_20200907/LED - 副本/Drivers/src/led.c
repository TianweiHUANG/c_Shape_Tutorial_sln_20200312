#include "stm32f10x_rcc.h"
#include "stm32f10x_gpio.h"

void LED_Init(void)
{
	
	GPIO_InitTypeDef GPIO_initstruct;

	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOC, ENABLE);  //打开GPIOC的时钟
	
	GPIO_initstruct.GPIO_Mode = GPIO_Mode_Out_PP;					 //设置为推挽输出模式
	GPIO_initstruct.GPIO_Pin = GPIO_Pin_13;                //初始化Pin13
	GPIO_initstruct.GPIO_Speed = GPIO_Speed_50MHz;				 //承载的最大频率
	GPIO_Init(GPIOC, &GPIO_initstruct);										 //初始化GPIOC
	
	GPIO_SetBits(GPIOC,GPIO_Pin_13);

}
