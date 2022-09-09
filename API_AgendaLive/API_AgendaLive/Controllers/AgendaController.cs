using API_AgendaLive.Data;
using API_AgendaLive.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_AgendaLive.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class AgendaController : Controller
    {
        private readonly Contexto _context;

        public AgendaController(Contexto context)
        {
            _context = context;
        }

        // ---------- GET DE LISTA GERAL ----------
        [Route("Cadastro")]
        [HttpGet]
        public ActionResult<List<AgendaModel>> Cadastro()
        {
            List<AgendaModel> cadastroModel = new List<AgendaModel>();

            var cad = _context.TB_AGENDA.ToList();

            foreach (var item in cad)
            {
                AgendaModel dados = new AgendaModel()
                {
                    id = item.id,
                    liveName = item.liveName,
                    channelName = item.channelName,
                    liveDate = item.liveDate,
                    liveLink = item.liveLink,
                    registrationDate = item.registrationDate
                };
                cadastroModel.Add(dados);
            }

            return Json(cadastroModel);
        }

        // ---------- INSERIR DADO ----------
        [Route("Insert")]
        [HttpPost]
        public ActionResult<List<AgendaModel>> Insert(AgendaModel dados)
        {

            TB_AGENDA tB_AGENDA = new TB_AGENDA();

            tB_AGENDA.liveName = dados.liveName;
            tB_AGENDA.channelName = dados.channelName;
            tB_AGENDA.liveDate = dados.liveDate;
            tB_AGENDA.liveLink = dados.liveLink;
            tB_AGENDA.registrationDate = dados.registrationDate;
            _context.TB_AGENDA.Add(tB_AGENDA);
            _context.SaveChanges();

            return Json(tB_AGENDA);
        }

        // ---------- UPDATE DO DADO ----------
        [Route("Update")]
        [HttpPost]
        public ActionResult<List<AgendaModel>> Update(AgendaModel dados)
        {

            var cad = _context.TB_AGENDA.Where(x => x.id == dados.id).FirstOrDefault();

            if (cad != null)
            {
                cad.id = dados.id;
                cad.liveName = dados.liveName;
                cad.channelName = dados.channelName;
                cad.liveDate = dados.liveDate;
                cad.liveLink = dados.liveLink;
                cad.registrationDate = dados.registrationDate;
                _context.SaveChanges();
            }

            return Json(cad);
        }

        // ---------- BUSCANDO DADO POR ID ----------
        [Route("Get/{id}")]
        [HttpGet]
        public ActionResult<AgendaModel> Get(int id)
        {
            var cad = _context.TB_AGENDA.Where(x => x.id == id).FirstOrDefault();
            return Json(cad);
        }

        // ---------- DELETAR DADO ----------
        [Route("Delete")]
        [HttpPost]
        public bool Delete(IdModel dados)
        {
            try
            {
                //int id1 = int.Parse(codigo);
                var cad = _context.TB_AGENDA.Where(x => x.id == dados.id).FirstOrDefault();

                if (cad != null)
                {
                    _context.TB_AGENDA.Remove(cad);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
