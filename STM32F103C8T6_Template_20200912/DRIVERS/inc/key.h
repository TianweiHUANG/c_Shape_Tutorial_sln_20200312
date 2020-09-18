#ifndef _KEY_H
#define _KEY_H
 
#define USER_KEY    GPIO_ReadInputDataBit(GPIOA, GPIO_Pin_12)
 
void KEY_init(void);
 
#endif
