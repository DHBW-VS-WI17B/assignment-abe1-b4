using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Server.Logic.DataAccess;
using TicketStore.Server.Logic.DataAccess.Entities;

namespace TicketStore.Server.Logic.Test.DataAccess
{
    [TestFixture]
    public class RepositoryWrapperTest
    {
        [Test]
        public async Task CreateValidEvent_CreatesEvent()
        {
            var optionBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("CreateValidEvent_CreatesEvent");
            var repositoryContext = new RepositoryContext(optionBuilder.Options);
            var repoWrapper = new RepositoryWrapper(repositoryContext);

            var newEvent = new Event
            {
                Date = DateTime.Parse("01.01.2021"),
                Location = "Suttgart",
                MaxTicketCount = 1000,
                MaxTicketsPerUser = 5,
                Name = "Hamilton Musical",
                PricePerTicket = 50.0,
                SaleDuration = TimeSpan.FromDays(14),
                SalesStartDate = DateTime.Parse("01.12.2020"),
            };

            repoWrapper.Events.Create(newEvent);
            await repoWrapper.SaveAsync();

            var savedEvent = repoWrapper.Events.FindByCondition(e => e.Location.Equals("Stuttgart")).FirstOrDefault();

            savedEvent?.Name.Should().Be(newEvent.Name);
            savedEvent?.Location.Should().Be(newEvent.Location);
            savedEvent?.MaxTicketCount.Should().Be(newEvent.MaxTicketCount);
            savedEvent?.MaxTicketsPerUser.Should().Be(newEvent.MaxTicketsPerUser);
            savedEvent?.PricePerTicket.Should().Be(newEvent.PricePerTicket);
            savedEvent?.SaleDuration.Should().Be(newEvent.SaleDuration);
            savedEvent?.SalesStartDate.Should().Be(newEvent.SalesStartDate);
            savedEvent?.Id.ToString().Should().NotBeEmpty();
        }

        [Test]
        public async Task CreateValidUser_CreatesUserAndAddress()
        {
            var optionBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("CreateValidUser_CreatesUserAndAddress");
            var repositoryContext = new RepositoryContext(optionBuilder.Options);
            var repoWrapper = new RepositoryWrapper(repositoryContext);

            var newUser = new User
            {
                IsAdmin = true,
                UserName = "Simon",
                Address = new Address
                {
                    City = "San Francisco",
                    HouseNumber = "42a",
                    Street = "Some Street",
                    ZipCode = 12345
                }
            };
            repoWrapper.Users.Create(newUser);
            await repoWrapper.SaveAsync();

            var createdUser = repoWrapper.Users.FindByCondition(u => u.UserName.Equals("Simon")).FirstOrDefault();
            var allAdresses = repoWrapper.Addresses.FindAll().ToList();

            createdUser?.Id.ToString().Should().NotBeEmpty();
            createdUser?.UserName.Should().Be(newUser.UserName);
            createdUser?.IsAdmin.Should().Be(newUser.IsAdmin);
            createdUser?.Address?.City.Should().Be(newUser.Address.City);
            createdUser?.Address?.HouseNumber.Should().Be(newUser.Address.HouseNumber);
            createdUser?.Address?.Street.Should().Be(newUser.Address.Street);
            createdUser?.Address?.ZipCode.Should().Be(newUser.Address.ZipCode);

            allAdresses?.Count.Should().Be(1);
            allAdresses.FirstOrDefault()?.City.Should().Be(newUser.Address.City);
            allAdresses.FirstOrDefault()?.HouseNumber.Should().Be(newUser.Address.HouseNumber);
            allAdresses.FirstOrDefault()?.Street.Should().Be(newUser.Address.Street);
            allAdresses.FirstOrDefault()?.ZipCode.Should().Be(newUser.Address.ZipCode);
        }

        [Test]
        public async Task CreateTicket_CreatesTicket()
        {
            var optionBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("CreateTicket_CreatesTicket");
            var repositoryContext = new RepositoryContext(optionBuilder.Options);
            var repoWrapper = new RepositoryWrapper(repositoryContext);

            var newUser = new User
            {
                IsAdmin = true,
                UserName = "Simon",
                Address = new Address
                {
                    City = "San Francisco",
                    HouseNumber = "42a",
                    Street = "Some Street",
                    ZipCode = 12345
                }
            };
            repoWrapper.Users.Create(newUser);

            var newEvent = new Event
            {
                Date = DateTime.Parse("01.01.2021"),
                Location = "Suttgart",
                MaxTicketCount = 1000,
                MaxTicketsPerUser = 5,
                Name = "Hamilton",
                PricePerTicket = 50.0,
                SaleDuration = TimeSpan.FromDays(14),
                SalesStartDate = DateTime.Parse("01.12.2020"),
            };
            repoWrapper.Events.Create(newEvent);
            await repoWrapper.SaveAsync();

            var createdUserId = repoWrapper.Users.FindByCondition(u => u.UserName.Equals("Simon")).FirstOrDefault().Id;
            var createdEventId = repoWrapper.Events.FindByCondition(e => e.Name.Equals("Hamilton")).FirstOrDefault().Id;

            var newTicket = new Ticket()
            {
                EventId = createdEventId,
                UserId = createdUserId,
                PurchaseDate = DateTime.UtcNow
            };
            repoWrapper.Tickets.Create(newTicket);
            await repoWrapper.SaveAsync();

            var ticket = repoWrapper.Tickets.FindByCondition(t => t.EventId.Equals(createdEventId) && t.UserId.Equals(createdUserId)).FirstOrDefault();

            ticket?.PurchaseDate.Should().Be(newTicket.PurchaseDate);
        }
    }
}