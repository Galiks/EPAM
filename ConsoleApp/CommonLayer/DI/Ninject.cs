using BusinessLogicLayer.Implementations;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Implementations;
using DataAccessLayer.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DI
{
    public class Ninject
    {
        private static readonly IKernel kernel = new StandardKernel();

        public static IKernel Kernel => kernel;

        public static void Registration()
        {
            Kernel.Bind<IBackupDao>().To<BackupDao>();
            Kernel.Bind<IBackupLogic>().To<BackupLogic>();

            Kernel.Bind<IFileDao>().To<FileDao>();
            Kernel.Bind<IFileLogic>().To<FileLogic>();

            Kernel.Bind<IDirectoryDao>().To<DirectoryDao>();
            Kernel.Bind<IDirectoryLogic>().To<DirectoryLogic>();
        }
    }
}
