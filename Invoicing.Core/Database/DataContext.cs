﻿using Invoicing.Core.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoicing.Core
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
