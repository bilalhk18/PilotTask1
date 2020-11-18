using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Domain.DAL;
internal sealed class Configuration : DbMigrationsConfiguration<Domain.DAL.DomainContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = true;
    }

    protected override void Seed(Domain.DAL.DomainContext context)
    {

    }
}