#include "stm32f10x.h"

void KEY_init(void)
{
    GPIO_InitTypeDef GPIO_InitStruct;   //����GPIO�ṹ�����
 
	  RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA, ENABLE);   //ʹ��GPIOA��ʱ��
    //RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOB, ENABLE);   //ʹ��GPIOB��ʱ��
 
    GPIO_InitStruct.GPIO_Pin = GPIO_Pin_12;   //����GPIO��12����
    GPIO_InitStruct.GPIO_Mode = GPIO_Mode_IPU;   //����GPIOΪ��������
	  GPIO_InitStruct.GPIO_Speed=GPIO_Speed_50MHz;   //����GPIO����
    GPIO_Init(GPIOA, &GPIO_InitStruct);   //GPIO��ʼ������
}
