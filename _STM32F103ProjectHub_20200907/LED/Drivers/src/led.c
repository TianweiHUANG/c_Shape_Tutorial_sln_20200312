#include "stm32f10x_rcc.h"
#include "stm32f10x_gpio.h"

void LED_Init(void)
{
	
	GPIO_InitTypeDef GPIO_initstruct;

	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOC, ENABLE);  //��GPIOC��ʱ��
	
	GPIO_initstruct.GPIO_Mode = GPIO_Mode_Out_PP;					 //����Ϊ�������ģʽ
	GPIO_initstruct.GPIO_Pin = GPIO_Pin_13;                //��ʼ��Pin13
	GPIO_initstruct.GPIO_Speed = GPIO_Speed_50MHz;				 //���ص����Ƶ��
	GPIO_Init(GPIOC, &GPIO_initstruct);										 //��ʼ��GPIOC
	
	GPIO_SetBits(GPIOC,GPIO_Pin_13);

}
