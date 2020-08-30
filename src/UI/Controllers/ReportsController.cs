using System.Threading.Tasks;
using AutoMapper;
using BusinessTempus.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UI.ViewModels;

namespace UI.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;


        public ReportsController(IMapper mapper,
                                   ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        [Route("relatorio")]
        public async Task<IActionResult> Index()
        {
            ReportViewModel report = new ReportViewModel();
            
            report.Count = await _customerRepository.GetCount();
            report.ClassA = await _customerRepository.GetCountClassA();
            report.ClassB = await _customerRepository.GetCountClassB();
            report.ClassC = await _customerRepository.GetCountClassC();
            return View(report);
        }
    }
}
