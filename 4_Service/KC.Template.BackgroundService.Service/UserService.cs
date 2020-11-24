using KC.Template.BackgroundService.Infrastructure;
using KC.Template.BackgroundService.IRepository;
using KC.Template.BackgroundService.IService;
using Microsoft.Extensions.Options;
using System;
using System.Threading;

namespace KC.Template.BackgroundService.Service
{
    public class UserService : BaseService, IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly CustomSettings _customSettings;

        public UserService(IUserRepository userRepository,
            IOptions<CustomSettings> customSettingsOption)
        {
            _userRepository = userRepository;
            _customSettings = customSettingsOption.Value;
        }
        public void Excute()
        {
            var data = _userRepository.GetAll();
            Console.WriteLine(data.ToString());
            Thread.Sleep(_customSettings.SleepTime);
        }

     
    }
}
