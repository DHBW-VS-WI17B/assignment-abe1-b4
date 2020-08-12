﻿using System;
using System.Collections.Generic;
using System.Text;
using TicketStore.Server.Contracts;
using TicketStore.Server.Entities;

namespace TicketStore.Server.DataAccess
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repositoryContext;
        private ICustomerRepository _customer;
        private IEventRepository _event;
        private IPostalAddressRepository _postalAddress;
        private ITicketRepository _ticket;

        public ICustomerRepository Customer
        {
            get
            {
                if(_customer == null)
                {
                    _customer = new CustomerRepository(_repositoryContext);
                }

                return _customer;
            }
        }

        public IEventRepository Event
        {
            get
            {
                if (_event == null)
                {
                    _event = new EventRepository(_repositoryContext);
                }

                return _event;
            }
        }

        public IPostalAddressRepository PostalAddress
        {
            get
            {
                if (_postalAddress == null)
                {
                    _postalAddress = new PostalAddressRepository(_repositoryContext);
                }

                return _postalAddress;
            }
        }

        public ITicketRepository Ticket
        {
            get
            {
                if (_ticket == null)
                {
                    _ticket = new TicketRepository(_repositoryContext);
                }

                return _ticket;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
