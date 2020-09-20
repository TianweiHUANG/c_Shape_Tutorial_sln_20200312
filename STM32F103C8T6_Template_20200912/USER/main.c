#include "stm32f10x.h"
#include "led.h"
#include "key.h"
#include "delay.h"

#include "usart.h"
#include "stdio.h"

int main(void)
{
	LED_Init();   //LED��ʼ��
	KEY_init();   //������ʼ��
	Delay_Init();   //��ʱ��ʼ��
	USART_init(9600);   //���ڳ�ʼ������ڲ���Ϊ������9600
	
//	while(1)
//	{
//		uint8_t RX_Data;   //����һ��8λ����
//		
//		GPIO_ResetBits(GPIOC,GPIO_Pin_13);   //PC13����͵�ƽ
//		Delay_ms(1000);   //500ms��ʱ
//		GPIO_SetBits(GPIOC,GPIO_Pin_13);   //PC13����ߵ�ƽ
//		Delay_ms(1000);   //500ms��ʱ
//		
//		while(USART_GetFlagStatus(USART1,USART_FLAG_RXNE)==RESET);   //�ȴ�һ�ֽ����ݽ������
//		RX_Data = USART_ReceiveData(USART1);   //�����յ���һ�ֽ����ݸ�������RX_Data
//		USART_SendData(USART1,RX_Data);   //�����յ���һ�ֽ����ݷ��͵���������
//		Delay(100);   //����ʱ
//		printf("Hello,my Printf\r\n");
//	}
	
	while(1)
	{
		if(USER_KEY == 0) 
			{
         Delay_ms(20);    //������������ʱʱ��һ��Ϊ10-20ms
         if(USER_KEY == 0) GPIO_ResetBits(GPIOC,GPIO_Pin_13);
      }
    else GPIO_SetBits(GPIOC,GPIO_Pin_13);
	}
}
