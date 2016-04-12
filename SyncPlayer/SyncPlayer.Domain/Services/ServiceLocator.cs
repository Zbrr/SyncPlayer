using System;
using System.Collections.Generic;
using SyncPlayer.Common.Contracts;
using SyncPlayer.Common.Enums;
using SyncPlayer.DropboxAPI.Services;

namespace SyncPlayer.Domain.Services
{
    public class ServiceLocator
    {
        private static Dictionary<AudioFileSource, object> serviceContainer;

        public ServiceLocator()
        {
            serviceContainer = new Dictionary<AudioFileSource, object>
            {
                { AudioFileSource.Dropbox, new DropboxFileFinderService() },
            };
        }

        public static IFileFinderService GetService(AudioFileSource fileSource)
        {
            try
            {
                return (IFileFinderService)serviceContainer[fileSource];
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Service not available.");
            }
        }
    }
}
