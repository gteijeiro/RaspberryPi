using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Web.Clima.Data;

namespace Web.Clima.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160614024550_firstversion")]
    partial class firstversion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web.Clima.Model.WeatherModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Humidity");

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Temperature");

                    b.HasKey("Id");

                    b.ToTable("Weather");
                });
        }
    }
}
