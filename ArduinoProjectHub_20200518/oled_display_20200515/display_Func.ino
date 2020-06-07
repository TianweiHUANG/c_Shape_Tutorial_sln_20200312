/* *** *** *** *** *** *** display_Func *** *** *** *** *** *** */

void display_Init()
{
  display.begin(SSD1306_SWITCHCAPVCC, 0x3C);
  display.setTextColor(WHITE);//打开像素点发光
  display.clearDisplay();//清除显示
}

void display_Println()
{  
  display.setTextSize(1); //设置字体大小
  display.setCursor(35, 5);//设置显示位置
  display.println("-TonyCode-");

  display.setTextSize(2);//设置字体大小 
  display.setCursor(15, 30);//设置显示位置
  display.println("OLED TEST");

  display.display();//打开显示
}

void display_DrawBitmap()
{
  display.drawBitmap(0, 0, str1, 16, 16, 1); //绘制字符点阵数据
  display.drawBitmap(112, 0, str2, 16, 16, 1); //绘制字符点阵数据
  display.drawBitmap(0, 48, str3, 16, 16, 1); //绘制字符点阵数据
  display.drawBitmap(112, 48, str4, 16, 16, 1); //绘制字符点阵数据
  
  display.drawBitmap(32, 0, pic3, 64, 64, 1); //绘制字符点阵数据
  display.display();//打开显示
}

void display_DrawBitmap_FLOW()
{
  display.drawBitmap(0, 0, pic1, 128, 64, 1); //绘制字符点阵数据
  display.display();//打开显示
  delay(2000);
  display.clearDisplay();//清除显示
  display.drawBitmap(0, 0, pic2, 128, 64, 1); //绘制字符点阵数据
  display.display();//打开显示
  delay(2000);
  display.clearDisplay();//清除显示
}

void display_Scroll()
{
  display.startscrollright(0x00, 0x0F);
  delay(5000);
  display.stopscroll();
  display.startscrollleft(0x00, 0x0F);
  delay(1000);
  display.stopscroll();
}
