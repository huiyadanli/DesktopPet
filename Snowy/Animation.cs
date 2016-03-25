using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snowy
{
    class Animation 
    {
        public delegate void DelegateSetBits(Bitmap bitmap);
        DelegateSetBits QuoteSetBits = new DelegateSetBits(new Form1().SetBits);
        int blinkFrame = 0; //眨眼帧数计数

        Bitmap[] petBlink = new Bitmap[2];
        Bitmap[] pet = new Bitmap[30];
        Bitmap[] petClothes = new Bitmap[10];
        public Animation()
        {
            //初始化,载入基础图片
            pet[0] = new Bitmap(Application.StartupPath + "\\shell\\surface0000.png");
            pet[1] = new Bitmap(Application.StartupPath + "\\shell\\surface0001.png");
            pet[2] = new Bitmap(Application.StartupPath + "\\shell\\surface0002.png");
            pet[3] = new Bitmap(Application.StartupPath + "\\shell\\surface0003.png");
            pet[4] = new Bitmap(Application.StartupPath + "\\shell\\surface0004.png");
            pet[5] = new Bitmap(Application.StartupPath + "\\shell\\surface0005.png");
            pet[6] = new Bitmap(Application.StartupPath + "\\shell\\surface0006.png");
            pet[7] = new Bitmap(Application.StartupPath + "\\shell\\surface0007.png");
            pet[8] = new Bitmap(Application.StartupPath + "\\shell\\surface0008.png");
            pet[9] = new Bitmap(Application.StartupPath + "\\shell\\surface0009.png");
            petBlink[0] = new Bitmap(Application.StartupPath + "\\shell\\surface1003.png");
            petBlink[1] = new Bitmap(Application.StartupPath + "\\shell\\surface1004.png");
            petClothes[0] = new Bitmap(Application.StartupPath + "\\shell\\surface3523.png");
        }

        public void Blink()
        {
            System.Timers.Timer tBlink = new System.Timers.Timer(10000); 
            tBlink.Elapsed += new System.Timers.ElapsedEventHandler(tmrBlink_Elapsed);
            tBlink.AutoReset = false; //眨眼一次
            tBlink.Enabled = true;  
        }

        private void tmrBlink_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            if (blinkFrame < 2)
            {
                QuoteSetBits(petBlink[blinkFrame]);
                blinkFrame += 1;
            }
            else
            {
                QuoteSetBits(pet[0]);
                blinkFrame = 0;
            }
        }
    }
}