using KC.Template.BackgroundService.Infrastructure;
using KC.Template.BackgroundService.IService;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KC.Template.BackgroundService.BgService
{
    public class UserHS : Microsoft.Extensions.Hosting.BackgroundService
    {
        private readonly CustomSettings _customSettings;
        private readonly ILogger<UserHS> _logger;
        private readonly IUserService _userService;

        public UserHS(IOptions<CustomSettings> customSettingsOption,
            ILogger<UserHS> logger,
            IUserService userService)
        {
            _customSettings = customSettingsOption.Value;
            _logger = logger;
            _userService = userService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TaskFactory factory = new TaskFactory();
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await factory.StartNew(() => _userService.Excute(), TaskCreationOptions.LongRunning);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "程序异常");
                    Thread.Sleep(_customSettings.SleepTime);
                }
            }
        }
    }
}
