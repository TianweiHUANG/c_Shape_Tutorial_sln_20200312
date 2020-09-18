#include "stm32f10x.h"

void KEY_init(void)
{
    GPIO_InitTypeDef GPIO_InitStructure;   //定义GPIO结构体变量
 
    RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA, ENABLE);   //使能GPIOA的时钟
	
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_12;   //配置GPIO第12引脚
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;   //配置GPIO为上拉输入
	  GPIO_InitStructure.GPIO_Speed=GPIO_Speed_50MHz;   //配置GPIO速率
    GPIO_Init(GPIOA, &GPIO_InitStructure);   //GPIO初始化函数
}
