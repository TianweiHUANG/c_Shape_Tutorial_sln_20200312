#ifndef   _DELAY_H
#define   _DELAY_H

#include "stm32f10x.h"
//#include "stdint.h"

void Delay(uint16_t timers);

void Delay_Init(void);
void Delay_us(uint32_t nus);
void Delay_ms(uint32_t nms);

#endif
