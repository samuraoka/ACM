﻿using ACM.BL;
using System.Collections.Generic;

namespace ACM.Data
{
    public class ACMCustomerRepository : CustomerRepository
    {
        public InvoiceRepository InvoiceRepository { get; private set; }

        public ACMCustomerRepository(InvoiceRepository invoiceRepository)
        {
            InvoiceRepository = invoiceRepository;
        }

        public override IList<Customer> Retrieve()
        {
            List<Customer> custList = new List<Customer>
            {
                new Customer()
                {
                    CustomerId = 1,
                    FirstName = "Frodo",
                    LastName = "Baggins",
                    EmailAddress = "fb@hob.me",
                    CustomerTypeId = 1,
                    InvoiceList = InvoiceRepository.Retrieve(1)
                },
                new Customer()
                {
                    CustomerId = 2,
                    FirstName = "Bilbo",
                    LastName = "Baggins",
                    EmailAddress = "bb@hob.me",
                    CustomerTypeId = null,
                    InvoiceList = InvoiceRepository.Retrieve(2)
                },
                new Customer()
                {
                    CustomerId = 3,
                    FirstName = "Samwise",
                    LastName = "Gamgee",
                    EmailAddress = "sg@hob.me",
                    CustomerTypeId = 4,
                    InvoiceList = InvoiceRepository.Retrieve(3)
                },
                new Customer()
                {
                    CustomerId = 4,
                    FirstName ="Rosie",
                    LastName = "Cotton",
                    EmailAddress = "rc@hob.me",
                    CustomerTypeId = 2,
                    InvoiceList = InvoiceRepository.Retrieve(4)
                }
            };
            return custList;
        }
    }
}
