using System;
using System.Configuration;

namespace JSTC.Config
{
    public class JSTCConfigurationSection : ConfigurationSection, IJSTCConfiguration
    {
        private const string ExtensionKey = "extension";
        private const string PathKey = "path";
        private const string OutputKey = "output";
        private const string JsObjectKey = "jsObject";
        private const string InitializeJsObjectKey = "initJsObject";
        private const string ListenKey = "listen";

        // Invalid characters taken from Path.GetInvalidFileNameChars()
        [ConfigurationProperty(ExtensionKey, DefaultValue = ".tmpl.html", IsRequired = false)]
        [StringValidator(InvalidCharacters = "\x0022\x003C\x003E\x007C\x0000\x0001\x0002\x0003"
            + "\x0004\x0005\x0006\x0007\x0008\x0009\x000A\x000B\x000C\x000D\x000E\x000F\x0010"
            + "\x0011\x0012\x0013\x0014\x0015\x0016\x0017\x0018\x0019\x001A\x001B\x001C\x001D"
            + "\x001E\x001F\x003A\x002A\x003F\x005C\x002F", MinLength = 2)]
        public String Extension
        {
            get
            {
                return (String)this[ExtensionKey];
            }
            set
            {
                this[ExtensionKey] = value;
            }
        }

        // Invalid characters taken from Path.GetInvalidPathChars()
        [ConfigurationProperty(PathKey, DefaultValue = ".", IsRequired = false)]
        [StringValidator(InvalidCharacters = "\x0022\x003C\x003E\x007C\x0000\x0001\x0002\x0003"
            + "\x0004\x0005\x0006\x0007\x0008\x0009\x000A\x000B\x000C\x000D\x000E\x000F\x0010"
            + "\x0011\x0012\x0013\x0014\x0015\x0016\x0017\x0018\x0019\x001A\x001B\x001C\x001D"
            + "\x001E\x001F", MinLength = 1)]
        public String Path
        {
            get
            {
                return (String)this[PathKey];
            }
            set
            {
                this[PathKey] = value;
            }
        }

        [ConfigurationProperty(OutputKey, DefaultValue = "", IsRequired = false)]
        [StringValidator(InvalidCharacters = "\x0022\x003C\x003E\x007C\x0000\x0001\x0002\x0003"
            + "\x0004\x0005\x0006\x0007\x0008\x0009\x000A\x000B\x000C\x000D\x000E\x000F\x0010"
            + "\x0011\x0012\x0013\x0014\x0015\x0016\x0017\x0018\x0019\x001A\x001B\x001C\x001D"
            + "\x001E\x001F")]
        public String Output
        {
            get
            {
                return (String)this[OutputKey];
            }
            set
            {
                this[OutputKey] = value;
            }
        }

        [ConfigurationProperty(JsObjectKey, DefaultValue = "templates", IsRequired = true)]
        [RegexStringValidator(@"^[A-Za-z][A-Za-z\.]*$")]
        public String JsObject
        {
            get
            {
                return (String)this[JsObjectKey];
            }
            set
            {
                this[JsObjectKey] = value;
            }
        }

        [ConfigurationProperty(InitializeJsObjectKey, DefaultValue = true, IsRequired = false)]
        public Boolean InitializeJsObject
        {
            get
            {
                return (Boolean)this[InitializeJsObjectKey];
            }
            set
            {
                this[InitializeJsObjectKey] = value;
            }
        }

        [ConfigurationProperty(ListenKey, DefaultValue = false, IsRequired = false)]
        public Boolean Listen
        {
            get
            {
                return (Boolean)this[ListenKey];
            }
            set
            {
                this[ListenKey] = value;
            }
        }
    }
}
