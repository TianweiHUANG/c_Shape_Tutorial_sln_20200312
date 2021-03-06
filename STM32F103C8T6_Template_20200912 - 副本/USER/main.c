#include "stm32f10x.h"
#include "led.h"
#include "delay.h"

#include "usart.h"
#include "stdio.h"

int main(void)
{
	LED_Init();   //LED初始化
	Delay_Init();   //延时初始化
	USART_init(9600);   //串口初始化，入口参数为波特率9600
	
	while(1)
	{
		uint8_t RX_Data;   //定义一个8位变量
		
		GPIO_ResetBits(GPIOC,GPIO_Pin_13);   //PC13输出低电平
		Delay_ms(1000);   //500ms延时
		GPIO_SetBits(GPIOC,GPIO_Pin_13);   //PC13输出高电平
		Delay_ms(1000);   //500ms延时
		
		while(USART_GetFlagStatus(USART1,USART_FLAG_RXNE)==RESET);   //等待一字节数据接收完成
		RX_Data = USART_ReceiveData(USART1);   //将接收到的一字节数据赋给变量RX_Data
		USART_SendData(USART1,RX_Data);   //将接收到的一字节数据发送到串口助手
		Delay(100);   //粗延时
		printf("Hello,my Printf\r\n");
	}
}
