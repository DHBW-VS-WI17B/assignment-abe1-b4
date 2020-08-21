﻿using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Client.Logic.Messages
{
    public class InitStateMessage
    {
        public UserDto UserDto{ get; }

        public double YearlyBudget { get; }

        public InitStateMessage(UserDto userDto, double yearlyBudget)
        {
            UserDto = userDto;
            YearlyBudget = yearlyBudget;
        }
    }
}
