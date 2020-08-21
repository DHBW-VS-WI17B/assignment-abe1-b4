﻿using Sharprompt;
using Sharprompt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Shared.Models;

namespace TicketStore.Client.Logic.Util
{
    public static class Ask
    {
        public static EventDto ForEventDto()
        {
            var name = Prompt.Input<string>("What is the name of the event?", null, new[] { Validators.Required(), Validators.MaxLength(256) });
            var date = Prompt.Input<DateTime>("When will the event take place (format: 21.7.1969 20:17)?", null, new[] { Validators.Required(), GreaterThanOrEqualTo(DateTime.UtcNow) });
            var location = Prompt.Input<string>("Where will the event take place?", null, new[] { Validators.Required() });
            var pricePerTicket = Prompt.Input<double>("Whats the price of one ticket (format: '1,23' for 1,23€)?", null, new[] { Validators.Required(), GreaterThanOrEqualTo(0.0) });
            var maxTicketCount = Prompt.Input<int>("How many tickets should be available for sale?", null, new[] { Validators.Required(), GreaterThanOrEqualTo(1) });
            var maxTicketsPerUser = Prompt.Input<int>("How many tickets should one user be able to buy?", null, new[] { Validators.Required(), GreaterThanOrEqualTo(1) });
            var saleStartDate = Prompt.Input<DateTime>("When should the ticket sale begin?", null, new[] { Validators.Required(), LessThan(date) });
            var saleEndDate = Prompt.Input<DateTime>("When should the ticket sale end?", null, new[] { Validators.Required(), GreaterThan(saleStartDate), LessThanOrEqualTo(date) });

            return new EventDto(name, date, location, pricePerTicket, maxTicketCount, maxTicketsPerUser, saleStartDate, saleEndDate);
        }

        public static double ForYearlyBudget()
        {
            return Prompt.Input<double>("What is your yearly budget for tickets (format: '1,23' for 1,23€)?", 0.0, new[] { Validators.Required() });
        }

        public static UserDto ForUserDto()
        {
            var userName = Prompt.Input<string>("What is your name?", null, new[] { Validators.Required(), Validators.MaxLength(64), Validators.MinLength(1) });
            var address = ForAddressDto();

            return new UserDto(userName, address);
        }

        private static AddressDto ForAddressDto()
        {
            var zipCode = Prompt.Input<string>("What is your ZIP code?", null, new[] { Validators.Required(), Validators.MaxLength(10) });
            var city = Prompt.Input<string>("Whats the name of your city?", null, new[] { Validators.Required(), Validators.MaxLength(128) });
            var street = Prompt.Input<string>("Whats the name of your street?", null, new[] { Validators.Required(), Validators.MaxLength(128) });
            var houseNumber = Prompt.Input<string>("Whats your house or apartment number?", null, new[] { Validators.Required(), Validators.MaxLength(32) });

            return new AddressDto(zipCode, city, street, houseNumber);
        }

        // custom validators (we are aware that the validators API of the Sharprompt lib is a mess...) therefore bad code below
        private static Func<object, ValidationResult> GreaterThanOrEqualTo(double value)
        {
            return input =>
            {
                double doubleVal;
                if (double.TryParse(input.ToString(), out doubleVal))
                {
                    if (doubleVal >= value)
                    {
                        return null;
                    }
                }

                return new ValidationResult($"{input} is not greater or equal to {value}");
            };
        }

        private static Func<object, ValidationResult> GreaterThanOrEqualTo(DateTime value)
        {
            return input =>
            {
                DateTime dateTimeVal;
                if (DateTime.TryParse(input.ToString(), out dateTimeVal))
                {
                    if (dateTimeVal >= value)
                    {
                        return null;
                    }
                }

                return new ValidationResult($"{input} is not greater or equal to {value}");
            };
        }

        private static Func<object, ValidationResult> GreaterThanOrEqualTo(int value)
        {
            return input =>
            {
                int intVal;
                if (int.TryParse(input.ToString(), out intVal))
                {
                    if (intVal >= (double)value)
                    {
                        return null;
                    }
                }

                return new ValidationResult($"{input} is not greater or equal to {value}");
            };
        }

        private static Func<object, ValidationResult> GreaterThan(DateTime value)
        {
            return input =>
            {
                DateTime dateTimeVal;
                if (DateTime.TryParse(input.ToString(), out dateTimeVal))
                {
                    if (dateTimeVal > value)
                    {
                        return null;
                    }
                }

                return new ValidationResult($"{input} is not greater than {value}");
            };
        }

        private static Func<object, ValidationResult> LessThanOrEqualTo(DateTime value)
        {
            return input =>
            {
                DateTime dateTimeVal;
                if (DateTime.TryParse(input.ToString(), out dateTimeVal))
                {
                    if (dateTimeVal <= value)
                    {
                        return null;
                    }
                }

                return new ValidationResult($"{input} is not less or equal to {value}");
            };
        }

        private static Func<object, ValidationResult> LessThan(DateTime value)
        {
            return input =>
            {
                DateTime dateTimeVal;
                if (DateTime.TryParse(input.ToString(), out dateTimeVal))
                {
                    if (dateTimeVal < value)
                    {
                        return null;
                    }
                }

                return new ValidationResult($"{input} is not less than {value}");
            };
        }
    }
}
