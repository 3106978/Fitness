using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    public abstract class BaseController
    {
        private readonly IDataSaver manager = new DataBaseDataSaver();

        protected void Save<T>(List<T> item) where T:class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
       

    }
}
