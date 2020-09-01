void u8g2Dispaly_1()
{
    //为字形和字符串绘图功能定义u8x8字体。注意：不能使用u8g2字体。
    u8g2.setFont(u8g2_font_fur20_tf);

    //描述：画一条线。第一个字符被放置在位置x和y。在显示屏上绘制字符串之前，请使用setFont分配字体。
    u8g2.drawStr(0, 23, "H");
    u8g2.drawStr(20, 23, ":");
    u8g2.drawStr(40, 23, Humidity_str);
    u8g2.drawStr(90, 23, "%");
    
    u8g2.drawStr(0, 63, "T");
    u8g2.drawStr(20, 63, ":");   
    u8g2.drawStr(40, 63, Temperature_str);   
    u8g2.drawStr(90, 63, "'C");
}
void u8g2Dispaly_2()
{
    //为字形和字符串绘图功能定义u8x8字体。注意：不能使用u8g2字体。
    u8g2.setFont(u8g2_font_ncenB14_tr);

    //描述：画一条线。第一个字符被放置在位置x和y。在显示屏上绘制字符串之前，请使用setFont分配字体。
    u8g2.drawStr(8, 24, "H");
    u8g2.drawStr(24, 24, ":");
    u8g2.setCursor(40,24);
    u8g2.print(Humidity);
    u8g2.drawStr(96, 24, "%");
    
    u8g2.drawStr(8, 56, "T");
    u8g2.drawStr(24, 56, ":");
    u8g2.setCursor(40,56);
    u8g2.print(Temperature);
    u8g2.drawCircle(96,40,2,U8G2_DRAW_ALL);
    u8g2.drawStr(98, 56, "C");
}
