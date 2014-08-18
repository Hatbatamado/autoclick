using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace click
{
    class Help
    {
        static string help =
            "Auto-clicker help\n"
            + "Howto:\n"
            + "1) Write the coordinates to the 'X' and 'Y' textbox or push the 'F6' key and it will detect automatically\n"
            + "2) Set a delay in ms, 1000 is the default value\n"
            + "3) Set an 'click' value, how much should the program click the same button\n"
            + "4) Click on the 'Add' or push 'F8' key to add this to the clicking list\n"
            + "5) repeat 1)-4) as much as you need\n"
            + "6) If you keep the 'Full process run' on 0 then it will keep clicking on the list items forever / until you make it stop\n"
            + "----But if you change it, then it will repeat only the times you wrote in it\n"
            + "7) By clicking on 'Start' or pushing the 'F7' key will start the clicking and pushing/clicking again will stop it\n\n"
            + "If you want to remove an clicking process from the list, then write it's No. next to the 'Delete' button and then click it\n"
            + "If you want to remove all items from the list then write * in the textbox and then click the button\n\n"
            + "If you want to save or load the process you can do it, by clicking on the appropriate button\n\n"
            + "Status while running: Current: X/Y/Z\n"
            + "X: full process number\n"
            + "Y: clicking list number\n"
            + "Z: list item 'click' number\n"
            + "All: summary of clicks\n\n"
            + "Blue 'U' button = speed up\n"
            + "Red 'D' button = speed down\n"
            + "by clicking any of these two will increase / decrease the speed of all of the processes (by ms)\n\n"
            + "'Swap' button swap the lines that number was written in the boxes next to it\n"
            + "if you write -1 in one of the boxes then line number written in the other box will be the 0th line";

        static public void Help_out()
        {
            MessageBox.Show(help, "Help");
        }
    }
}
