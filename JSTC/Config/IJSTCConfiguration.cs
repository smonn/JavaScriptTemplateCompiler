using System;

namespace JSTC.Config
{
    public interface IJSTCConfiguration
    {
        String Extension { get; set; }
        String Path { get; set; }
        String Output { get; set; }
        String JsObject { get; set; }
        Boolean InitializeJsObject { get; set; }
        Boolean Listen { get; set; }
    }
}
