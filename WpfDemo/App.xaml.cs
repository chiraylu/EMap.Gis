﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IConfigurationRoot Configuration { get; }
        string[] _extensions = new[] { "dll", "exe" };
        static List<string> _privatePathes;
        static App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            var privatePathesSection = Configuration.GetSection("PrivatePathes");
            _privatePathes = new List<string>();
            foreach (var item in privatePathesSection.GetChildren())
            {
                _privatePathes.Add(item.Value);
            }
        }
        public App()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;
        }
        private Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly assembly = null;
            // check the installation directory
            if (_privatePathes != null)
            {
                string assemblyName = new AssemblyName(args.Name).Name;
                foreach (string directory in _privatePathes)
                {
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directory);
                    if (Directory.Exists(path))
                    {
                        foreach (string extension in _extensions)
                        {
                            var potentialFiles = Directory.GetFiles(path, assemblyName + "." + extension, SearchOption.TopDirectoryOnly);
                            if (potentialFiles.Length > 0)
                            {
                                assembly = Assembly.LoadFrom(potentialFiles[0]);
                                if (assembly != null)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if (assembly != null)
                    {
                        break;
                    }
                }
            }
            // assembly not found
            return assembly;
        }
    }
}
