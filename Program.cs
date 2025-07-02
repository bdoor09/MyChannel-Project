
//last version//2023-12-20
//last version//2024-1-11
using LearningHub2.Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.IdentityModel.Tokens;
using MyChannel.Core.Commen;
using MyChannel.Core.Repository;
using MyChannel.Core.Service;
using MyChannel.Infra.Commen;
using MyChannel.Infra.Repository;
using MyChannel.Infra.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbContext,DbContext>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IFeedbackRepository,FeedbackRepository>();
builder.Services.AddScoped<IFeedbackService,FeedbackService>();

builder.Services.AddScoped<IVideoRepository, VideoRepository>();
builder.Services.AddScoped<IVideoService, VideoService>();

builder.Services.AddScoped<IResponseRepository,ResponseRepository>();
builder.Services.AddScoped<IResponseService,ResponseService>();

builder.Services.AddScoped<ICommentRepository,CommentRepository>();
builder.Services.AddScoped<ICommentService,CommentService>();

builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();


builder.Services.AddScoped<IChannelRepository, ChannelRepository>();
builder.Services.AddScoped<IChannelService, ChannelService>();


builder.Services.AddScoped<INotificationRepoistory, NotificationRepoistory>();
builder.Services.AddScoped<INotificationService, NotificationService>();


builder.Services.AddScoped<IReportRepoistory, ReportRepoistory>();
builder.Services.AddScoped<IReportService, ReportService>();

builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService,LoginService>();

builder.Services.AddScoped<IFooterRepository, FooterRepository>();
builder.Services.AddScoped<IFooterService, FooterService>();

builder.Services.AddScoped<IHomeRepository, HomeRepository>();
builder.Services.AddScoped<IHomeService, HomeService>();

builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<IAboutService, AboutService>();

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddScoped<ITeamMembersRepository, TeamMembersRepository>();
builder.Services.AddScoped<ITeamMembersService, TeamMembersService>();

builder.Services.AddScoped<IChannelsubService, ChannelsubService>();
builder.Services.AddScoped<IChannelsubRepository, ChannelsubRepository>();


builder.Services.AddScoped<IFeaturesRepository, FeaturesRepository>();

builder.Services.AddScoped<IFeaturesService, FeaturesService>();


builder.Services.AddCors(corsOptions =>

{

    corsOptions.AddPolicy("policy",

    builder =>

    {

        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

    });

});

builder.Services.AddAuthentication(opt => {

    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})






   .AddJwtBearer(options =>

   {

       options.TokenValidationParameters = new TokenValidationParameters

       {

           ValidateIssuer = true,

           ValidateAudience = true,

           ValidateLifetime = true,

           ValidateIssuerSigningKey = true,

           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HelloTraineesinwebapicourse@6789"))

       };

   });

void ConfigureServices(IServiceCollection services)
{
    // Other configurations...

    services.Configure<FormOptions>(options =>
    {
        options.ValueLengthLimit = int.MaxValue; // Infinite length for the request body
        options.MultipartBodyLengthLimit = int.MaxValue; // Infinite length for the multipart/form-data
    });

    // Other configurations...
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("policy");

app.MapControllers();

app.Run();
