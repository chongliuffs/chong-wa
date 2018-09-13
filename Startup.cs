using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesContacts.Data;
using System.ComponentModel.DataAnnotations;

namespace chong_wa {
	public class Startup {
		public IHostingEnvironment HostingEnvironment { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.AddDbContext<AppDbContext>(options =>
				options.UseInMemoryDatabase("name"));
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app) {
			app.UseMvc();
		}
	}
}



namespace RazorPagesContacts.Data {
	public class Customer {
		public int Id { get; set; }

		[Required, StringLength(100)]
		public string Name { get; set; }
	}

	public class AppDbContext : DbContext {
		public AppDbContext(DbContextOptions options) : base(options) {}

		public DbSet<Customer> Customers { get; set; }
	}
}
