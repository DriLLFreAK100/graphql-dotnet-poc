using Demo.Server.Core.GraphQl.Schema;
using Demo.Server.Core.GraphQl.Types;
using Demo.Server.Core.Repository;
using Demo.Server.Core.Repository.Interface;
using Demo.Server.Core.Service;
using Demo.Server.Core.Service.Interface;
using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.Subscriptions;
using GraphQL.Server.Transports.WebSockets;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            ConfigureCors(services);
            ConfigureAppScopes(services);
            ConfigureGraphQlScopes(services);
            services
                .AddGraphQL(new GraphQLOptions()
                {
                    EnableMetrics= true,
                    ExposeExceptions = true
                })
                .AddWebSockets()
                .AddDataLoader()
                .AddGraphTypes();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        public void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .WithExposedHeaders("Content-Disposition");
                });
            });
        }

        public void ConfigureAppScopes(IServiceCollection services)
        {

            services.AddSingleton<ITransactionService, TransactionService>();
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IFeedbackService, FeedbackService>();
            services.AddSingleton<IFeedbackEventService, FeedbackEventService>();
            services.AddSingleton<ITransactionRepository, TransactionRepository>();
            services.AddSingleton<IClientRepository, ClientRepository>();
            services.AddSingleton<IFeedbackRepository, FeedbackRepository>();
        }

        public void ConfigureGraphQlScopes(IServiceCollection services)
        {
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<ClientType>();
            services.AddSingleton<FeedbackInputType>();
            services.AddSingleton<FeedbackType>();
            services.AddSingleton<FeedbackEventType>();
            services.AddSingleton<TransactionType>();
            services.AddSingleton<MonthType>();
            services.AddSingleton<TransactionCategoryType>();
            services.AddSingleton<TransactionSummaryByMonthType>();
            services.AddSingleton<ClientTransactionSummaryDtoType>();
            services.AddSingleton<DemoQuery>();
            services.AddSingleton<DemoMutation>();
            services.AddSingleton<DemoSubscription>();
            services.AddSingleton<ISchema, DemoSchema>();
            services.AddSingleton<IDependencyResolver>(d => new FuncDependencyResolver(type => d.GetRequiredService(type)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAllOrigins");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseWebSockets();
            app.UseGraphQLWebSockets<DemoSchema>("/graphql");

            app.UseGraphiQLServer(new GraphiQLOptions()
            {
                GraphiQLPath = "/graphiql",
                GraphQLEndPoint = "/graphql"
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
