//Bibliotecas 
using Microsoft.AspNetCore.Mvc;
using Projeto1.Repositorio;

namespace Projeto1.Controllers
{
    public class UsuarioController : Controller
    {
        //Declarando uma variável privada somente para leitura (ReadOnly) do tipo "UsuarioRepositorio" chama "_usuarioRepositorio"
        private readonly UsuarioRepositorio _usuarioRepositorio;

        //Definindo o construtor da classe UsuarioController que vai receber uma instância de UsuarioRepositorio
        public UsuarioController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        { 
            /* Chama o método ObterUsuario do _usuarioRepositorio, passando o email fornecido pelo usuário.
                  Isso buscará um usuário no banco de dados com o email correspondente.*/
                var usuario = _usuarioRepositorio.ObterUsuario(email);
            // Verifica se um usuário foi encontrado for diferente de vazio e se a senha fornecida corresponde à senha do usuário encontrado.
            if (usuario != null && usuario.Senha == senha)
            {
                return RedirectToAction("Cliente", "Cliente");
                // Autenticação bem-sucedida
                // Redireciona o usuário para a action "Index" do Controller "Cliente".
            }
             /* Se a autenticação falhar (usuário não encontrado ou senha incorreta):
             Adiciona um erro ao ModelState. ModelState armazena o estado do modelo e erros de validação.
             O primeiro argumento ("") indica um erro
             O segundo argumento é a mensagem de erro que será exibida ao usuário.*/
            
            ModelState.AddModelError("", "Email ou senha inválidos.");
            //retorna view Login 
            return View();
        }
        public IActionResult Contato()
        { 
            return View();   
        }
    }
}