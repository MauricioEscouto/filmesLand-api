using Microsoft.AspNetCore.Mvc;

namespace filmesLand_api.Shared.OutputPort
{
    public class OutputPort : ControllerBase
    {
        public IActionResult NaoEncontrado(string mensagem)
        {
            return base.NotFound(mensagem);
        }

        public IActionResult Sucesso(object obj)
        {
            return base.Ok(obj);
        }
    }
}
