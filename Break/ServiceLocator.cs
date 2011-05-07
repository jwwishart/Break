using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Break.Core;
using System.Reflection;
using System.IO;
using System.Configuration;

namespace Break
{
    internal class ServiceLocator
    {
        private static Assembly _serviceAssembly;


        // Properties
        //

        internal static string ServicesAssemblyPath {
            get {
                return (new FileInfo(ConfigurationManager.AppSettings["ServicesAssemblyName"] + ".dll")).FullName;
            }
        }

        internal static string SoundPlayerType {
            get {
                return ConfigurationManager.AppSettings["SoundPlayerType"];
            }
        }

        internal static string SystemUseServiceType {
            get {
                return ConfigurationManager.AppSettings["SystemUseServiceType"];
            }
        }


        // Internal Methods
        //
        
        internal static ISoundPlayer GetSoundPlayer() {
            if (_serviceAssembly == null)
                _serviceAssembly = Assembly.LoadFile( ServiceLocator.ServicesAssemblyPath );

            return (ISoundPlayer)_serviceAssembly.CreateInstance( ServiceLocator.SoundPlayerType, true );
        }

        internal static ISystemUseService GetSystemUseService() {
            if ( _serviceAssembly == null )
                _serviceAssembly = Assembly.LoadFile( ServiceLocator.ServicesAssemblyPath );

            return (ISystemUseService)_serviceAssembly.CreateInstance( ServiceLocator.SystemUseServiceType, true );
        }
    }
}
