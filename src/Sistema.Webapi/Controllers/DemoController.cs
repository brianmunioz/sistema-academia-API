using Microsoft.AspNetCore.Mvc;

namespace Sistema.Webapi.Controllers;
[ApiController]
[Route("Demo")]
public class DemoController:ControllerBase
{
    [HttpGet("getstring")]
    public string GetNombre(){
        return ".NET developer Brian Muñoz";
    }
}