using System.Reflection;
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.Application.Pipelines.Validation;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Abstraction;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Configurations;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Serilog.File;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using NArchitecture.Core.Localization.Resource.Yaml.DependencyInjection;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Mailing.MailKit;
using NArchitecture.Core.Security.DependencyInjection;
using Application.Services.Customers;
using Application.Services.Departments;
using Application.Services.Documents;
using Application.Services.DocumentTypes;
using Application.Services.Employees;
using Application.Services.Genders;
using Application.Services.Notifications;
using Application.Services.Offers;
using Application.Services.Regions;
using Application.Services.Requests;
using Application.Services.Sales;
using Application.Services.Settings;
using Application.Services.StatusTypes;
using Application.Services.TaskEntities;
using Application.Services.TaskStatuses;
using Application.Services.Titles;
using Application.Services.UserAddresses;
using Application.Services.UserEmails;
using Application.Services.UserPhones;
using Application.Services.RequestStatuses;
using Application.Services.OfferStatuses;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        MailSettings mailSettings,
        FileLogConfiguration fileLogConfiguration,
        ElasticSearchConfig elasticSearchConfig
    )
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>(_ => new MailKitMailService(mailSettings));
        services.AddSingleton<ILogger, SerilogFileLogger>(_ => new SerilogFileLogger(fileLogConfiguration));
        services.AddSingleton<IElasticSearch, ElasticSearchManager>(_ => new ElasticSearchManager(elasticSearchConfig));

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddYamlResourceLocalization();

        services.AddSecurityServices<Guid, int>();

        services.AddScoped<ICustomerService, CustomerManager>();
        services.AddScoped<IDepartmentService, DepartmentManager>();
        services.AddScoped<IDocumentService, DocumentManager>();
        services.AddScoped<IDocumentTypeService, DocumentTypeManager>();
        services.AddScoped<IEmployeeService, EmployeeManager>();
        services.AddScoped<IGenderService, GenderManager>();
        services.AddScoped<INotificationService, NotificationManager>();
        services.AddScoped<IGenderService, GenderManager>();
        services.AddScoped<INotificationService, NotificationManager>();
        services.AddScoped<IOfferService, OfferManager>();
        services.AddScoped<IOfferStatusService, OfferStatusManager>();
        services.AddScoped<IRegionService, RegionManager>();
        services.AddScoped<IRequestService, RequestManager>();
        services.AddScoped<IRequestStatusService, RequestStatusManager>();
        services.AddScoped<ISaleService, SaleManager>();
        services.AddScoped<ISettingService, SettingManager>();
        services.AddScoped<ISettingService, SettingManager>();
        services.AddScoped<IStatusTypeService, StatusTypeManager>();
        services.AddScoped<ITaskEntityService, TaskEntityManager>();
        services.AddScoped<ITaskStatusService, TaskStatusManager>();
        services.AddScoped<ITitleService, TitleManager>();
        services.AddScoped<IUserAddressService, UserAddressManager>();
        services.AddScoped<IUserEmailService, UserEmailManager>();
        services.AddScoped<IUserPhoneService, UserPhoneManager>();
        services.AddScoped<IUserPhoneService, UserPhoneManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
