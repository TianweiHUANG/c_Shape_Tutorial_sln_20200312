#ifndef _KEY_H
#define _KEY_H

#define USER_KEY    GPIO_ReadInputDataBit(GPIOA, GPIO_Pin_12)   //��PA12�ܽź궨��
//#define USER_KEY    GPIO_ReadInputDataBit(GPIOB, GPIO_Pin_12)   //��PB12�ܽź궨��
 
void KEY_init(void);
 
#endif
