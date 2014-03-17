using System;
using System.Configuration;

namespace JSTC.Config
{
    public sealed class JSTCConfiguration : IJSTCConfiguration
    {
        private readonly IJSTCConfiguration _config;

        public JSTCConfiguration()
        {
            _config = ConfigurationManager.GetSection("jstc") as IJSTCConfiguration;
        }

        public String Extension
        {
            get
            {
                return _config.Extension;
            }
            set
            {
                _config.Extension = value;
            }
        }

        public String Path
        {
            get
            {
                return _config.Path;
            }
            set
            {
                _config.Path = value;
            }
        }

        public String Output
        {
            get
            {
                return _config.Output;
            }
            set
            {
                _config.Output = value;
            }
        }


        public String JsObject
        {
            get
            {
                return _config.JsObject;
            }
            set
            {
                _config.JsObject = value;
            }
        }

        public Boolean InitializeJsObject
        {
            get
            {
                return _config.InitializeJsObject;
            }
            set
            {
                _config.InitializeJsObject = value;
            }
        }


        public Boolean Listen
        {
            get
            {
                return _config.Listen;
            }
            set
            {
                _config.Listen = value;
            }
        }
    }
}
