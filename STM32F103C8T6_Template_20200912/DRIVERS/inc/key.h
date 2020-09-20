#ifndef _KEY_H
#define _KEY_H

#define USER_KEY    GPIO_ReadInputDataBit(GPIOA, GPIO_Pin_12)   //读PA12管脚宏定义
//#define USER_KEY    GPIO_ReadInputDataBit(GPIOB, GPIO_Pin_12)   //读PB12管脚宏定义
 
void KEY_init(void);
 
#endif
