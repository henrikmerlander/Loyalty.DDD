﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Seedwork;
using Domain.WalletAggregate;
using Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class LoyaltyContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "loyalty";
        public DbSet<Wallet> Wallets { get; set; }

        private readonly IMediator _mediator;

        private LoyaltyContext(DbContextOptions<LoyaltyContext> options) : base(options) { }

        public LoyaltyContext(DbContextOptions<LoyaltyContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WalletEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync();

            return true;
        }
    }
}
