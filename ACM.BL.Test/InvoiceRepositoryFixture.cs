using Moq;
using System;
using System.Collections.Generic;

namespace ACM.BL.Test
{
    public class InvoiceRepositoryFixture
    {
        public InvoiceRepositoryFixture()
        {
            var mock = new Mock<InvoiceRepository>();
            mock.Setup(x => x.Retrieve(It.Is<int>(i => i == 1))).Returns(new List<Invoice> {
                new Invoice()
                {
                    InvoiceId = 1,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2013, 6, 20),
                    DueDate = new DateTime(2013, 8,29),
                    IsPaid = null
                },
                new Invoice()
                {
                    InvoiceId = 2,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2013, 7, 20),
                    DueDate = new DateTime(2013, 8,20),
                    IsPaid = null
                },
            });

            mock.Setup(x => x.Retrieve(It.Is<int>(i => i == 2))).Returns(new List<Invoice> {
                new Invoice()
                {
                    InvoiceId = 3,
                    CustomerId = 2,
                    InvoiceDate=new DateTime(2013, 7, 25),
                    DueDate=new DateTime(2013, 8,25),
                    IsPaid=null
                },
            });

            mock.Setup(x => x.Retrieve(It.Is<int>(i => i == 3))).Returns(new List<Invoice> {
                new Invoice()
                {
                    InvoiceId = 4,
                    CustomerId = 3,
                    InvoiceDate=new DateTime(2013, 7, 1),
                    DueDate=new DateTime(2013, 9,1),
                    IsPaid=true
                },
            });

            Repository = mock.Object;
        }

        public InvoiceRepository Repository { get; }
    }
}
