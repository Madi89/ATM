using System;
using System.Collections.Generic;
using System.Text;

namespace Geldautomat
{
    enum State_login
    { 
        CardAccepted,
        CardRejected,
        CardBlocked,
        PinNotCorrect,
        UserLoggedIn,
    }

    enum State
    {
        Starting,
        Running,
    }

    class Display_Menü
    {
        public State_login User;
        public State Mashine;

        public int remaining_Trials;
        public int trials;

        public Display_Menü()
        {
            Mashine = State.Starting;
            remaining_Trials = 3;
            trials = remaining_Trials;
            Mashine = State.Running;
            
        }
        public void CardCheck(string cardID)
        {
            if (cardID == "1874")
                User = State_login.UserLoggedIn;
            else
                User = State_login.CardRejected;
        }

        public void Pin_Input(short Input_pin)
        {

            for (int i = 1; i <= 3; i++)
            {
                if (Input_pin == 1234)
                {
                    User = State_login.UserLoggedIn;
                    remaining_Trials = trials;
                }
                else
                    remaining_Trials = trials - i;

                if (Input_pin != 1234)
                {
                    User = State_login.CardBlocked;
                }
            }
        }
    }           
}
