#include "stm32f10x.h"

void KEY_init(void)
{
    GPIO_InitTypeDef GPIO_InitStructure;   //����GPIO�ṹ�����
 
    RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA, ENABLE);   //ʹ��GPIOA��ʱ��
	
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_12;   //����GPIO��12����
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;   //����GPIOΪ��������
	  GPIO_InitStructure.GPIO_Speed=GPIO_Speed_50MHz;   //����GPIO����
    GPIO_Init(GPIOA, &GPIO_InitStructure);   //GPIO��ʼ������
}
